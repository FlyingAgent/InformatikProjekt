using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace InformatikProjekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Button newButton = new Button();
        DispatcherTimer gameTimer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();



            gameTimer.Tick += gameEngine; // link the timer tick to the game engine event
            gameTimer.Interval = TimeSpan.FromMilliseconds(1000);
            startGame();




            //// Klick-Event hinzufügen (optional)
            //newButton.Click += NewButton_Click;


        }

        private void startGame()
        {
            // Position des Buttons festlegen
            double x = 50; // X-Koordinate
            double y = 100; // Y-Koordinate
            Canvas.SetLeft(newButton, x);
            Canvas.SetTop(newButton, y);
            newButton.Width = 100;
            newButton.Height = 50;

            // Button zum Canvas hinzufügen
            MyCanvas.Children.Add(newButton);

            gameTimer.Start();
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            //// Zufällige neue Position berechnen (z.B. innerhalb eines Bereichs)
            //Random random = new Random();
            //double newX = random.Next(0, 200); // Beispiel: zufällige X-Koordinate
            //double newY = random.Next(0, 200); // Beispiel: zufällige Y-Koordinate

            //// Setze die neuen Koordinaten für den Button
            //Canvas.SetLeft(newButton, newX);
            //Canvas.SetTop(newButton, newY);

            //// Optional: Button-Position in einer Nachricht anzeigen
            //newButton.Content = $"Position: ({newX}, {newY})";
        }

        private void gameEngine(object sender, EventArgs e)
        {
            // Zufällige neue Position berechnen (z.B. innerhalb eines Bereichs)
            Random random = new Random();
            double newX = random.Next(0, 200); // Beispiel: zufällige X-Koordinate
            double newY = random.Next(0, 200); // Beispiel: zufällige Y-Koordinate

            // Setze die neuen Koordinaten für den Button
            Canvas.SetLeft(newButton, newX);
            Canvas.SetTop(newButton, newY);

            // Optional: Button-Position in einer Nachricht anzeigen
            newButton.Content = $"Position: ({newX}, {newY})";
            Console.WriteLine("Test");

        }
    }
}