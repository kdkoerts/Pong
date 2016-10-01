using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
/*

Add sound {
    Joke(Tennis grunting Sound?) HIEASda
}

Add Fancy GFX {

    Trails, Particles etc
}

Add AI ()

*/

namespace Pong
{

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private SpriteFont font;
        public static platform PlatformRight = new platform();
        public static platform PlatformLeft = new platform();
        public static Ball PongBall = new Ball();
        public static int SchreenHeight;
        public static int SchreenWith;
        public static int LivesLeft = 5;
        public static int LivesRight = 5;
        public static Random Random = new Random(); //call .next() or .next (int minimum, int maximum)
        public bool title = true;
        public bool startup = true;


        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            SchreenHeight = graphics.GraphicsDevice.Viewport.Height; //This is needed in the platform.draw()
            SchreenWith = graphics.GraphicsDevice.Viewport.Width;
            //Add data to the platforms: start position, controls etc.
            PlatformLeft.Position.X = 0;
            PlatformLeft.ControlUp = Keys.W;
            PlatformLeft.ControlDown = Keys.S;
            
            PlatformRight.ControlUp = Keys.Up;
            PlatformRight.ControlDown = Keys.Down;
            PongBall.Spawn();


            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //The sprites for the platforms
            PlatformLeft.sprite = Content.Load<Texture2D>("blauweSpeler.png");
            PlatformRight.sprite = Content.Load<Texture2D>("rodeSpeler.png");
            PlatformRight.Position.X = SchreenWith - PlatformRight.sprite.Width;
            PongBall.sprite = Content.Load<Texture2D>("bal.png");
            font = Content.Load<SpriteFont>("Miramob");

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();     //exit on pressing escape
            if (Keyboard.GetState().IsKeyDown(Keys.R)) PongBall.Spawn();

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {//Restart the game
                title = false;
                startup = false;
                LivesLeft = 5;
                LivesRight = 5;
            }

            if (LivesRight <= 0)
            {
                title = true;
                //Player Right is Dead
                //Do end of match stuff
            }
            if (LivesLeft <= 0)
            {
                title = true;
                //Player Left is Dead
            }

            if (title == false)
            {
                PlatformLeft.Update();
                PlatformRight.Update();
                PongBall.Update();
                base.Update(gameTime);
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black); //replace previous image with background colors
            spriteBatch.Begin();
            base.Draw(gameTime);
            if (startup == true)
            {
                spriteBatch.DrawString(font, "Welcome to Pong! \n Press Space to Start.", new Vector2(250, 200), Color.White);
            }
            if (LivesLeft <= 0)
            {
                spriteBatch.DrawString(font, "Red WINS!.", new Vector2(250, 200), Color.White);
            }
            if (LivesRight <= 0)
            {
                spriteBatch.DrawString(font, "Blue WINS!.", new Vector2(250, 200), Color.White);
            }
            if (title == false)
            {

                //Draw the items with their draw functions
                PlatformLeft.Draw(spriteBatch);
                PlatformRight.Draw(spriteBatch);
                PongBall.Draw(spriteBatch);
            }
            spriteBatch.End();
        }
    }
}
