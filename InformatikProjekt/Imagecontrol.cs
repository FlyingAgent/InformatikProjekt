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
            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ufo2.png"); //Suche den Pfad zu dem Bild in der Projektmappe
            bitmap.UriSource = new Uri(imagePath, UriKind.Absolute);
            bitmap.EndInit();

            // Weise die Quelle dem Image-Steuerelement zu
            imageControl.Source = bitmap;
            ScaleTransform scaleTransform = new ScaleTransform(scale, scale); //Anwenden von Skalierung
            imageControl.RenderTransform = scaleTransform;

            //Zufälliges Rechteck im Raster für das neue Objekt auswählen --> Koordianten zum Spawnen
            Random random = new Random();
            int index = random.Next(0, positions.Count);
            double newX = positions[index].x;
            double newY = positions[index].y;

            //Diese Koordinaten festlegen
            Canvas.SetLeft(imageControl, newX);
            Canvas.SetTop(imageControl, newY);

            // Füge das Image zum Grid hinzu
            MyCanvas.Children.Add(imageControl);

            //Neues Bild zur entsprechenden Liste inklusive Variablen hinzufügen
            bilder.Add(new Bild { Image = imageControl, h = (double)bitmap.PixelHeight * scale, w = (double)bitmap.PixelWidth * scale }); //(double) Konvertiert Integer in double
            return imageControl; //Gibt neu erstelltes Bild an den Punkt, an dem die Methode ausgeführt wurde zurück

        }

        //Methode zur Entfehrnung eines Bildes vom Canvas
        public static void removeImage(Image i, Canvas MyCanvas)
        {
            MyCanvas.Children.Remove(i);
        }

        //Methode um einBild erscheinen und dann wieder verschinden zu lassen
        //Asynchrone Methode mit await um den Hauptthread nicht durch durch Wartezeit zu pausieren, damit andere Aktionen immer noch vom Programm ausgeführt werden können
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
