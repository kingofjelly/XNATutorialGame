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
    public class PlayerFan
    {
        //this is the class, for the object which the player will be controlling
        //vector for position
        //texture 2d for texture
        //speed?
        Vector2 playerPosition = new Vector2(540, 700);//position of player    X, Y
        Texture2D playerTexture;//cow texture
        string playerAssetName;
        Rectangle playerHitbox; //hitbox for my cow
        //200 x 200 for height x width
        
        const int START_POSITION_X = 640;//X IS HORIZONTAL. Y IS VERTICAL!!!!
        const int START_POSITION_Y = 600;
        const int WIZARD_SPEED = 320;//160
        const int MOVE_UP = -1;
        const int MOVE_DOWN = 1;
        const int MOVE_LEFT = -2;
        const int MOVE_RIGHT = 2;
        public Rectangle playerBoundary;

        enum State
        {
            Walking//=1
        }

        State mCurrentState = State.Walking;

        Vector2 mDirection = Vector2.Zero;
        Vector2 mSpeed = Vector2.Zero;

        KeyboardState mPreviousKeyboardState;

        //load
        public void LoadContent(ContentManager theContentManager, string theAssetName)
        {
            playerTexture = theContentManager.Load<Texture2D>(theAssetName);
            //sprite class doesn't have built in content manager, so needs one. It also needs name of asset that will be loaded
            //playerAssetName = theAssetName;
            //playerHitbox = new Rectangle(0, 0, (int)(playerTexture.Width), (int)(playerTexture.Height));
        }
        //update
        public void Update(GameTime theGameTime)
        {
            //calculation means : Cow position = cow position + sum of the following
            playerBoundary = new Rectangle((int)playerPosition.X, (int)playerPosition.Y, 120, 50);//200, 200 is widtth and height. first to are position
            KeyboardState aCurrentKeyboardState = Keyboard.GetState();
            UpdateMovement(aCurrentKeyboardState);
            playerPosition += mDirection * mSpeed * (float)theGameTime.ElapsedGameTime.TotalSeconds;
            //then run method to update playerHitBox, based on info above
        }
        //draw
        public void Draw(SpriteBatch theSpriteBatch)
        {           
            theSpriteBatch.Draw(playerTexture, playerPosition, Color.White);
        }

        private void UpdateMovement(KeyboardState aCurrentKeyboardState)//updates movement. needed for positon and drawing
        {
            if (mCurrentState == State.Walking)
            {
                mSpeed = Vector2.Zero;
                mDirection = Vector2.Zero;
                if (playerPosition.X > 0) //0 is window  length. x axis
                {
                    if (aCurrentKeyboardState.IsKeyDown(Keys.Left) == true || aCurrentKeyboardState.IsKeyDown(Keys.A) == true)
                    {
                        mSpeed.X = WIZARD_SPEED;
                        mDirection.X = MOVE_LEFT;
                    }

                }

                else if (playerPosition.X == 0)
                {

                    mSpeed.X = 0;//set speed to 0.

                }


                if (playerPosition.X < 1160)//sprite is 200 wide
                {
                    if (aCurrentKeyboardState.IsKeyDown(Keys.Right) == true || aCurrentKeyboardState.IsKeyDown(Keys.D) == true)
                    {
                        mSpeed.X = WIZARD_SPEED;
                        mDirection.X = MOVE_RIGHT;
                    }
                }
                else if (playerPosition.X == 1160) //not 1280, due to sprite length of 200 pix
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
