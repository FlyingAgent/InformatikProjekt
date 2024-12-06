using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace InformatikProjekt
{
    internal class Score
    {
        //Methoden, die die Textboxen für den Score und Highscore, updaten
        public static void ScoreUpdate(TextBox box, int score, Canvas MyCanvas)
        {
            if (MyCanvas.Children.Contains(box)) //Prüfen, ob die Box überhaupt auf dem Canvas ist (Fehler vorbeugen)
            {
                box.Text = $"Punkte: {score}";
            }
        }

        public static void HighScoreUpdate(TextBox box, int score, Canvas MyCanvas)
        {
            if (MyCanvas.Children.Contains(box)) //Prüfen, ob die Box überhaupt auf dem Canvas ist (Fehler vorbeugen)
            {
                box.Text = $"Highscore: {score}";
            }
        }
    }
}
