using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Graphics;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.ViewportAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blob {
    class SinglePlayer : GameMode {
        ContentManager Content;
        TiledMap map;
        TiledMapRenderer renderer;
        Camera2D camera;
        Texture2D whiteRectangle;
        Player player;

        public SinglePlayer(GameWindow w, GraphicsDevice gd) : base(w, gd) {
            ViewportAdapter adapter = new BoxingViewportAdapter(Window, GraphicsDevice, 800, 480);
            camera = new Camera2D(adapter);
            player = new Player();
            map = AssetManager.GetLevel("Sandbox");
            renderer = new TiledMapRenderer(GraphicsDevice);
        }

        override
        public void Update(float time_elapsed) {
            player.Update(time_elapsed);
            camera.LookAt(new Vector2((int)player.Position.X, (int)player.Position.Y));
        }

        override
        public void Draw(SpriteBatch sb) {
            renderer.Draw(map, camera.GetViewMatrix());
        }

        override
        public Matrix GetViewMatrix() {
            return camera.GetViewMatrix();
        }
    }
}
