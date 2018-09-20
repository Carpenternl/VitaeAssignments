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

        public delegate void LeftDownHandler(object sender, Point location);
        public event LeftDownHandler leftdown;
        public delegate void leftUpHandler(object sender, Point location);
        public event leftUpHandler LeftUp;

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
                Cells[i].MouseLeftButtonDown += Ship_MouseLeftButtonDown;
            }
        }

        private void Ship_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MapCell target = sender as MapCell;
            
            target.MouseLeftButtonUp += Target_MouseLeftButtonUp;
        }

        private void Target_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MapCell target = sender as MapCell;
            target.MouseLeftButtonUp -= Target_MouseLeftButtonUp;
            throw new NotImplementedException();
        }

        //TODO: Rotate
    }
}
