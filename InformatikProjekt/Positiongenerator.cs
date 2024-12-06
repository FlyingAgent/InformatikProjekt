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

namespace InformatikProjekt
{
    public class Positiongenerator
    {
        public static List<Position> PositionGenerator()
        {
            int AnzahlPunkteX = 4;
            int AnzahlPunkteY = 4;
            int Punkktegesamt = AnzahlPunkteX * AnzahlPunkteY;
            List <Position> positionen = new List<Position>();

            for (int i = 0; i < AnzahlPunkteY; i++)
            {
                for (int j = 0; j < AnzahlPunkteX; j++)
                {
                    positionen.Add(new Position { x = (int)(MainWindow.w * 0.115) + i * (int)(MainWindow.w * 0.2), y = (int)(MainWindow.h * 0.115) + j * (int)(MainWindow.h * 0.2) });
                }

            }

            return positionen;
        }

        public static void Fieldgeneration(List<Position> positionen, Canvas MyCanvas)
        {
            positionen.ForEach(p => {
                Rectangle Rechteck = new Rectangle
                {
                    Width = MainWindow.w * 0.15,
                    Height = MainWindow.h * 0.15,
                    Fill = new SolidColorBrush(Colors.DarkKhaki)
                };

                string imagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "scheresmall.png");

                Rechteck.Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(imagePath, UriKind.Absolute))
                };

                Canvas.SetLeft(Rechteck, p.x);
                Canvas.SetTop(Rechteck, p.y);
                MyCanvas.Children.Add(Rechteck);
            });
        }
    }
}
