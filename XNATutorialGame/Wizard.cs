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
    public class Wizard : Sprite //indicates it inherits sprite class. Will need to provide all sprite properties
    {
        const string WIZARD_ASSETNAME = "WizardSquare";
        const int START_POSITION_X = 640;//X IS HORIZONTAL. Y IS VERTICAL!!!!
        const int START_POSITION_Y = 600;
        const int WIZARD_SPEED = 160;
        const int MOVE_UP = -1;
        const int MOVE_DOWN = 1;
        const int MOVE_LEFT = -2;
        const int MOVE_RIGHT = 2;
        
        enum State
        {
            Walking//=1
        }

        State mCurrentState = State.Walking;

        Vector2 mDirection = Vector2.Zero;
        Vector2 mSpeed = Vector2.Zero;

        KeyboardState mPreviousKeyboardState;


        //create new LoadContent method
        public void LoadContent(ContentManager theContentManager)
        {
            Position = new Vector2(START_POSITION_X, START_POSITION_Y);
            base.LoadContent(theContentManager, WIZARD_ASSETNAME);
            //we use the LoadContent method in the base class. This is sprite
        }
        //base class also has draw, update

        public void Update(GameTime theGameTime)
        {
            KeyboardState aCurrentKeyboardState = Keyboard.GetState();

            //LINKS IN WITH ABOVE METHOD
            UpdateMovement(aCurrentKeyboardState);

            mPreviousKeyboardState = aCurrentKeyboardState;

            base.Update(theGameTime, mSpeed, mDirection);
        }
        //UPDATE WIZARD MOVEMENT
        private void UpdateMovement(KeyboardState aCurrentKeyboardState)//updates movement. needed for positon and drawing
        {
            if (mCurrentState == State.Walking)
            {
                mSpeed = Vector2.Zero;
                mDirection = Vector2.Zero;
                if (Position.X > 0) //0 is window  length. x axis
                {
                    if (aCurrentKeyboardState.IsKeyDown(Keys.Left) == true || aCurrentKeyboardState.IsKeyDown(Keys.A) == true)
                    {
                        mSpeed.X = WIZARD_SPEED;
                        mDirection.X = MOVE_LEFT;
                    }

                }

                else  if (Position.X == 0)
                    {

                        mSpeed.X = 0;//set speed to 0.
               
                    }


                if (Position.X < 1080)//sprite is 200 wide
                {
                    if (aCurrentKeyboardState.IsKeyDown(Keys.Right) == true || aCurrentKeyboardState.IsKeyDown(Keys.D) == true)
                    {
                        mSpeed.X = WIZARD_SPEED;
                        mDirection.X = MOVE_RIGHT;
                    }
                }
                else if (Position.X == 1080) //not 1280, due to sprite length of 200 pix
                {
                    mSpeed.X = 0;
                }

                //TEMP DISABLE UP DOWN. DON'T NEED FOR WIZARD SPRITE
                if (aCurrentKeyboardState.IsKeyDown(Keys.Up) == true || aCurrentKeyboardState.IsKeyDown(Keys.W) == true)
                {
                    mSpeed.Y = WIZARD_SPEED;
                    mDirection.Y = MOVE_UP;
                }
                else if (aCurrentKeyboardState.IsKeyDown(Keys.Down) == true || aCurrentKeyboardState.IsKeyDown(Keys.S) == true)
                {
                    mSpeed.Y = WIZARD_SPEED;
                    mDirection.Y = MOVE_DOWN;
                }
            }
        }
    }
}
