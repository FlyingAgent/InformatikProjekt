using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using System.Windows.Threading;

namespace InformatikProjekt
{
    class GetMouseClick
    {
        public static void Mausklick(Canvas MyCanvas, MouseButtonEventArgs e, List<Bild> bilder, ref int awaitedIndex, DispatcherTimer gameTimer, ref int Punkte, ref int Highscore, ref TextBox Highscorebox)
        {
            Music music = new Music();
            music.playSound("plop2.wav");
            // Get the position of the mouse click relative to the Canvas
            Point clickPosition = e.GetPosition(MyCanvas);

            if (bilder.Count < 1)
            {
                return;
            }
            Image img = bilder[awaitedIndex].Image;
            double x = Canvas.GetLeft(img);
            double y = Canvas.GetTop(img);
            Rect imageBounds = new Rect(x, y, img.Width, img.Height);


            if ((clickPosition.X > imageBounds.X && clickPosition.X < imageBounds.X + bilder[awaitedIndex].w) && (clickPosition.Y > imageBounds.Y && clickPosition.Y < imageBounds.Y + bilder[awaitedIndex].h))
            {
                //Nur wenn das angeklickte Bild nicht auf dem Canvas ist, soll es erscheinen und kurz danach wieder entfernt werden
                if (!MyCanvas.Children.Contains(img))
                {
                    Imagecontrol.spawnAndDespawn(img, MyCanvas);
                }
                Debug.WriteLine("Yapp");
                bilder[awaitedIndex].gotClicked = true;
                if (awaitedIndex + 1 < bilder.Count)
                {
                    awaitedIndex++;
                }
                else
                {
                    awaitedIndex = 0;
                    Punkte++;
                }
            }
            else
            {
                //Abspielen von Endsound
                Music endmusic = new Music();
                endmusic.playSound("endsound.wav");

                //Entfehrnene aller Bilder von dem Canvas
                bilder.ForEach(bild => {
                    MyCanvas.Children.Remove(bild.Image);
                });
                bilder.Clear();

                // Liste für die Rechtecke, die entfernt werden sollen
                var rectanglesToRemove = MyCanvas.Children.OfType<System.Windows.Shapes.Rectangle>().ToList();

                // Entferne die Rechtecke
                foreach (var rectangle in rectanglesToRemove)
                {
                    MyCanvas.Children.Remove(rectangle);
                }

                Highscore = Punkte;
                Score.HighScoreUpdate(Highscorebox, Highscore, MyCanvas);
                gameTimer.Stop();

                Boxerstellung.gameOverBox(MyCanvas, Punkte);
                RestartButton  rB = new RestartButton();
                rB.buttonCreate(MyCanvas, ref gameTimer);
            }
        }
    }
}
