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
    public class Ball : GameObject
    {
        //public Vector2 Position;
        //public Vector2 Speed;
        //public Texture2D sprite;

        public void Update()
        {
            Position = Position + Velocity;
            ColisionHandeler();
        }
        void Spawn()
        {
            Position = new Vector2(Game.SchreenWith / 2 , Game.SchreenHeight / 2);
            Velocity = new Vector2(5f, 0f);
        }

        public void ColisionHandeler() //Check and handle a collision.
        {
            if (Position.Y <= 0)
            {
                Velocity.Y = -Velocity.Y;
                Velocity = Velocity * VelocityModifier; //add speed on collision
            }
            if (Position.Y >= Game.SchreenHeight - sprite.Height)
            {
                Velocity.Y = -Velocity.Y;
                Velocity = Velocity * VelocityModifier;
            }
            if (Position.X >= Game.SchreenWith - sprite.Width)
            {
                Velocity.X = -Velocity.X;                   //remove
                Velocity = Velocity * VelocityModifier;     //remove

                Game.LivesRight--;    //deduct a life
                Spawn();
            }
            if (Position.X <= 0)
            {
                Velocity.X = -Velocity.X;                   //remove
                Velocity = Velocity * VelocityModifier;     //remove

                Game.LivesLeft--;
                Spawn();
            }
            //Collision with platform should go here?

            float xR = Game.PlatformRight.sprite.Width;
            float yR = Game.PlatformRight.sprite.Height;
            Vector2 OffsetR = new Vector2(2/yR, 2/xR);

            if ((Position.X >= Game.PlatformRight.Position.X - OffsetR.X && Position.X <= Game.PlatformRight.Position.X + OffsetR.X) &&
                (Position.Y >= Game.PlatformRight.Position.Y - OffsetR.Y && Position.Y <= Game.PlatformRight.Position.Y + OffsetR.Y))
            {
                float speed = (float) Math.Sqrt((Math.Pow(Velocity.X, 2)) + Math.Pow(Velocity.Y, 2));


            }

            float xL = Game.PlatformLeft.sprite.Width;
            float yL = Game.PlatformLeft.sprite.Height;
            Vector2 OffsetL = new Vector2(2/yL, 2/xL);
            if ((Position.X >= Game.PlatformLeft.Position.X - OffsetL.X && Position.X <= Game.PlatformLeft.Position.X + OffsetL.X) &&
               (Position.Y >= Game.PlatformLeft.Position.Y - OffsetL.Y && Position.Y <= Game.PlatformLeft.Position.Y + OffsetL.Y))
            {
                Velocity.X = -Velocity.X;


            }
         }
    }
}
