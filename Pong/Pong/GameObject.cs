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
        public void ColisionHandeler() //Check and handle a collision.
        {
            if (Position.Y <= 0)
            {
                Velocity.Y = -Velocity.Y;
                Velocity = Velocity * new Vector2(1.1f, 1.1f); //add speed on collision
            }
            if (Position.Y >= 1)
            {
                Velocity.Y = -Velocity.Y;
                Velocity = Velocity * new Vector2(1.1f, 1.1f);
            }
            if (Position.X >= 1)
            {
                Velocity.X = -Velocity.X;
                Velocity = Velocity * new Vector2(1.1f, 1.1f);
                //remove
                //Goal!!
                //Ball.Kill()
                //Score.Update()
                //Ball.Respawn()
            }
            if (Position.X <= 0)
            {
                Velocity.X = -Velocity.X;
                Velocity = Velocity * new Vector2(1.1f, 1.1f);
                //remove
                //Goal!!
                //Ball.Kill()
                //Score.Update()
                //Ball.Respawn()
            }
            //Collision with platform
            
        }
    }
}
