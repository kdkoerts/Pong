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
            //#########################################################################
            //Check For platform Collision
            //Get easy acces to nececary variables
            Vector2 PRP = Game.PlatformRight.Position;
            Vector2 PLP = Game.PlatformLeft.Position;
            int PRH = Game.PlatformRight.sprite.Height;
            int PLH = Game.PlatformLeft.sprite.Height;
            int PRW = Game.PlatformRight.sprite.Width;
            int PLW = Game.PlatformLeft.sprite.Width;
            //Collision Left
            if (Position.Y < PLP.Y + PLH && Position.Y + sprite.Height > PLP.Y && Position.X < PLP.X + PLW)
            {
                //Bounce
                Velocity.X = -Velocity.X;
                Velocity = Velocity * VelocityModifier; //add speed on collision
            }

            //Collision Right
            if (Position.Y < PRP.Y + PRH && Position.Y + sprite.Height > PRP.Y && Position.X + sprite.Width > PRP.X)
            {
                //Bounce
                Velocity.X = -Velocity.X;
                Velocity = Velocity * VelocityModifier; //add speed on collision
            }

        }
    }
}
