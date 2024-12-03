using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace InformatikProjekt
{
    public class Boxerstellung()
    {
        public static void Punkteboxerstellung(ref TextBox Punktebox, Canvas MyCanvas, int Punkte, double w)
        {
            Punktebox = new TextBox
            {
                Width = 200,
                Height = 30,
                Text = $"Punkte: {Punkte}",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                IsEnabled = false
            };
            Punktebox.Background = new SolidColorBrush(Colors.LightBlue);
            Canvas.SetLeft(Punktebox, w / 2 - 200);
            MyCanvas.Children.Add(Punktebox);
        }

        public static void Highscoreboxerstellung(ref TextBox Highscorebox, Canvas MyCanvas, int Punkte, double w)
        {
            Highscorebox = new TextBox
            {
                Width = 200,
                Height = 30,
                Text = $"Highsore: {Punkte}",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                IsEnabled = false
            };
            Highscorebox.Background = new SolidColorBrush(Colors.LightBlue);
            Canvas.SetLeft(Highscorebox, w / 2);
            MyCanvas.Children.Add(Highscorebox);
        }

        public static void gameOverBox(Canvas myCanvas)
        {
            TextBox box = new TextBox
            {
                Width = 400,
                Height = 150,
                Text = "Game over du Huen",
                IsEnabled = false,
                FontSize = 20,
                TextAlignment = TextAlignment.Center,
                VerticalContentAlignment= VerticalAlignment.Center,
                Background = new SolidColorBrush(Colors.IndianRed),
                FontFamily = new FontFamily("Aharoni"),
                FontWeight = FontWeights.Bold
            };
            Canvas.SetLeft(box, 500 - box.Width/2);
            Canvas.SetTop(box, 400 - box.Height/2);
            myCanvas.Children.Add(box);
        }
    }
}
