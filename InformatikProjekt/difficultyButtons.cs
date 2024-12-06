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
    internal class DificultyBrainrot
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
                Content = "Brainrot",
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
            Canvas.SetLeft(myButton, MainWindow.w / 3 * 1 - (myButton.Width + 50));
            Canvas.SetTop(myButton, 500 - myButton.Height / 3);

            //Verlinkung zwischen der Methode buttonClick und dem Button, sodass es aufgerufen wird, wenn der Button
            //geklickt wird
            myButton.Click += buttonClick; // Ereignis verknüpfen

            // Button zum Layout hinzufügen
            MyCanvas.Children.Add(myButton);
        }

        //Methode, die beim Anklicken aufgerufen wird
        private void buttonClick(object sender, RoutedEventArgs e)
        {
            //Starten des Games
            InformatikProjekt.gameEngine.startGame(gameTimer, Canvas);

            //Jeden Button auf dem Canvas in eine Liste eintragen
            var filteredButtons = Canvas.Children.OfType<Button>();
            List<Button> buttons = new List<Button>();
            foreach (var button in filteredButtons)
            {
                if (Canvas.Children.Contains(button)) //Überprüfen ob Element auf dem Canvas ist
                {
                    buttons.Add(button);
                }
            }

            //Jeden Button entfernen
            buttons.ForEach(b =>
            {
                Canvas.Children.Remove(b); //Button entfernen
            });
            //Setzen des Schwierigkeitsgrads
            MainWindow.difficulty = "brainrot";
        }
    }
    internal class Dificultyintermediate
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
                Content = "Intermediate",
                //Breite und Höhe
                Width = 250,
                Height = 100,
                //Hintergrundfarbe
                Background = new SolidColorBrush(Colors.Orange),
                //Font
                FontFamily = new FontFamily("Aharoni"),
                FontWeight = FontWeights.Bold,
                //Zentrierung des Textes
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            //Setzen der Postition des Buttons auf dem Canvas
            Canvas.SetLeft(myButton, MainWindow.w / 3 * 2 - (myButton.Width + 50));
            Canvas.SetTop(myButton, 500 - myButton.Height / 3);

            //Verlinkung zwischen der Methode buttonClick und dem Button, sodass es aufgerufen wird, wenn der Button
            //geklickt wird
            myButton.Click += buttonClick; // Ereignis verknüpfen

            // Button zum Layout hinzufügen
            MyCanvas.Children.Add(myButton);
        }

        //Methode, die beim Anklicken aufgerufen wird
        private void buttonClick(object sender, RoutedEventArgs e)
        {
            //Starten des Games
            InformatikProjekt.gameEngine.startGame(gameTimer, Canvas);

            //Jeden Button auf dem Canvas in eine Liste eintragen
            var filteredButtons = Canvas.Children.OfType<Button>();
            List<Button> buttons = new List<Button>();
            foreach (var button in filteredButtons)
            {
                if (Canvas.Children.Contains(button)) //Überprüfen ob Element auf dem Canvas ist
                {
                    buttons.Add(button);
                }
            }

            //Jeden Button entfernen
            buttons.ForEach(b =>
            {
                Canvas.Children.Remove(b); //Button entfernen
            });
            //Setzen des Schwierigkeitsgrads
            MainWindow.difficulty = "brainwarrior";
        }
    }

    internal class DificultyBrainwarrior
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
                Content = "Brainwarrior",
                //Breite und Höhe
                Width = 250,
                Height = 100,
                //Hintergrundfarbe
                Background = new SolidColorBrush(Colors.Red),
                //Font
                FontFamily = new FontFamily("Aharoni"),
                FontWeight = FontWeights.Bold,
                //Zentrierung des Textes
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            //Setzen der Postition des Buttons auf dem Canvas
            Canvas.SetLeft(myButton, MainWindow.w / 3 * 3 - (myButton.Width + 50));
            Canvas.SetTop(myButton, 500 - myButton.Height / 3);

            //Verlinkung zwischen der Methode buttonClick und dem Button, sodass es aufgerufen wird, wenn der Button
            //geklickt wird
            myButton.Click += buttonClick; // Ereignis verknüpfen

            // Button zum Layout hinzufügen
            MyCanvas.Children.Add(myButton);
        }

        //Methode, die beim Anklicken aufgerufen wird
        private void buttonClick(object sender, RoutedEventArgs e)
        {
            //Starten des Games
            InformatikProjekt.gameEngine.startGame(gameTimer, Canvas);

            //Jeden Button auf dem Canvas in eine Liste eintragen
            var filteredButtons = Canvas.Children.OfType<Button>();
            List<Button> buttons = new List<Button>();
            foreach (var button in filteredButtons)
            {
                if (Canvas.Children.Contains(button)) //Überprüfen ob Element auf dem Canvas ist
                {
                    buttons.Add(button);
                }
            }

            //Jeden Button entfernen
            buttons.ForEach(b =>
            {
                Canvas.Children.Remove(b); //Button entfernen
            });
            //Setzen des Schwierigkeitsgrads
            MainWindow.difficulty = "brainwarrior";
        }
    }
    
}
