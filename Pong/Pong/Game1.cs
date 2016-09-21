using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
/*

Add sound {
    Joke(Tennis Sound?) 
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
            SchreenHeight = graphics.GraphicsDevice.Viewport.Height; //This needs to be set for (or be aviable to) ALL Platform items
            SchreenWith = graphics.GraphicsDevice.Viewport.Width;
            PlatformLeft.Position.X = 0;
            PlatformLeft.ControlUp = Keys.W;
            PlatformLeft.ControlDown = Keys.S;
            PlatformRight.Position.X= 0.9f;
            PlatformRight.ControlUp = Keys.Up;
            PlatformRight.ControlDown = Keys.Down;
            //Bal.position = (.5, .5);
            //Bal.speed = ()
            

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

            
            PlatformLeft.sprite = Content.Load<Texture2D>("blauweSpeler.png");
            PlatformRight.sprite = Content.Load<Texture2D>("rodeSpeler.png");
          //  Bal.sprite = Content.Load<Texture2D>("bal.png");
            

            // TODO: use this.Content to load your game content here
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
            PlatformLeft.Move();
            PlatformRight.Move();


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkBlue);
            spriteBatch.Begin();
            
            // TODO: Add your drawing code here

            base.Draw(gameTime);
            PlatformLeft.Draw(spriteBatch);
            PlatformRight.Draw(spriteBatch);

            spriteBatch.End();
        }
    }
}
