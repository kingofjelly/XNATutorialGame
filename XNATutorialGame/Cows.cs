using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace XNATutorialGame
{
    class Cows
    {
        //vector for position
        //texture 2d for texture
        //speed?
        public Vector2 cowPosition = new Vector2(0, 0);//position of cow
        private Texture2D cowSpriteTexture;//cow texture
        string cowAssetName;
        Rectangle cowHitbox; //hitbox for my cow              

        

        //load
        public void LoadContent(ContentManager theContentManager, string theAssetName)
        {
            cowSpriteTexture = theContentManager.Load<Texture2D>(theAssetName);
            //sprite class doesn't have built in content manager, so needs one. It also needs name of asset that will be loaded
            //cowAssetName = theAssetName;
            //cowHitbox = new Rectangle(0, 0, (int)(cowTexture.Width), (int)(cowTexture.Height));
        }
        //update
        public void Update(GameTime theGameTime, Vector2 theSpeed, Vector2 theDirection)
        {
            //calculation means : Cow position = cow position + sum of the following
            cowPosition += theDirection * theSpeed * (float)theGameTime.ElapsedGameTime.TotalSeconds;
            UpdateMovement();//makes it just fall down screen

        }
        //draw
        public void Draw(SpriteBatch theSpriteBatch)
        {
            //theSpriteBatch.Draw(cowTexture, cowPosition,
            //    new Rectangle(0, 0, cowTexture.Width, cowTexture.Height),
            //    Color.White, 0.0f, Vector2.Zero, 0, SpriteEffects.None, 0);
            theSpriteBatch.Draw(cowSpriteTexture, cowPosition, Color.White);
        }

        private void UpdateMovement()//updates movement. needed for positon and drawing
        {
            ////simply pushes sprite down
            //mSpeed = Vector2.Zero;
            //mDirection = Vector2.Zero;
            ////here, opposed to if key is pressed, update movemnt every sec
            //mSpeed.Y = WIZARD_SPEED;
            //mDirection.Y = MOVE_DOWN; //this will decrease by 1 for each iteration


        }
    }
}
