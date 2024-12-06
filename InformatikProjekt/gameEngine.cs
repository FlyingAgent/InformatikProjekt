using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace InformatikProjekt
{

    class gameEngine
    {
        //Methode die als GameEngine ausgeführt wird
        public async static void Execute(List<Bild> bilder, int time, Canvas MyCanvas, double scale, double w, double h, int score)
        {
            //Überprüfen, ob alle Bilder angeklickt wurden
            bool allPicturesClicked = true;
            bilder.ForEach(b =>
            {
                if (b.gotClicked == false)
                {
                    allPicturesClicked = false;
                }
            });

            //Wenn ja, dann...
            if (allPicturesClicked == true)
            {
                //geklickt Status alle Bilder zurücksetzen
                bilder.ForEach(b =>
                {
                    b.gotClicked = false;
                });


                //Entfehrnen aller aktuell noch angezeigten Ufos
                foreach (var item in bilder)
                {
                    Imagecontrol.removeImage(item.Image, MyCanvas);
                }

                //Neues Bild mithilfe von Methode erstellen
                Image thisImage = Imagecontrol.AddImageToGrid(MyCanvas, scale, w, h, bilder);

                //Je nach Schwierigkeitsgrad und Punktzahl die Anzeigedauer dieses Bildes bestimmen
                int diffFactor = 0;
                if(MainWindow.difficulty == "brainrot")
                {
                    diffFactor = 1;
                } else if (MainWindow.difficulty == "intermediate")
                {
                    diffFactor = 3;

                } else if (MainWindow.difficulty == "brainwarrior")
                {
                    diffFactor = 8;
                }
                double duration = time - score * diffFactor * 40;
                if (duration < 0) duration = 50;
                await Task.Delay((int)duration); //Asynchroner Delay um den Mainthread nicht zu behindern
                Imagecontrol.removeImage(thisImage, MyCanvas); //Bild wieder verdecken (vom Canvas entfernen)
            }
        }

        //Methode zum Start des Spiels
        public static void startGame(DispatcherTimer gameTimer, Canvas MyCanvas)
        {
            //Stop der Hintergrundmusik
            Music.StopLoopingMusic();
            //Nicht benötigte Boxen entfernen, um Spiel sauber zu gestalten
            RemoveBoxes rb = new RemoveBoxes();
            rb.Remove(MyCanvas);
            //Neugenerierung des Rasters
            List<Position> positionen = MainWindow.positionen;
            Positiongenerator.Fieldgeneration(positionen, MyCanvas);
            Music.PlayLoopingMusic(); //Start der Hintergrundmusik
            gameTimer.Start(); //Start des gameTimers und somit Start der gameEngine
        }
    }
}
