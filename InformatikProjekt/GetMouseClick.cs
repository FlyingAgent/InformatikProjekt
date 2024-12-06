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
        //Methode, die bei Mausklick aufgerufen wird
        public static void Mausklick(Canvas MyCanvas, MouseButtonEventArgs e, List<Bild> bilder, ref int awaitedIndex, DispatcherTimer gameTimer, ref int Punkte, ref int Highscore, ref TextBox Highscorebox)
        {
            //Abspielen des "Plop"-Sounds
            Music music = new Music();
            music.playSound("plop2.wav");

            // Position des Mausklicks relativ zum Canvas bekommen
            Point clickPosition = e.GetPosition(MyCanvas);

            //Abbrechen der Methode, wenn noch keine Elemente gespawned wurden
            if (bilder.Count < 1)
            {
                return;
            }
            //Definierung des Bildes, das der Nutzer nach der richtigen Reihenfolge anklicken müsste und x und y Koordianten davon abrufen, sowie ein Rechteck damit erstellen
            Image img = bilder[awaitedIndex].Image;
            double x = Canvas.GetLeft(img);
            double y = Canvas.GetTop(img);
            Rect imageBounds = new Rect(x, y, img.Width, img.Height);

            //Prüfen, on der Nutzer auf das Bild geklickt hat
            if ((clickPosition.X > imageBounds.X && clickPosition.X < imageBounds.X + bilder[awaitedIndex].w) && (clickPosition.Y > imageBounds.Y && clickPosition.Y < imageBounds.Y + bilder[awaitedIndex].h))
            {
                //Nur wenn das angeklickte Bild nicht auf dem Canvas ist, soll es erscheinen und kurz danach wieder entfernt werden
                if (!MyCanvas.Children.Contains(img))
                {
                    Imagecontrol.spawnAndDespawn(img, MyCanvas); //Aufdecken des Bildes zur Bestätigung, dass der Nutzer richtig geklickt hat
                }
                //Markieren des aktuellen Bildes als "angeklickt"
                bilder[awaitedIndex].gotClicked = true;

                //Wenn es noch übrige Bilder gibt, dann soll der awaitedIndex erhöht werden, um eine weitere Abfrage beim nächsten Klick zu ermöglichen, sonst wird dieser Zurückgesetzt und der Nutzer bekommt einen Punkt dafür, dass er alle Bilder in der richtigen Reihenfolge angeklickt hat
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
            else //Wenn der Nutzer nicht richtig geklickt hat
            {
                //Abspielen von Endsound
                Music endmusic = new Music();
                endmusic.playSound("endsound.wav");

                //Entfehrnene aller Bilder von dem Canvas
                bilder.ForEach(bild => {
                    MyCanvas.Children.Remove(bild.Image);
                });
                bilder.Clear(); //Leeren der Bilderliste

                // Liste für die Rechtecke, die entfernt werden sollen
                var rectanglesToRemove = MyCanvas.Children.OfType<System.Windows.Shapes.Rectangle>().ToList(); //Filtern aller Rechtecke auf dem Canvas --> das Raster

                // Entferne die Rechtecke
                foreach (var rectangle in rectanglesToRemove)
                {
                    MyCanvas.Children.Remove(rectangle);
                }

                //Erhöhung des Highscores, wenn der neue Punktestand höher als dieser ist 
                if (Punkte > Highscore)
                {
                    Highscore = Punkte;
                }
                Score.HighScoreUpdate(Highscorebox, Highscore, MyCanvas); //Updaten der Highscorebox
                gameTimer.Stop(); //Stoppen des gameTimers und somit der gameEngine

                Boxerstellung.gameOverBox(MyCanvas, Punkte); //Erstellung der gameOverBox
                //Erstellung des Restartbuttons
                RestartButton  rB = new RestartButton(); 
                rB.buttonCreate(MyCanvas, ref gameTimer);
            }
        }
    }
}
