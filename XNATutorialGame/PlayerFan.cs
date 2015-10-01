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
    class PlayerFan
    {
        //this is the class, for the object which the player will be controlling
        //vector for position
        //texture 2d for texture
        //speed?
        Vector2 playerPosition = new Vector2(540, 540);//position of player    X, Y
        Texture2D playerTexture;//cow texture
        string playerAssetName;
        Rectangle playerHitbox; //hitbox for my cow

        
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

        //load
        public void LoadContent(ContentManager theContentManager, string theAssetName)
        {
            playerTexture = theContentManager.Load<Texture2D>(theAssetName);
            //sprite class doesn't have built in content manager, so needs one. It also needs name of asset that will be loaded
            //playerAssetName = theAssetName;
            //playerHitbox = new Rectangle(0, 0, (int)(playerTexture.Width), (int)(playerTexture.Height));
        }
        //update
        public void Update(GameTime theGameTime, Vector2 theSpeed, Vector2 theDirection)
        {
            //calculation means : Cow position = cow position + sum of the following
            playerPosition += theDirection * theSpeed * (float)theGameTime.ElapsedGameTime.TotalSeconds;
            //then run method to update playerHitBox, based on info above
        }
        //draw
        public void Draw(SpriteBatch theSpriteBatch)
        {           
            theSpriteBatch.Draw(playerTexture, playerPosition, Color.White);
        }
    }
}
