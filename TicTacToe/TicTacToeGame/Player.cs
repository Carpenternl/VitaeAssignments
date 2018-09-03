using System;
using System.Windows.Media;

namespace TicTacToeGame
{
    public class Player
    {
        public readonly int PlayerID;
        public string PlayerName { get; set; }
        public Color PlayerColor { get; set; }

        public Player(string Name,Color color,int ID = 0)
        {
            PlayerName = Name;
            PlayerColor = color;
            if(ID == 0)
            {
                PlayerID = new Random().Next(1000000, 9999999);
            }
            else
            {
                PlayerID = ID;
            }
        }
        public override string ToString()
        {
            return $"{PlayerID} | {PlayerName}";
        }
    }
}