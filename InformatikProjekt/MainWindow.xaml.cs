//Für die Datei benötigten Namespaces
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

//Namespace für das Projekt, damit alle Klassen miteinander verknüpft werden lassen
namespace InformatikProjekt
{   
    //Einstiegsklasse für den Code
    //Access Modifier (Zugriffsrechte -> Public/Privat), Zusatz (partial --> Bedeutet, dass anderer Code in dieser Klasse in einer anderen Datei
    //definiert wird, Typ des Objektes (--> class), Name des Objektes
    public partial class MainWindow
    {
        //Schwierigkeit: Brainrot/Intermediate/Brainwarrior; static bedeutet, dass die Variable statisch ist und nicht durch eine Instanzierung aufgerufen werden kann, also direkt über MainWindow.difficulty aufgerufen werden kann. Statische Variablen sind in einem Namespace Klassenübergreifend
        public static string difficulty = "brainrot";
        //Deklarierung und Initialisierung (DuI) des DispatcherTimers gameTimer, der dafür dient, die Methode gameEngine 60 Mal pro Sekund auszuführen
        DispatcherTimer gameTimer = new DispatcherTimer();

        //DuI der Liste Bilder von der Klasse Bild --> Diese Liste wird alle gespawnten Bilder (Ufos) enthalten
        public List<Bild> bilder = new List<Bild>();
        //DuI der Liste positionen von der Klasse Postion, die dafür genutzt werden wird das Raster zu generieren, in dem die Objekte spawnen können
        public static List<Position> positionen = new List<Position>();

        //DuI der Variablen (double --> auch Kommazahlen) für die Dimensionen des Fensters;
        public static double w = 1000;
        public static double h = 1000;

        //DuI der Integer Variable (ganze Zahl (hier in ms)) time, die dafür genutzt wird, die Dauer des Einblendens von Objekten bei erfolgreichem Klick darauf zu bestimmen
        public int time = 1000;

        //DuI der Variable scale für die Skalierung der Bilder, die gespawned werden (Ufos)
        public double scale = ((w+h)/2)/1000;

        //DuI der statischen TextBox Variable Punkte, die klassenübergreifend dafür eingesetzt wird, den Punktestand zu aktualisieren
        public static TextBox Punktebox;

        //DuI der TextBox Variable Highscorebox, die dafür eingesetzt wird, den Highscore zu aktualisieren
        public TextBox Highscorebox;

        //DuI von Variablen zum halten von Scores und Highscores
        public static int Punkte = 0;
        public int Highscore = 0;

        //DuI der statischen Variable awaitedIndex, die in der getMouseClick.Mausklick() Methode dafür verwendet wird zu prüfen, ob der Nutzer auf die Bilder in der richtigen Reihenfolge klickt
        public static int awaitedIndex = 0;

        //Methode, die beim Start des Proramms von WPF automatisch auferufen wird, wird genutzt, um das Prorgamm zu starten
        public MainWindow()
        {
            //Die MainWindow.xaml Datei wird initialisiert, die gehardcodete Elemente und wichtige Bestimmungen für den Code, wie z.B. das Event, was bei einem Mausklick ausgelöst wird, enthalten kann
            InitializeComponent();

            //Aufrufen der Methode, die die Positionen des Rasters in dem Fenster berechnet und speichert
            positionen = Positiongenerator.PositionGenerator();

            //Bei jedem Tick des Gametimers wird die gameEngine Methode aufgerufen
            gameTimer.Tick += gameEngine;
            //Der Interval dafür wird hier deklariert (60 Ausführungen pro Sekunde)
            gameTimer.Interval = TimeSpan.FromMilliseconds(time + 1);
            //InformatikProjekt.gameEngine.startGame(gameTimer, MyCanvas);

            //Erstellung des Startbuttons (Instanzierung der Klasse und anschließend Ausführung der Methode)
            StartButton sB = new StartButton();
            sB.buttonCreate(MyCanvas, gameTimer);

            //Suche des Bildes in der Projektmappe, sodass es auch gefunden werden kann, wenn das Projekt geklont wird und keinen direkten Dateipfadverweis besitzt
            string imagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "void.png");

            //Erstellung eines Bildes als BitMap --> Hintergrundbild
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(imagePath, UriKind.Absolute); // Absoluter oder relativer Pfad
            bitmap.EndInit();

            //Konvertierung dieser bitmap in einen imageBrush, der als Hintergrund des Fensters verwendet werden kann
            ImageBrush imageBrush = new ImageBrush
            {
                ImageSource = bitmap
            };

            //Festlegung des Hintergrundes und der Dimensionen des Fensters
            this.Background = imageBrush;
            this.Width = w;
            this.Height = h;

            //Erstellen von Punkte- und Highscorebox mit Übergabe von benötigten Parametern; "ref" bedeutet hier, dass die Textbox als Referenz übergeben wird. 
            Boxerstellung.Punkteboxerstellung(ref Punktebox, MyCanvas, Punkte, w);
            Boxerstellung.Highscoreboxerstellung(ref Highscorebox, MyCanvas, Punkte, w);
        }

        //Methode die von dem gameTimer aufgerufen wird
        private void gameEngine(object sender, EventArgs e)
        {
            InformatikProjekt.gameEngine.Execute(bilder, time, MyCanvas, scale, w, h, Punkte);
            //Die Scoretextbox wird geupdatet
            Score.ScoreUpdate(Punktebox, Punkte, MyCanvas);
            
        }

        //Methode, die bei Mausklick ausgeführt wird --> Diese triggert die Mausklick Methode in der GetMouseClick Klasse
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GetMouseClick.Mausklick(MyCanvas, e, bilder, ref awaitedIndex, gameTimer, ref Punkte, ref Highscore, ref Highscorebox);
        }
    }

}

//To-Do: Count Down erstellen, Schwierigkeitsgrad --> Verringerung der Zeit bei fortgeschrittener Punktzahl
//Wenn alle Bilder angeklickt wurden (Klicksequenz beendet) dann sollen alle Bilder despawnen und dann das neue spawnen