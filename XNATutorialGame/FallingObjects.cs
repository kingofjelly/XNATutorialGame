using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

namespace XNATutorialGame
{
    class FallingObjects : Sprite //it inherits sprite
    {
        ///class for falling objects. For replication of something akin to cows calling game.
        ///AssetName
        ///Position x,y
        ///Rectangle?
        ///Speed
        ///Velocity?
        ///DEFAULT WINDOW SIZE = 800 x 600
        const string WIZARD_ASSETNAME = "SquareGuy";//temp placeholder

        const int START_POSITION_X = 125;
        const int START_POSITION_Y = 245;
        const int START_POSITION_X1 = 225;
        const int START_POSITION_Y1 = 245;
        const int START_POSITION_X2 = 325;
        const int START_POSITION_Y2 = 245;
        const int WIZARD_SPEED = 160;
        const int MOVE_UP = -1;
        const int MOVE_DOWN = 1;
        const int MaximumTimeLeft = 500;

        GameWideMethods GWM = new GameWideMethods();

        Vector2 mDirection = Vector2.Zero;
        Vector2 mSpeed = Vector2.Zero;
        

        public void LoadContent(ContentManager theContentManager)
        {
            //positions could be decided by RNG. Could also decide in here if fallingObArray < 4 in size, crete, else don't this run
            int positionChoice = GWM.randomNumer();

            if (positionChoice == 1)
            {
                Position = new Vector2(START_POSITION_X, START_POSITION_Y);
                base.LoadContent(theContentManager, WIZARD_ASSETNAME);
            }
            if (positionChoice == 2)
            {
                Position = new Vector2(START_POSITION_X1, START_POSITION_Y1);
                base.LoadContent(theContentManager, WIZARD_ASSETNAME);
            }
            if (positionChoice == 3)
            {
                Position = new Vector2(START_POSITION_X2, START_POSITION_Y2);
                base.LoadContent(theContentManager, WIZARD_ASSETNAME);
            }

            //Position = new Vector2(START_POSITION_X, START_POSITION_Y);
            //base.LoadContent(theContentManager, WIZARD_ASSETNAME);
            //we use the LoadContent method in the base class. This is sprite
        }
        //base class also has draw, update

        //Draw


        //Update
        public void Update(GameTime theGameTime)
        {
            //any methods can be put in here. It's a Update > Draw cycle, until the objectt gets unloaded
            KeyboardState aCurrentKeyboardState = Keyboard.GetState();            
            UpdateMovement();
            base.Update(theGameTime, mSpeed, mDirection);
            //mWizardSprite position.X
        }

        //UpdatePosition

        private void UpdateMovement()//updates movement. needed for positon and drawing
        {
            //simply pushes sprite down
            mSpeed = Vector2.Zero;
            mDirection = Vector2.Zero;
            //here, opposed to if key is pressed, update movemnt every sec
            mSpeed.Y = WIZARD_SPEED;
            mDirection.Y = MOVE_DOWN; //this will decrease by 1 for each iteration

           
        }

        private void CheckForProximityToWizard()
        {
            //method to check whether it's close to wizard. Do based on y Axis proximity and X axis? if x axis / give or take (sprite size
            //and x axis = within 50? push up?

            


        }
       
    }
}
