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
        //for cow class. position and texture

        //COW VARIABLES
        
        Texture2D mCowTexture;//Texture2D is a 2d image                
        Cows mCowSprite;
        GameMusicSounds mMusicSounds;
        List<Cows> mCowSprites = new List<Cows>();//initialize as new list;//DOESN'T NEED INITIALIZING

        //PLAYER VARIABLES:
        //Don't know why the variables below are here
        Texture2D mPlayerTexture;
        PlayerFan mPlayerSprite;
        PlayerScore mPlayerScoreSprite;


        //movement for falling object
        const int MOVE_UP = -1;
        const int MOVE_DOWN = 1;
        
      
        //used internally of methods, to avoid objects going off screen
        public const int screenWidth = 1280;
        public const int screenHeight = 800;

               
        //int used for timing whether another obj should be spawned. could spawn tons in a line. will prove correct
        private int spawnTimer = 0;

        Color backgroundColor = Color.Aquamarine;//change color to prove intersect


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
           
            mCowSprite = new Cows();//initialise instance
            mPlayerSprite = new PlayerFan();
            mPlayerScoreSprite = new PlayerScore();
            mMusicSounds = new GameMusicSounds();
            
            
           



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
            mCowSprite.LoadContent(this.Content, "SquareGuy");//call loadcontent method. this.Content, because you pass in Gam1 contentmanager
            mPlayerSprite.LoadContent(this.Content, "WizardSquare");//call loadcontent method. this.Content, because you pass in Gam1 contentmanager

            //load font
            mPlayerScoreSprite.LoadContent(this.Content, "DefaultFont");

            //load song
            //mMusicSounds.LoadContent(this.Content, "Chiptune_Artic_Odyssey");

            //load list?
            //DONT NEED TO LOAD HERE. I LOAD AS I ADD TO LIST
            //foreach (Cows mCowInList in mCowSprites)
            //{
            //    //for each cow in list, LOAD
            //    mCowInList.LoadContent(this.Content, "SquareGuy");
            //}
            
            
            
            
            
          
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
            //RemoveFallenCowFromList();
            mPlayerSprite.Update(gameTime);
            mCowSprite.Update(gameTime);
            checkIfIntersect();
            //reverseFallingSpriteDirection();
            spawnTimer++;
            checkIfCowShouldSpawn();
            foreach (Cows mCowInList in mCowSprites)
            {
                //for each cow in list, LOAD
                mCowInList.Update(gameTime);
            }
            CowHitsFloor();
            
            //as player score isn't reflective of time the game has gone on yet, doesn't need to be called. it's
            //interacted with, by another method
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
            //mCowSprite.Draw(this.spriteBatch);
            mPlayerSprite.Draw(this.spriteBatch);
            mPlayerScoreSprite.Draw(this.spriteBatch);

            //draw cow list
            foreach (Cows mCowInList in mCowSprites)
            {                
                mCowInList.Draw(this.spriteBatch);
            }

            spriteBatch.End();


            base.Draw(gameTime);
        }

        public void checkIfIntersect()
        {
            //my own method, to check if intersect happens
            foreach (Cows mCowInList in mCowSprites)
            {
                if (mPlayerSprite.playerBoundary.Intersects(mCowInList.cowBoundary))
                {
                    //if it intersects, slow speed of cow obj
                    mCowInList.MOVEMENT = MOVE_UP;
                    mPlayerScoreSprite.score += 100;//increase by 100. basically means score add 100 
                }
            }
          
        }   

        public void checkIfCowShouldSpawn()
        {
            //if timer == 100. add cow. reset timer
            if (spawnTimer == 100)
            {
                Cows mCowInList = new Cows();
                mCowInList.LoadContent(this.Content, "SquareGuy");
                mCowSprites.Add(mCowInList);
                spawnTimer = 0;//reset
            }
        }

        public void CowHitsFloor()
        {
         //loops through cowSprite List. If its boundary intersects/equals floor, remove from list
            for (int i = 0; i < mCowSprites.Count; i++)
            {
                if (mCowSprites[i].cowBoundary.Y == 800 - 91)
                {
                    //mCowInList.MOVEMENT = MOVE_UP;
                    mCowSprites.RemoveAt(i);
                }
                
            }
           

        }

        public void RemoveFallenCowFromList()
        {
            foreach (Cows mCowInList in mCowSprites)
            {
                if (mCowInList.cowPosition.Y == 0)
                {
                    //if it intersects, slow speed of cow obj
                    mCowSprites.Remove(mCowInList);
                }
            }
        }
       
    }
}
