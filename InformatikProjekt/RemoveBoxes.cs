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
            var filteredTextBoxes = MyCanvas.Children.OfType<TextBox>().Where(tb => tb.Tag?.ToString() == "over");
            foreach (var textBox in filteredTextBoxes)
            {
                if (MyCanvas.Children.Contains(textBox))
                {
                    MyCanvas.Children.Remove(textBox);
                    return;
                }
            }
        }
    }
}
