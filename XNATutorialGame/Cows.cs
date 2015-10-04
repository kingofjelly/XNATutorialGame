using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace XNATutorialGame
{
    public class Cows
    {
        //vector for position
        //texture 2d for texture
        //speed?

        //91 x 91 for height x width

        public Vector2 cowPosition = new Vector2(540, 0);//position of cow
        private Texture2D cowSpriteTexture;//cow texture
        string cowAssetName;
        Rectangle cowHitbox; //hitbox for my cow              
        


        //used for updating object falling down
        public Vector2 mDirection = Vector2.Zero;
        public Vector2 mSpeed = Vector2.Zero;
        //testing float
        public float Speed = 10;

        //variables for controlling descent and ascent
        const int COW_SPEED = 160;
        public int MOVEMENT = MOVE_DOWN;//initializaes it as descending
        const int MOVE_UP = -1;
        const int MOVE_DOWN = 1;
        private int reverseTimer;
        //this is a special integer I'm creating. When intersect happens, this is triggerd and counts down with each update. When it hits 0, direction flips again
        //and then the sprite descends again

        public Rectangle cowBoundary;

        //load
        public void LoadContent(ContentManager theContentManager, string theAssetName)
        {
            cowSpriteTexture = theContentManager.Load<Texture2D>(theAssetName);
            //sprite class doesn't have built in content manager, so needs one. It also needs name of asset that will be loaded
            //cowAssetName = theAssetName;
            //cowHitbox = new Rectangle(0, 0, (int)(cowTexture.Width), (int)(cowTexture.Height));
        }
        //update
        //public void Update(GameTime theGameTime, Vector2 theSpeed, Vector2 theDirection)
        public void Update(GameTime theGameTime)
        {
            //calculation means : Cow position = cow position + sum of the following
            //cowPosition += theDirection * theSpeed * (float)theGameTime.ElapsedGameTime.TotalSeconds;
            UpdateMovement();//makes it just fall down screen
            //cowPosition += mDirection * mSpeed * (float)theGameTime.ElapsedGameTime.TotalSeconds;
            cowPosition += mDirection * mSpeed * (float)theGameTime.ElapsedGameTime.TotalSeconds;
            cowBoundary = new Rectangle((int)cowPosition.X, (int)cowPosition.Y, 91, 91);
            

        }
        //draw
        public void Draw(SpriteBatch theSpriteBatch)
        {            
            theSpriteBatch.Draw(cowSpriteTexture, cowPosition, Color.White);
        }

        private void UpdateMovement()//updates movement. needed for positon and drawing
        {
            //simply pushes sprite down
            mSpeed = Vector2.Zero;
            mDirection = Vector2.Zero;
            //here, opposed to if key is pressed, update movemnt every sec
            mSpeed.Y = COW_SPEED;
            mDirection.Y = MOVEMENT; //this will decrease by 1 for each iteration


        }

        private void BounceOffWalls()
        {
            //another cow class method I'm making, which means if it strikes the bottom or top, it reverses
        }


    }
}
