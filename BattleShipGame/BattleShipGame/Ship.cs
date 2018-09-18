using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BattleShipGame
{
    class Ship
    {
        private int shipSize;
        public MapCell[] Cells;
        public int ShipSize
        {
            get { return shipSize; }
            set { shipSize = value; }
        }
        private Point shipPosition;

        public Point ShipPosition
        {
            get { return shipPosition; }
            set { SetShipPostion(value); }
        }

        private void SetShipPostion(Point value)
        {
            if (shipPosition!=value)
            {
                shipPosition = value;
                MoveCells();
            }
        }

        private void MoveCells()
        {
            for (int i = 0; i < Cells.Length; i++)
            {
                if (vertical)
                {
                    GameMap.setGridPos(Cells[i],(int)ShipPosition.X,(int)ShipPosition.Y + i);
                }
                else
                {
                    GameMap.setGridPos(Cells[i], (int)ShipPosition.X + i, (int)ShipPosition.Y);
                }
            }
        }

        //Constructor
        bool vertical = false;
        public Ship(int ShipSize)
        {
            shipSize = ShipSize;
            Cells = new MapCell[ShipSize];
            for (int i = 0; i < Cells.Length; i++)
            {
                Cells[i] = new MapCell();
                Cells[i].MouseLeftButtonUp += Ship_MouseLeftButtonUp;
            }
        }

        private void Ship_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MapCell f = sender as MapCell;
            f.Content = "test";
          //  Console.Write("CLicked");
        }

        //TODO: Rotate
    }
}
