using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace XNATutorialGame
{
   

    class Sprite
    {
        //aking sprite class
        //public = acessible outside this class
        //private = editable inside class only
        public Vector2 Position = new Vector2(0, 0);//position for this class objects. Accessible externally.

        private Texture2D mSpriteTexture;//texture for this class. Can only be accessed within this class
        //now need to load + draw + update content?
        //asset name for sprite texture
        public string AssetName;
        //size of sprite with scale applied
        public Rectangle Size;
        //amount to increase/decrease size of original sprite
        private float mScale = 1.0f;

        public float Scale
        {
            get { return mScale; }
            set
            {
                mScale = value;
                //recalculate the size of the sprite with the new scale
                Size = new Rectangle(0, 0, (int)(mSpriteTexture.Width * Scale), (int)(mSpriteTexture.Height * Scale));
            }
        }


        public void LoadContent(ContentManager theContentManager, string theAssetName)
        {
            mSpriteTexture = theContentManager.Load<Texture2D>(theAssetName);
            //sprite class doesn't have built in content manager, so needs one. It also needs name of asset that will be loaded
            AssetName = theAssetName;
            Size = new Rectangle(0, 0, (int)(mSpriteTexture.Width * Scale), (int)(mSpriteTexture.Height * Scale));

        }

        //update sprite based on speed, direction and elapsed time
        public void Update(GameTime theGameTime, Vector2 theSpeed, Vector2 theDirection)
        {
            Position += theDirection * theSpeed * (float)theGameTime.ElapsedGameTime.TotalSeconds;
        }

        //draw sprites to the screen
        public void Draw(SpriteBatch theSpriteBatch)
        {
            theSpriteBatch.Draw(mSpriteTexture, Position, 
                new Rectangle(0,0, mSpriteTexture.Width, mSpriteTexture.Height),
                Color.White, 0.0f, Vector2.Zero, Scale, SpriteEffects.None, 0);
        }

       
    }
}
