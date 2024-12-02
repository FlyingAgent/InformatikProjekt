using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using System.Windows.Threading;

namespace InformatikProjekt
{
    class GetMouseClick
    {
        public static void Mausklick(Canvas MyCanvas, MouseButtonEventArgs e, List<Bild> bilder, ref int awaitedIndex, DispatcherTimer gameTimer)
        {
            // Get the position of the mouse click relative to the Canvas
            Point clickPosition = e.GetPosition(MyCanvas);

            Image img = bilder[awaitedIndex].Image;
            double x = Canvas.GetLeft(img);
            double y = Canvas.GetTop(img);
            Rect imageBounds = new Rect(x, y, img.Width, img.Height);


            if ((clickPosition.X > imageBounds.X && clickPosition.X < imageBounds.X + bilder[awaitedIndex].w) && (clickPosition.Y > imageBounds.Y && clickPosition.Y < imageBounds.Y + bilder[awaitedIndex].h))
            {
                Imagecontrol.spawnAndDespawn(img, MyCanvas);

                Debug.WriteLine("Yapp");
                bilder[awaitedIndex].gotClicked = true;
                if (awaitedIndex + 1 < bilder.Count)
                {
                    awaitedIndex++;
                }
                else
                {
                    awaitedIndex = 0;
                }
            }
            else
            {
                MessageBox.Show("Nö du huen");

                //Entfehrnene aller Bilder von dem Canvas
                bilder.ForEach(bild => {
                    MyCanvas.Children.Remove(bild.Image);
                });
                gameTimer.Stop();
            }
        }
    }
}
