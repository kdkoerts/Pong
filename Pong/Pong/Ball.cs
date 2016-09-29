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
        public void Spawn()
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
            else if (Position.Y >= Game.SchreenHeight - sprite.Height) //if it collides with one side it wont with the other
            {
                Velocity.Y = -Velocity.Y;
                Velocity = Velocity * VelocityModifier;
            }
            if (Position.X >= Game.SchreenWith - sprite.Width)
            {
                Game.LivesRight--;    //deduct a life
                Spawn();
            }
            else if (Position.X <= 0)   //if it collides with one side it wont with the other
            {
                Game.LivesLeft--;
                Spawn();
            }
            //#########################################################################
            //Check For platform Collision
            //Get easy acces to nececary variables, could this work with a reference or pointer etc.?
            Vector2 PRP = Game.PlatformRight.Position;
            Vector2 PLP = Game.PlatformLeft.Position;
            int PRH = Game.PlatformRight.sprite.Height;
            int PLH = Game.PlatformLeft.sprite.Height;
            int PRW = Game.PlatformRight.sprite.Width;
            int PLW = Game.PlatformLeft.sprite.Width;
            //Max upward angle deflexion at Position + sprite.height = P(R?L)P
            //Max downward angle deflection at Position = P(R?L)P + P(L?R)H
            //No angle deflection at Position + sprite.Height / 2 = P(LR)P + p(L?R)H / 2

            //Collision Left || Right
            if ((  Position.Y < PLP.Y + PLH && Position.Y + sprite.Height > PLP.Y && Position.X < PLP.X + PLW  )||
                (  Position.Y < PRP.Y + PRH && Position.Y + sprite.Height > PRP.Y && Position.X + sprite.Width > PRP.X  ))
            {
                Vector2 CPP;
                int CPW;
                int CPH;
                float speed = (float)Math.Sqrt(Math.Pow(Velocity.X, 2) + Math.Pow(Velocity.Y, 2));
                if (Position.X > Game.SchreenWith / 2) //wich side are we on?
                {
                    //Right Side
                    CPP = PRP;
                    CPW = PRW;
                    CPH = PRH;
                    Position.X = Game.SchreenWith - CPW - sprite.Width;
                }
                else
                {
                    //Left Side
                    CPP = PLP;
                    CPW = PLW;
                    CPH = PLH;
                    speed = speed * -1;
                    Position.X = CPW;
                }
                //Find Relative position
                Vector2 RelativePos = new Vector2();
                RelativePos = new Vector2((Position.X + sprite.Width / 2) - (CPP.X + CPW / 2), (Position.Y + sprite.Height / 2) - (CPP.Y + CPH / 2));
                float MaxRelativePos = CPH / 2 + sprite.Height;
                //float entryAngle = 
                float exitAngle = (RelativePos.Y / MaxRelativePos) * 90; //Could cause problems in extreme cases (platform edges) TO BE TESTED

                Velocity.X = speed * (float)Math.Cos(exitAngle);
                Velocity.Y = speed * (float)Math.Sin(exitAngle);                   


                Velocity = Velocity * VelocityModifier; //add speed on collision
                if (Velocity.X == 0 && Velocity.Y == 0) Spawn();
            }
        }
    }
}
