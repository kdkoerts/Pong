using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    public class platform : GameObject
    {
        
        public new float MaxVelocity = 4f;
        //public Texture2D sprite;
        public Keys ControlUp;
        public Keys ControlDown;


        public void Update() //Actually does all update stuff including user input
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
                if (Position.Y <= Game.SchreenHeight - sprite.Height)
                {
                    Position.Y = Position.Y + MaxVelocity;
                }
            }
        }
    }
}
