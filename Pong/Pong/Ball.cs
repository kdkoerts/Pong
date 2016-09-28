using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    class Ball : GameObject
    {
        //public Vector2 Position;
        //public Vector2 Speed;
        //public Texture2D sprite;

        public void Update()
        {
            Position = Position + Velocity;
            ColisionHandeler();
            // Collision nog toevoegen Hi


        }
        void Spawn()
        {
            Position = new Vector2(0.5f, 0.5f);
            Velocity = new Vector2(0.05f, 0.05f);
        }
    }
}
