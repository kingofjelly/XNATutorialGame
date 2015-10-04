using System;
using System.Collections.Generic;
using System.Linq;
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
    public class GameMusicSounds
    {
        protected Song song;
        //load
        public void LoadContent(ContentManager theContent, string theAssetName)
        {
            song = theContent.Load<Song>("Chiptune_Artic_Odyssey");
            MediaPlayer.Play(song);
            //MediaPlayer.IsRepeating = true;
        }
    }
}
