﻿using System;
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
    public class PlayerScore
    {
        //class for player score

        private SpriteFont font;
        public int score = 0;
        public int scoreToDock = 100;
        public int highScore = 0;
        

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
        public void Draw(SpriteBatch theSpriteBatch)
        {

            theSpriteBatch.DrawString(font, "Score: " + score, new Vector2(1100, 100), Color.Black);
            
        }

    }

  
}
