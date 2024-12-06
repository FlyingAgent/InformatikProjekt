using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using System.Windows;

namespace InformatikProjekt
{
    internal class StartButton
    {
        //Initialisierung des Buttons
        public Button myButton = new Button();
        //Initialisierung von leerem Canvas, damit dieser bei der Klickmethode aufgerufen werden kann
        public Canvas Canvas = new Canvas();  
        public DispatcherTimer gameTimer = new DispatcherTimer();
        public void buttonCreate(Canvas MyCanvas, DispatcherTimer timer)
        {
            //Festlegung des Canvas
            Canvas = MyCanvas;
            gameTimer = timer;
            //Bestimmung des Buttons
            myButton = new Button
            {
                //Text
                Content = "Start",
                //Breite und Höhe
                Width = 250,
                Height = 100,
                //Hintergrundfarbe
                Background = new SolidColorBrush(Colors.LightGreen),
                //Font
                FontFamily = new FontFamily("Aharoni"),
                FontWeight = FontWeights.Bold,
                //Zentrierung des Textes
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            
            //Setzen der Postition des Buttons auf dem Canvas
            Canvas.SetLeft(myButton, 500 - myButton.Width / 2);
            Canvas.SetTop(myButton, 500 - myButton.Height / 2);

            //Verlinkung zwischen der Methode StartButton_Click und dem Button, sodass es aufgerufen wird, wenn der Button
            //geklickt wird
            myButton.Click += StartButton_Click; // Ereignis verknüpfen

            // Button zum Layout hinzufügen
            MyCanvas.Children.Add(myButton);
        }

        //Methode, die beim Anklicken aufgerufen wird
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            //Erstellen der Buttons zur Festlegung der Schwierigkeit
            DificultyBrainrot dificultyBrainrot = new DificultyBrainrot();
            dificultyBrainrot.buttonCreate(Canvas, gameTimer);

            Dificultyintermediate difficultyIntermediate = new Dificultyintermediate();
            difficultyIntermediate.buttonCreate(Canvas, gameTimer);

            DificultyBrainwarrior dificultyBrainwarrier = new DificultyBrainwarrior();
            dificultyBrainwarrier.buttonCreate(Canvas, gameTimer);

            //Entfehrenen des Buttons vom Canvas
            Canvas.Children.Remove(myButton);
        }
    }
}
