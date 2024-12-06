using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace InformatikProjekt
{
    internal class RemoveBoxes
    {
        public void Remove(Canvas MyCanvas)
        {
            //Entfehrnen alle GameOver-Textboxen (Markiert durch den Tag "over")
            var filteredTextBoxes = MyCanvas.Children.OfType<TextBox>().Where(tb => tb.Tag?.ToString() == "over"); //Alle Elemente auf dem Canvas, wo (--> Schleife --> Aktuelles Element mit "tb" abrufbar) der Tag ("?" macht die Variable nullable falls der Tag nich definiert ist) "over" ist
            //Foreach Schleife für jedes Element
            foreach (var textBox in filteredTextBoxes)
            {
                if (MyCanvas.Children.Contains(textBox)) //Überprüfen ob Element auf dem Canvas ist
                {
                    MyCanvas.Children.Remove(textBox); //wenn ja, entfernen und Methode abbrechen (return)
                    return;
                }
            }
        }
    }
}
