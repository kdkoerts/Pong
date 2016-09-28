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
        public Vector2 VelocityModifier = new Vector2(1f, 1f);
        public Vector2 ResolutionFactor; //Value given on LoadContent

        public void Draw(SpriteBatch spritebatch)
        {
            //draw the Sprite from float 0-1 position
            //The pixel position is mapped from the (0 to 1) float value with a ConversionFactor
            //wich is created with the schreen resolution and the sprite size
            Vector2 SpritePosition;
            
            SpritePosition = Position * ResolutionFactor;

            spritebatch.Draw(sprite, SpritePosition); //Vector2 pos in pixels from top left.

        }

        
    }
}
