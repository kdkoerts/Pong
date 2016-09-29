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
        // angle = (float)Math.Atan2(Velocity.Y, Velocity.X);
        // 
        // double random = Ball.Random.NextDouble();

        public void Update()
        {
            Position = Position + Velocity;
            ColisionHandeler();
            // Collision nog toevoegen Hi


        }
        public void ColisionHandeler() //Check and handle a collision.
        {
            if (Position.Y <= 0)
            {
                Velocity.Y = -Velocity.Y;
                Velocity = Velocity * VelocityModifier; //add speed on collision
            }
            if (Position.Y >= 1)
            {
                Velocity.Y = -Velocity.Y;
                Velocity = Velocity * VelocityModifier;
            }
            if (Position.X >= 1)
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

        }
        public void Spawn()
        {
            Position = new Vector2(0.5f, 0.5f);
           /* int RandomAngle = new Random().Next(25, 155);
            int randomValue = new Random().Next(0, 1);
            if(randomValue == 0)
            {
                RandomAngle = -RandomAngle;
            }
            RandomAngle = (float)Math.Atan2(Velocity.Y, Velocity.X); */
            Velocity = new Vector2(0.05f, 0.05f);
        }
    }
}
