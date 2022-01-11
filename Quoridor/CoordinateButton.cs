using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Threading.Tasks;

namespace Quoridor
{
    public class CoordinateButton : Button
    {
        public int X { get; set; }
        public int Y { get; set; }
    public CoordinateButton() : base()
        {
            this.BorderBrush = new SolidColorBrush(Colors.Black);
            this.BorderThickness = new System.Windows.Thickness(3);
            this.Background = new SolidColorBrush(Colors.White);
        }
    }
}
