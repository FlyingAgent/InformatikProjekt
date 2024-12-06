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
        public async static void Execute(List<Bild> bilder, int time, Canvas MyCanvas, double scale, double w, double h, int score)
        {
            bool allPicturesClicked = true;
            bilder.ForEach(b =>
            {
                if (b.gotClicked == false)
                {
                    allPicturesClicked = false;
                }
            });

            if (allPicturesClicked == true)
            {
                //Bild spawnen
                bilder.ForEach(b =>
                {
                    b.gotClicked = false;
                });

                //Image thisImage = AddImageToGrid();

                //Entfehrnen aller aktuell noch angezeigten Ufos
                foreach (var item in bilder)
                {
                    Imagecontrol.removeImage(item.Image, MyCanvas);
                }

                Image thisImage = Imagecontrol.AddImageToGrid(MyCanvas, scale, w, h, bilder);
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
                await Task.Delay((int)duration);
                Imagecontrol.removeImage(thisImage, MyCanvas);
            }
        }

        public static void startGame(DispatcherTimer gameTimer, Canvas MyCanvas)
        {
            Music.StopLoopingMusic();
            RemoveBoxes rb = new RemoveBoxes();
            rb.Remove(MyCanvas);
            //Zurücksetzen der Punktzahl bei mehreren Runden hintereinander
            List<Position> positionen = MainWindow.positionen;
            Positiongenerator.Fieldgeneration(positionen, MyCanvas);
            Music.PlayLoopingMusic();
            gameTimer.Start();
        }
    }
}
