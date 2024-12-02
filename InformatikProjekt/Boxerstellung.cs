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
        public static void Punkteboxerstellung(TextBox Punktebox, Canvas MyCanvas, int Punkte, double w)
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

        public static void Highscoreboxerstellung(TextBox Highscorebox, Canvas MyCanvas, int Punkte, double w)
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
    }
}
