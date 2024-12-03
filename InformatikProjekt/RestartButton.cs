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
    internal class RestartButton
    {
        public Button myButton = new Button();
        public Canvas Canvas = new Canvas();
        public DispatcherTimer timer = new DispatcherTimer();
        public void buttonCreate(Canvas MyCanvas, ref DispatcherTimer gameTimer)
        {
            Canvas = MyCanvas;
            timer = gameTimer;
            myButton = new Button
            {
                Content = "Restart",
                Width = 200,
                Height = 60,
                Background = new SolidColorBrush(Colors.IndianRed),
                FontFamily = new FontFamily("Aharoni"),
                FontWeight = FontWeights.Bold,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            Canvas.SetLeft(myButton, 500 - myButton.Width / 2);
            Canvas.SetTop(myButton, 600 - myButton.Height / 2);

            myButton.Click += MyButton_Click; // Ereignis verknüpfen

            // Button zum Layout hinzufügen
            Canvas.Children.Add(myButton);
        }

        private void MyButton_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Button wurde geklickt!");
            Canvas.Children.Remove(myButton);
            MainWindow.Punkte = 0;
            Score.ScoreUpdate(MainWindow.Punktebox, MainWindow.Punkte, Canvas);
            MainWindow.awaitedIndex = 0;
            gameEngine.startGame(timer, Canvas);
        }
    }
}
