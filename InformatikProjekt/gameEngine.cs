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
        public async static void Execute(List<Bild> bilder, int time, Canvas MyCanvas, double scale, double w, double h)
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
                Image thisImage = Imagecontrol.AddImageToGrid(MyCanvas, scale, w, h, bilder);
                await Task.Delay(time);
                Imagecontrol.removeImage(thisImage, MyCanvas);
            }
        }

        public static void startGame(DispatcherTimer gameTimer, Canvas MyCanvas)
        {
            Music.StopLoopingMusic();
            RemoveBoxes rb = new RemoveBoxes();
            rb.Remove(MyCanvas);

            List<Position> positionen = MainWindow.positionen;
            Positiongenerator.Fieldgeneration(positionen, MyCanvas);
            Music.PlayLoopingMusic();
            gameTimer.Start();
        }
    }
}
