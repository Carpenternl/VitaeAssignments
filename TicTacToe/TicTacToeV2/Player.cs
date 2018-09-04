using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TicTacToeV2
{
    public class Player
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public Player(string name, Color color)
        {
            Name = name;
            Color = color;
        }
    }
}
