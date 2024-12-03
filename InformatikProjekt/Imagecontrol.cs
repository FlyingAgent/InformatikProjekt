using System;
using System.IO;
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
        public static List<Position> positions = InformatikProjekt.MainWindow.positionen;
        public static Image AddImageToGrid(Canvas MyCanvas, double scale, double w, double h, List<Bild> bilder)
        {
            // Erstelle ein Image-Steuerelement
            Image imageControl = new Image();


            // Erstelle eine BitmapImage-Quelle
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "scheresmall.PNG");
            bitmap.UriSource = new Uri(imagePath, UriKind.Absolute); // Absoluter oder relativer Pfad
            bitmap.EndInit();

            // Weise die Quelle dem Image-Steuerelement zu
            imageControl.Source = bitmap;
            ScaleTransform scaleTransform = new ScaleTransform(scale, scale);
            imageControl.RenderTransform = scaleTransform;

            Random random = new Random();

            int index = random.Next(0, positions.Count);
            double newX = positions[index].x;
            double newY = positions[index].y;


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
            if (!MyCanvas.Children.Contains(img))
            {
                MyCanvas.Children.Add(img);
                await Task.Delay(1000);
                MyCanvas.Children.Remove(img);
            }
        }

    }
}
