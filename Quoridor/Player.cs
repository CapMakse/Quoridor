using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quoridor
{
    class Player
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public int NumberOfWalls { get; set; } = 9;
        public string Name { get; set; }
    }
}
