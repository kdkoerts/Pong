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
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        platform PlatformRight = new platform();
        platform PlatformLeft = new platform();
        Ball Ball = new Ball();
        public static int SchreenHeight;
        public static int SchreenWith;


        public Game1()
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
            Ball.Position = new Vector2(0.1f, 0.5f);
            Ball.Velocity = new Vector2(0.005f, -0.005f);
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
            Ball.sprite = Content.Load<Texture2D>("bal.png");
            
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

            //Move / update the platforms
            PlatformLeft.Move();
            PlatformRight.Move();
            Ball.Update();


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


            //Draw the items with their draw functions
            PlatformLeft.Draw(spriteBatch);
            PlatformRight.Draw(spriteBatch);
            Ball.Draw(spriteBatch);

            spriteBatch.End();
        }
    }
}
