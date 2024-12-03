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
                    positionen.Add(new Position { x = 115 + i * 200, y = 115 + j * 200 });
                }

            }

            return positionen;
        }

        public static void Fieldgeneration(List<Position> positionen, Canvas MyCanvas)
        {
            positionen.ForEach(p => {
                Rectangle Rechteck = new Rectangle
                {
                    Width = 150,
                    Height = 150,
                    Fill = new SolidColorBrush(Colors.DarkKhaki)
                };

                Canvas.SetLeft(Rechteck, p.x);
                Canvas.SetTop(Rechteck, p.y);
                MyCanvas.Children.Add(Rechteck);
            });
        }
    }
}
