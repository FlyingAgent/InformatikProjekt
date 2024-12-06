using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;
using static System.Formats.Asn1.AsnWriter;

namespace InformatikProjekt
{
    public class Positiongenerator
    {
        //Es werden nun die Positionen in einer Liste festgelegt, auf denen die Bilder erscheinen sollen
        //Methode, die eine Liste mit dem Datentyp der Positionen Klassen zurückgibt
        public static List<Position> PositionGenerator()
        {
            //Anzahl der verschiedenen Positionen in x und y Richtung
            int AnzahlPunkteX = 4;
            int AnzahlPunkteY = 4;
            List <Position> positionen = new List<Position>();

            //verschachtelte for-Schleife für das 4x4 Feld
            for (int i = 0; i < AnzahlPunkteY; i++)
            {
                for (int j = 0; j < AnzahlPunkteX; j++)
                {
                    //Die Positionen passen sich automatisch an die Größe des Spiels an
                    positionen.Add(new Position { x = (int)(MainWindow.w * 0.115) + i * (int)(MainWindow.w * 0.2), y = (int)(MainWindow.h * 0.115) + j * (int)(MainWindow.h * 0.2) });
                }

            }

            return positionen; //Rückgabe der neu erstellten Liste <-- Diese Methode ist vom Typ List<Position> und muss deshalb diesen Typ auch returnen
        }

        public static void Fieldgeneration(List<Position> positionen, Canvas MyCanvas)
        {
            //Aufrufen der Positionen aus der Liste zum spawnen der Punkte
            positionen.ForEach(p => {
                Rectangle Rechteck = new Rectangle
                {
                    Width = MainWindow.w * 0.15,
                    Height = MainWindow.h * 0.15,
                    Fill = new SolidColorBrush(Colors.DarkKhaki)
                };

                //Suche des Bildes in der Projektmappe, sodass es auch gefunden werden kann, wenn das Projekt geklont wird und keinen direkten Dateipfadverweis besitzt
                string imagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "mond.png");

                //Füllen des Rechtecks mit dem Bild

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(imagePath, UriKind.Absolute);
                bitmap.EndInit();


                ImageBrush imageBrush = new ImageBrush
                {
                    ImageSource = bitmap //Festlegen des Bildes in imageBrush
                };

                Rechteck.Fill = imageBrush; //Anwenden des Bildes auf das Rechteck

                //Koordinaten des neuen Rechtecks aus der Liste
                Canvas.SetLeft(Rechteck, p.x);
                Canvas.SetTop(Rechteck, p.y);
                MyCanvas.Children.Add(Rechteck); //Hinzufügen des Rechtecks auf den Canvas
            });
        }
    }
}
