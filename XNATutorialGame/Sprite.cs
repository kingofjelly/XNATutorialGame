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

        public Vector2 Position = new Vector2(0, 0);//position for this class objects. Accessible externally.

        private Texture2D mSpriteTexture;//texture for this class. Can only be accessed within this class
        //now need to load + draw + update content?

        public void LoadContent(ContentManager theContentManager, string theAssetName)
        {
            mSpriteTexture = theContentManager.Load<Texture2D>(theAssetName);
            //sprite class doesn't have built in content manager, so needs one. It also needs name of asset that will be loaded
        }

        //draw sprites to the screen

        public void Draw(SpriteBatch theSpriteBatch)
        {
            theSpriteBatch.Draw(mSpriteTexture, Position, Color.White);
        }

    }
}
