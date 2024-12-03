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
        public static void ScoreUpdate(TextBox box, int score, Canvas MyCanvas)
        {
            if (MyCanvas.Children.Contains(box))
            {
                box.Text = $"Punkte: {score}";
            }
        }

        public static void HighScoreUpdate(TextBox box, int score, Canvas MyCanvas)
        {
            if (MyCanvas.Children.Contains(box))
            {
                box.Text = $"Highscore: {score}";
            }
        }
    }
}
