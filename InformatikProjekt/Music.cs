﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.IO;
//using System.Windows.Shapes;

namespace InformatikProjekt
{
    internal class Music
    {
        static MediaPlayer player = new MediaPlayer();
        public static void PlayLoopingMusic()
        {
            string musicPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "guitar-electro-sport-trailer-115571.wav");
            player.Open(new Uri(musicPath, UriKind.Relative));
            player.MediaEnded += (s, e) => player.Position = TimeSpan.Zero; // Wiederholung
            player.Play();
        }

        public static void StopLoopingMusic()
        {
            player.Stop();
        }
    }
}