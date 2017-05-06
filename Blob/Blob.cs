using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Graphics;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.ViewportAdapters;

namespace Blob
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Blob : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        TiledMap map;
        TiledMapRenderer renderer;
        Camera2D camera;
        Texture2D whiteRectangle;
        Player player;

        public Blob()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 550;
            Window.AllowUserResizing = true;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize() {
            // TODO: Add your initialization logic here
            InputState.Init();
            ViewportAdapter adapter = new BoxingViewportAdapter(Window, GraphicsDevice, 800, 480);
            camera = new Camera2D(adapter);
            player = new Player();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent() {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            map = Content.Load<TiledMap>("Sandbox");
            renderer = new TiledMapRenderer(GraphicsDevice);

            whiteRectangle = new Texture2D(GraphicsDevice, 1, 1);
            whiteRectangle.SetData(new[] { Color.White });
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent() {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime) {
            InputState.Update();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            // TODO: Add your update logic here
            player.Update(gameTime.GetElapsedSeconds());
            camera.LookAt(new Vector2((int) player.Position.X, (int) player.Position.Y));

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin(transformMatrix: camera.GetViewMatrix());
            renderer.Draw(map, camera.GetViewMatrix());
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
