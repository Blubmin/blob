using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blob
{
    class Player
    {
        public Vector2 Position { get; private set; }
        public float Speed { get; }

        public Player()
        {
            Position = Vector2.Zero;
            Speed = 200;
        }

        public void Update(float time_elapsed)
        {
            Vector2 vel = Vector2.Zero;
            if (InputState.IsPressedDown(new Keys[] { Keys.W, Keys.Up }))
                vel += new Vector2(0, -1);
            if (InputState.IsPressedDown(new Keys[] { Keys.A, Keys.Left }))
                vel += new Vector2(-1, 0);
            if (InputState.IsPressedDown(new Keys[] { Keys.S, Keys.Down }))
                vel += new Vector2(0, 1);
            if (InputState.IsPressedDown(new Keys[] { Keys.D, Keys.Right }))
                vel += new Vector2(1, 0);

            Position += vel * time_elapsed * Speed;
        }

        public void Draw(SpriteBatch sb)
        {

        }
    }
}
