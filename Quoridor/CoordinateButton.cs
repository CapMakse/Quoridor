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
        public int Row { get; set; }
        public int Column { get; set; }
    public CoordinateButton() : base()
        {
            this.BorderBrush = new SolidColorBrush(Colors.Black);
            this.BorderThickness = new System.Windows.Thickness(3);
        }
    }
}
