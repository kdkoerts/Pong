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
    class GameObject //Draw a given sprite at a given position
    {
        new Vector2 Position;
        new Vector2 Velocity;
        new float MaxVelocity;
        new Texture2D sprite;

        public void Draw(SpriteBatch spritebatch)
        {
            //draw the Sprite from float 0-1 position
            //The pixel position is mapped from the (0 to 1) float value with a ConversionFactor
            //wich is created with the schreen resolution and the sprite size
            Vector2 SpritePosition;
            Vector2 ResolutionFactor = new Vector2(Game1.SchreenWith - sprite.Width, Game1.SchreenHeight - sprite.Height);

            SpritePosition = Position * ResolutionFactor;

            spritebatch.Draw(sprite, SpritePosition); //Vector2 pos in pixels from top left.

        }
    }
}
