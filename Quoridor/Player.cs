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
        public int CountOfWalls { get; set; } = 9;
        public string Name { get; set; }
        public PlayerType Type { get; set; }
    }
    enum PlayerType
    {
        red,
        blue
    }
}
