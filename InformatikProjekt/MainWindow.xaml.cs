using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;


namespace InformatikProjekt
{   
    public partial class MainWindow
    {
        //Schwierigkeit: Brainrot/Intermediate/Brainwarrior
        public static string difficulty = "brainrot";
        DispatcherTimer gameTimer = new DispatcherTimer();
        public List<Bild> bilder = new List<Bild>();
        public static List<Position> positionen = new List<Position>();

        public double w = 1000;
        public double h = 1000;
        public int time = 1000;
        public double scale = 1;
        public static TextBox Punktebox;
        public TextBox Highscorebox;
        public static int Punkte = 0;
        public int Highscore = 0;
        public static int awaitedIndex = 0;

        public MainWindow()
        {
            InitializeComponent();
            positionen = Positiongenerator.PositionGenerator();
            gameTimer.Tick += gameEngine; // link the timer tick to the game engine event
            gameTimer.Interval = TimeSpan.FromMilliseconds(time + 16.66);
            //InformatikProjekt.gameEngine.startGame(gameTimer, MyCanvas);
            StartButton sB = new StartButton();
            sB.buttonCreate(MyCanvas, gameTimer);

            this.Background = new SolidColorBrush(Colors.LightSlateGray);
            this.Width = w;
            this.Height = h;

            Boxerstellung.Punkteboxerstellung(ref Punktebox, MyCanvas, Punkte, w);
            Boxerstellung.Highscoreboxerstellung(ref Highscorebox, MyCanvas, Punkte, w);
        }


        private void gameEngine(object sender, EventArgs e)
        {
            InformatikProjekt.gameEngine.Execute(bilder, time, MyCanvas, scale, w, h, Punkte);
            Score.ScoreUpdate(Punktebox, Punkte, MyCanvas);
            
        }

        
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GetMouseClick.Mausklick(MyCanvas, e, bilder, ref awaitedIndex, gameTimer, ref Punkte, ref Highscore, ref Highscorebox);
        }

        public void ResetPoints()
        {
            Punkte = 0;
        }
    }

}

//To-Do: Count Down erstellen, Schwierigkeitsgrad --> Verringerung der Zeit bei fortgeschrittener Punktzahl
//Wenn alle Bilder angeklickt wurden (Klicksequenz beendet) dann sollen alle Bilder despawnen und dann das neue spawnen