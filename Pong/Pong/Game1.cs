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
        public static platform PlatformRight = new platform();
        public static platform PlatformLeft = new platform();
        public static Ball PongBall = new Ball();
        public static int SchreenHeight;
        public static int SchreenWith;
        public static int LivesLeft = 5;
        public static int LivesRight = 5;


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
            PlatformRight.Position.X= 1f;
            PlatformRight.ControlUp = Keys.Up;
            PlatformRight.ControlDown = Keys.Down;
            PongBall.Position = new Vector2(0.1f, 0.5f);
            PongBall.Velocity = new Vector2(0.005f, -0.005f);
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
            PlatformLeft.ResolutionFactor = new Vector2(Game.SchreenWith - PlatformLeft.sprite.Width, Game.SchreenHeight - PlatformLeft.sprite.Height);
            PlatformRight.sprite = Content.Load<Texture2D>("rodeSpeler.png");
            PlatformRight.ResolutionFactor = new Vector2(Game.SchreenWith - PlatformRight.sprite.Width, Game.SchreenHeight - PlatformRight.sprite.Height);
            PongBall.sprite = Content.Load<Texture2D>("bal.png");
            PongBall.ResolutionFactor = new Vector2(Game.SchreenWith - PongBall.sprite.Width, Game.SchreenHeight - PongBall.sprite.Height);
            
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
            PlatformLeft.Move();
            PlatformRight.Move();
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


            //Draw the items with their draw functions
            PlatformLeft.Draw(spriteBatch);
            PlatformRight.Draw(spriteBatch);
            PongBall.Draw(spriteBatch);

            spriteBatch.End();
        }
    }
}
