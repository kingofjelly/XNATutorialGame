using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace XNATutorialGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game//inherits from framework class
    {
        GraphicsDeviceManager graphics;//XNA VARIABLES
        SpriteBatch spriteBatch;
        /*
        Vector2 mPosition = new Vector2(0, 0);//this basically is x and y co-ordinates. Just called Vector2.
        Texture2D mSpriteTexture;//Texture2D is a 2d image
         */
        Wizard mWizardSprite;//gives Wizard an alias?
        FallingObjects mFallingObjectSprite;
        FallingObjects[] fallingObjectsArray = new FallingObjects[3];
        //used internally of methods, to avoid objects going off screen
        public const int screenWidth = 1280;
        public const int screenHeight = 800;



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //initialize screen resizing
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
            Window.AllowUserResizing = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            mWizardSprite = new Wizard();
            mFallingObjectSprite = new FallingObjects();
            for (int i = 0; i < fallingObjectsArray.Length; i++)
            {
                fallingObjectsArray[i] = new FallingObjects();
            }



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

            // TODO: use this.Content to load your game content here
            //mSpriteTexture = this.Content.Load<Texture2D>("SquareGuy");

            mWizardSprite.LoadContent(this.Content);
            mFallingObjectSprite.LoadContent(this.Content);
            for (int i = 0; i < fallingObjectsArray.Length; i++)
            {
                fallingObjectsArray[i].LoadContent(this.Content);
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            mWizardSprite.Update(gameTime);
            mFallingObjectSprite.Update(gameTime);
            for (int i = 0; i < fallingObjectsArray.Length; i++)
            {
                fallingObjectsArray[i].Update(gameTime);
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            //Spritebatch object is auto created when windows game is made. this is what's used to draw 2d objects to screen. This needs to be begun and ended.
            spriteBatch.Begin();
            //spriteBatch.Draw(mSpriteTexture, mPosition, Color.White);
            mWizardSprite.Draw(this.spriteBatch);
            mFallingObjectSprite.Draw(this.spriteBatch);
            for (int i = 0; i < fallingObjectsArray.Length; i++)
            {
                fallingObjectsArray[i].Draw(this.spriteBatch);
            }
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
