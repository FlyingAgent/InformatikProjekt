using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace InformatikProjekt
{
    //Handling des Restart Buttons
    internal class RestartButton
    {
        //Methodenübergreifende Variablen, auf die die "MyButton_Click"-Methode zugreifen soll
        public Button myButton = new Button();
        public Canvas Canvas = new Canvas();
        public DispatcherTimer timer = new DispatcherTimer();
        
        //Methode zur Erstellung des Buttons
        public void buttonCreate(Canvas MyCanvas, ref DispatcherTimer gameTimer)
        {
            //Belegung der oben genannten Variablen mit den benötigten Werten
            Canvas = MyCanvas;
            timer = gameTimer;
            //Button-Erstellung mit Text, Größe, Hintergrund, Font, Formatierung des Textes und Zentrierung des Textes
            myButton = new Button
            {
                Content = "Restart",
                Width = MainWindow.w * 0.2,
                Height = MainWindow.h * 0.06,
                Background = new SolidColorBrush(Colors.IndianRed),
                FontFamily = new FontFamily("Aharoni"),
                FontWeight = FontWeights.Bold,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            //Festlegen der Koordinaten des Buttons (Softcoded)
            Canvas.SetLeft(myButton, MainWindow.w * 0.5 - myButton.Width / 2);
            Canvas.SetTop(myButton, MainWindow.h * 0.6 - myButton.Height / 2);

            //Verlinkung des Buttons mit dem MyButton_Click Event, sodass dieses bei denem Klick ausgeführt wird
            myButton.Click += MyButton_Click; // Ereignis verknüpfen

            // Button zum Layout hinzufügen
            Canvas.Children.Add(myButton);
        }

        private void MyButton_Click(object sender, RoutedEventArgs e)
        {
            //Button entfehrnen
            Canvas.Children.Remove(myButton);
            MainWindow.Punkte = 0; //Punkte zurücksetzen
            Score.ScoreUpdate(MainWindow.Punktebox, MainWindow.Punkte, Canvas); //Updaten der ScoreBox
            MainWindow.awaitedIndex = 0; //Zurücksetzen der Variable, damit die Algorithmen bei einem Restart wie gedacht ausgeführt werden können
            gameEngine.startGame(timer, Canvas); //Start des Spiels
        }
    }
}
