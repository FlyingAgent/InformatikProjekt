using System;
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
    //Klasse die für Musik genutzt wird
    internal class Music
    {
        static MediaPlayer player = new MediaPlayer(); //Mediaplayer zum Abspielen der Hintergrundmusik
        public static void PlayLoopingMusic()
        {
            string musicPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "guitar-electro-sport-trailer-115571.wav"); //Pfad der Musikdatei in der Projektmappe finden
            player.Open(new Uri(musicPath, UriKind.Relative)); //Mediaplayer mit der Musikdatei laden
            player.MediaEnded += (s, e) => player.Position = TimeSpan.Zero; //Wiederholung des Liedes
            player.Play(); //Start des MediaPlayer
            player.Volume = 0.035; //Laustärke

        }

        //Methode um den Player zu stoppen
        public static void StopLoopingMusic()
        {
            player.Stop();
        }

        //Methode für SoundEffekte, die nicht mit dem Hintergrundtrack interferiert
        public void playSound(string sound)
        {
            //Soundplayer wird mit übergebenen Pfad erstellt, geladen und gestartet
            SoundPlayer splayer = new SoundPlayer(sound);
            splayer.Load(); // Optional: Lädt die Datei vorab für kürzere Wartezeiten
            splayer.Play(); // Startet den Sound (asynchron)
        }
    }
}
