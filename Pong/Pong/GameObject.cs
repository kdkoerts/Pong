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
    public class GameObject //Draw a given sprite at a given position
    {
        public string Name;
        public Vector2 Position;
        public Vector2 Velocity;
        public float MaxVelocity;
        public Texture2D sprite;
        public Vector2 VelocityModifier = new Vector2(1.05f, 1.05f);

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(sprite, Position); //Vector2 pos in pixels from top left.
        }        
    }
}
