using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blob {
    abstract class GameMode {
        protected GraphicsDevice GraphicsDevice;
        protected GameWindow Window;

        public GameMode(GameWindow w, GraphicsDevice gd) {
            GraphicsDevice = gd;
            Window = w;
        }

        public abstract void Update(float time_elapsed);
        public abstract void Draw(SpriteBatch sb);
        public abstract Matrix GetViewMatrix();
    }
}
