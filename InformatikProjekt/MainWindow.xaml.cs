using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;


namespace InformatikProjekt
{   
    public partial class MainWindow
    {
        DispatcherTimer gameTimer = new DispatcherTimer();
        public List<Bild> bilder = new List<Bild>();

        public double w = 1000;
        public double h = 1000;
        public int time = 1000;
        public double scale = 0.3;
        public TextBox Punktebox;
        public TextBox Highscorebox;
        public int Punkte = 0;
        public int awaitedIndex = 0;

        public MainWindow()
        {
            InitializeComponent();

            gameTimer.Tick += gameEngine; // link the timer tick to the game engine event
            gameTimer.Interval = TimeSpan.FromMilliseconds(time + 16.66);
            InformatikProjekt.gameEngine.startGame(gameTimer);

            this.Background = new SolidColorBrush(Colors.LightSlateGray);
            this.Width = w;
            this.Height = h;

            Boxerstellung.Punkteboxerstellung(Punktebox, MyCanvas, Punkte, w);
            Boxerstellung.Highscoreboxerstellung(Highscorebox, MyCanvas, Punkte, w);
        }

        private async void gameEngine(object sender, EventArgs e)
        {
            InformatikProjekt.gameEngine.Execute(bilder, time, MyCanvas, scale, w, h);
        }

        
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GetMouseClick.Mausklick(MyCanvas, e, bilder, ref awaitedIndex, gameTimer);
        }
    }

}