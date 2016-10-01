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
        public static int ColisionsHandled;
        public static void CollisionCounter()
        {
            ColisionsHandled++;
        }


        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
        }
        //static resolution = graphics.windowsize;

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
            PongBall.Position = new Vector2(SchreenWith / 2 , SchreenHeight / 2);
            PongBall.Velocity = new Vector2(1f, -0.5f);
            //Ball.speed = ()


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
            font = Content.Load<SpriteFont>("Font");

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
                Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.R)) PongBall.Spawn();
            //exit on pressing escape
            if (LivesRight < 0)
            {
                //Player Right is Dead
                //Do end of match stuff
            }
            if (LivesLeft < 0)
            {
                //Player Left is Dead
            }

            //Move / update the platforms
          //  if (!title.Visible)
          //      base.Update(gameTime);
            PlatformLeft.Update();
            PlatformRight.Update();
            PongBall.Update();


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black); //replace previous image with background color
            spriteBatch.Begin();
            base.Draw(gameTime);

            //spriteBatch.DrawString(
            spriteBatch.DrawString(font, ColisionsHandled.ToString(), new Vector2(100, 100), Color.White);

            //Draw the items with their draw functions
            PlatformLeft.Draw(spriteBatch);
            PlatformRight.Draw(spriteBatch);
            PongBall.Draw(spriteBatch);

            spriteBatch.End();
        }
    }
}
