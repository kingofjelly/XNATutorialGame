using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
    public class GameOverScreen
    {
        private SpriteFont font;
        


        public void LoadContent(ContentManager theContentManager, string theAssetName)
        {
            font = theContentManager.Load<SpriteFont>("DefaultFont");
        }
        //update
        public void Update()
        {
            //score += amountToUpdateScoreBy;//update score by the amount given here
        }
        //draw
        public void Draw(SpriteBatch theSpriteBatch, int finalScore)
        {

            theSpriteBatch.DrawString(font, "GAME OVER\nYour Highest Score: " + finalScore, new Vector2(540, 400), Color.Black);

        }
    }
}
