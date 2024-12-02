using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace InformatikProjekt
{
    class Imagecontrol
    {
        public static Image AddImageToGrid(Canvas MyCanvas, double scale, double w, double h, List<Bild> bilder)
        {
            // Erstelle ein Image-Steuerelement
            Image imageControl = new Image();


            // Erstelle eine BitmapImage-Quelle
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("C:/Users/joost/Downloads/IMG-20231002-WA0005.jpg", UriKind.Absolute); // Absoluter oder relativer Pfad
            bitmap.EndInit();

            // Weise die Quelle dem Image-Steuerelement zu
            imageControl.Source = bitmap;
            ScaleTransform scaleTransform = new ScaleTransform(scale, scale);
            imageControl.RenderTransform = scaleTransform;

            Random random = new Random();
            double newX = random.Next(0, (int)(w - (bitmap.PixelWidth * scale))); // Beispiel: zufällige X-Koordinate
            double newY = random.Next(0, (int)(h - (bitmap.PixelHeight * scale))); // Beispiel: zufällige Y-Koordinate

            Canvas.SetLeft(imageControl, newX);
            Canvas.SetTop(imageControl, newY);

            // Füge das Image zum Grid hinzu
            MyCanvas.Children.Add(imageControl);

            bilder.Add(new Bild { Image = imageControl, h = (double)bitmap.PixelHeight * scale, w = (double)bitmap.PixelWidth * scale });
            return imageControl;

        }

        public static void removeImage(Image i, Canvas MyCanvas)
        {
            MyCanvas.Children.Remove(i);
        }

        public static async void spawnAndDespawn(Image img, Canvas MyCanvas)
        {
            MyCanvas.Children.Add(img);
            await Task.Delay(1000);
            MyCanvas.Children.Remove(img);
        }
    }
}
