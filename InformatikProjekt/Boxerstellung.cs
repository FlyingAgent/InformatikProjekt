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
        //Erstellung einer Textbox, in der die Punkte Dynamisch während des Spiels eingefügt werden
        public static void Punkteboxerstellung(ref TextBox Punktebox, Canvas MyCanvas, int Punkte, double w)
        {
            Punktebox = new TextBox
            {
                //Größe der Box wird festgelegt -> Box passt sich der Spielgröße an und wird mit den "Punkten" gefüllt
                Width = MainWindow.w * 0.2,
                Height = MainWindow.h * 0.03,
                Text = $"Punkte: {Punkte}",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                //Punktänderung durch den Spieler ist nicht möglich (er kann nicht selber in die Box seine gewünschte Punktzahl schreiben)
                IsEnabled = false,
                //Schriftart und -größe wird festgelegt
                FontFamily = new FontFamily("Aharoni"),
                FontSize = 20,
            };
            //Farbe und Position wird festgelegt und Box zum Programm hinzugefügt
            Punktebox.Background = new SolidColorBrush(Colors.LightBlue);
            Canvas.SetLeft(Punktebox, w / 2 - MainWindow.w * 0.2);
            MyCanvas.Children.Add(Punktebox);
        }

        //Érstellung einer Textbox, die den Highscore während des Spiels zeigt und nach dem Beenden jeder Runde Sktualisiert wird
        public static void Highscoreboxerstellung(ref TextBox Highscorebox, Canvas MyCanvas, int Punkte, double w)
        {
            Highscorebox = new TextBox
            {
                //Größe der Box wird festgelegt -> Box passt sich der Spielgröße an und wird mit den "Punkten" gefüllt
                Width = MainWindow.w * 0.2,
                Height = MainWindow.h * 0.03,
                Text = $"Highsore: {Punkte}",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                //Punktänderung durch den Spieler ist nicht möglich (er kann nicht selber in die Box seinen gewünschten Highscore schreiben)
                IsEnabled = false,
                //Schriftart und -größe wird festgelegt
                FontFamily = new FontFamily("Aharoni"),
                FontSize = 20,
            };
            //Farbe und Position wird festgelegt und Box zum Programm hinzugefügt
            Highscorebox.Background = new SolidColorBrush(Colors.LightBlue);
            Canvas.SetLeft(Highscorebox, w / 2);
            MyCanvas.Children.Add(Highscorebox);
        }

        // Text box die erscheint, wenn man das Level nicht mehr schafft
        public static void gameOverBox(Canvas myCanvas, int Punkte)
        {
            TextBox box = new TextBox
            {
                //Größe der Box wird festgelegt -> Box passt sich der Spielgröße an und wird mit Text + den erziehltn "Punkten" gefüllt
                Width = MainWindow.w * 0.4,
                Height = MainWindow.h * 0.15,
                //Box wird mit Text und den erreichten Punkten gefüllt
                Text = $"Versuche es noch mal! \nErziehlter score: {Punkte}",
                //spieler kann nicht die Box beschreiben
                IsEnabled = false,
                TextAlignment = TextAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                //Farbe der Box wird festgelegt
                Background = new SolidColorBrush(Colors.IndianRed),
                //Schriftart und -größe wird festgelegt + schrift ist dick gedruckt
                FontFamily = new FontFamily("Aharoni"),
                FontWeight = FontWeights.Bold,
                FontSize = 25,
                Tag = "over"
            };
            //Position wird festgelegt und zum Programm hinzugefügt
            Canvas.SetLeft(box, MainWindow.w * 0.5 - box.Width / 2);
            Canvas.SetTop(box, MainWindow.h * 0.4 - box.Height / 2);
            myCanvas.Children.Add(box);
        }
    }
}
