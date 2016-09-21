using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    public class platform
    {
        public Vector2 Position;
        public float MaxVelocity = 0.005f;
        public Texture2D sprite;
        public Keys ControlUp;
        public Keys ControlDown;

        public void Move() //Actually does all update stuff including user input
        {
            if (Keyboard.GetState().IsKeyDown(ControlUp))
            {
                if (Position.Y >= 0)
                {
                    Position.Y = Position.Y - MaxVelocity;
                }
            }
            if (Keyboard.GetState().IsKeyDown(ControlDown))
            {
                if (Position.Y <= 1)
                {
                    Position.Y = Position.Y + MaxVelocity;
                }
            }
        }
        public void Draw(SpriteBatch spritebatch)   //draw the Sprite from float 0-1 position
        {
            Vector2 SpritePosition;
            Vector2 ResolutionFactor = new Vector2(Game1.SchreenWith, Game1.SchreenHeight);
            //Correct resolution factor for sprite height. Find property's with 
            SpritePosition = Position * ResolutionFactor;
                        
            spritebatch.Draw(sprite, SpritePosition); //Vector2 pos in pixels from top left.

        }
    }
}
