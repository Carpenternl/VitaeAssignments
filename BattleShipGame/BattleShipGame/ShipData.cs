using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BattleShipGame
{
    class ShipData
    {
        public string ShipName;
        public readonly int ShipID;
        public readonly int ShipSize;
        public enum _Orientation { None, North, East, South, West}
        public _Orientation Orientation;
        public CellData[] Sections;

        public void SetRotation(Point Center, int index)
        {
            

            switch (Orientation)
            {
                case _Orientation.None:
                    
                    break;
                case _Orientation.North:
                    for (int y = 0; y < Sections.Length; y++)
                    {
                        Sections[y].Location = new Point(Center.X, Center.Y + (y - index));
                    }
                    break;
                case _Orientation.East:
                    for (int x = 0; x < Sections.Length; x++)
                    {
                        Sections[x].Location = new Point(Center.X + (x - index),Center.Y);
                    }
                    break;
                case _Orientation.South:
                    for (int y = 0; y < Sections.Length; y++)
                    {
                        Sections[y].Location = new Point(Center.X, Center.Y - (y - index));
                    }
                    break;
                case _Orientation.West:
                    break;
                default:
                    for (int x = 0; x < Sections.Length; x++)
                    {
                        Sections[x].Location = new Point(Center.X + (x - index), Center.Y);
                    }
                    break;
            }
        }
    }
}
