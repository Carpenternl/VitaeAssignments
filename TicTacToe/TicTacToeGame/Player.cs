using System.Windows.Media;

namespace TicTacToeGame
{
    internal class Player
    {
        public string Name { get; set; }
        public Color MyProperty { get; set; }
        public Player(int index)
        {
            Name = $"Player {index}";
        }
    }
}