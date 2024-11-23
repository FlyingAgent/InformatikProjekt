using System;
using System.Diagnostics;
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
using System.Diagnostics;
using System.Windows.Media.Animation;
using System.Windows.Media.Converters;
using System.Security.Cryptography.X509Certificates;

namespace InformatikProjekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        DispatcherTimer gameTimer = new DispatcherTimer();
        public List<Bild> bilder = new List<Bild>();

        public double w = 1000;
        public double h = 1000;
        public int time = 1000;
        public double scale = 0.3;
        public TextBox Punktebox;
        public int Punkte = 0;

        public MainWindow()
        {
            InitializeComponent();

            gameTimer.Tick += gameEngine; // link the timer tick to the game engine event
            gameTimer.Interval = TimeSpan.FromMilliseconds(time + 16.66);
            startGame();

            this.Background = new SolidColorBrush(Colors.Green);
            this.Width = w;
            this.Height = h;

            //einbauen der Punkte
            Punktebox = new TextBox
            {
                Width = 200,
                Height = 30,
                Text = $"Punkte: {Punkte}",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top
            };
            Punktebox.Background = new SolidColorBrush(Colors.LightBlue);
            Canvas.SetLeft(Punktebox, w / 2 - 100);
            MyCanvas.Children.Add(Punktebox);
            
        }
            
        private void startGame()
        {
            gameTimer.Start();
        }



        private async void gameEngine(object sender, EventArgs e)
        {
            bool allPicturesClicked = true;
            bilder.ForEach(b =>
            {
                if (b.gotClicked == false)
                {
                    allPicturesClicked = false;
                }
            });

            if (allPicturesClicked == true)
            {
                bilder.ForEach(b =>
                {
                    b.gotClicked = false;
                });

                // Zufällige neue Position berechnen (z.B. innerhalb eines Bereichs)
                Random random = new Random();
                double newX = random.Next(0, (int)w); // Beispiel: zufällige X-Koordinate
                double newY = random.Next(0, (int)h); // Beispiel: zufällige Y-Koordinate

                Image thisImage = AddImageToGrid(newX, newY);
                await Task.Delay(time);
                removeImage(thisImage);
            }
        }


        private Image AddImageToGrid(double x, double y)
        {
            // Erstelle ein Image-Steuerelement
            Image imageControl = new Image();
            

            // Erstelle eine BitmapImage-Quelle
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("C:/Users/david/OneDrive/Bilder/IMG-20231002-WA0005.jpg", UriKind.Absolute); // Absoluter oder relativer Pfad
            bitmap.EndInit();

            // Weise die Quelle dem Image-Steuerelement zu
            imageControl.Source = bitmap;
            ScaleTransform scaleTransform = new ScaleTransform(scale, scale);
            imageControl.RenderTransform = scaleTransform;

            Canvas.SetLeft(imageControl, x);
            Canvas.SetTop(imageControl, y);

            // Füge das Image zum Grid hinzu
            MyCanvas.Children.Add(imageControl);

            bilder.Add(new Bild { Image = imageControl, h = (double)bitmap.PixelHeight * scale, w = (double)bitmap.PixelWidth * scale });
            return imageControl;
            
        }

        private void removeImage(Image i)
        {
            MyCanvas.Children.Remove(i);
        }

        public int awaitedIndex = 0;
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Get the position of the mouse click relative to the Canvas
            Point clickPosition = e.GetPosition(MyCanvas);
            int index = 0;

            //bilder.ForEach(image =>
            //{
            //    // Check if the click is within the bounds of this image
            //    Image img = image.Image;
            //    double x = Canvas.GetLeft(img);
            //    double y = Canvas.GetTop(img);
            //    Rect imageBounds = new Rect(x, y, img.Width, img.Height);

            //    if((clickPosition.X > imageBounds.X && clickPosition.X < imageBounds.X + image.w) && (clickPosition.Y > imageBounds.Y && clickPosition.Y < imageBounds.Y + image.h))
            //    {
            //        Debug.WriteLine("Yapp");
            //        image.gotClicked = true;    
            //    }

            //    //Debug.WriteLine($"X: {imageBounds.X}, Y: {imageBounds.Y}, W: {image.w} H: {image.h} --> ClickX: {clickPosition.X} ClickY: {clickPosition.Y}");
            //});


            Image img = bilder[awaitedIndex].Image;
            double x = Canvas.GetLeft(img);
            double y = Canvas.GetTop(img);
            Rect imageBounds = new Rect(x, y, img.Width, img.Height);
            

            if ((clickPosition.X > imageBounds.X && clickPosition.X < imageBounds.X + bilder[awaitedIndex].w) && (clickPosition.Y > imageBounds.Y && clickPosition.Y < imageBounds.Y + bilder[awaitedIndex].h))
            {
                Debug.WriteLine("Yapp");
                bilder[awaitedIndex].gotClicked = true;
                if (awaitedIndex + 1 < bilder.Count)
                
                {
                    awaitedIndex++;
                } 
                else
                {
                    awaitedIndex = 0;
                }
            } 
            else
            {
                MessageBox.Show("Nö du huen");
                gameTimer.Stop();
            }
        }

        public int listForIndex(List<Bild> liste)
        {
            int index = 0;
            int outPutIndex = 0;

            liste.ForEach(b =>
            {
                 index++;
                 if (b.gotClicked == true)
                 {
                     outPutIndex = index;
                 }
            });

            return outPutIndex;
        }

    }

    public class Bild
    {
        public double h { get; set; }
        public double w { get; set; }
        public Image Image { get; set; }

        public bool gotClicked = false;

    }
}