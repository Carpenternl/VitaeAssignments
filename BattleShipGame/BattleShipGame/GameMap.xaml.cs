using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BattleShipGame
{
    /// <summary>
    /// Interaction logic for GameMap.xaml
    /// </summary>
    public partial class GameMap : UserControl
    {

        public delegate void MapClickHandler(Point Cellindex);
        public event MapClickHandler MapClick;
        public GameMap()
        {
            MapClick += GameMap_MapClick;
            InitializeComponent();
        }

        private void GameMap_MapClick(Point Cellindex)
        {
            // Do Nothing
        }

        public bool ValidCell(Point arg)
        {
            Point GridPoint = GetGridPosition(arg);
            if(GridPoint.X>=1 & GridPoint.Y>=1 & GridPoint.X<12 & GridPoint.Y < 12)
            {
                return true;
            }
            return false;
        }
        public Point GetGridPosition(Point absolutePosition)
        {
            Point ClickPostion = absolutePosition;
            double Mapwidth = this.ActualWidth;
            double MapHeight = this.ActualHeight;
            double Column = ClickPostion.X * 11 / Mapwidth;
            double Row = ClickPostion.Y * 11 / Mapwidth;
            return new Point(Column, Row);  
        }

        private void Grid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (ValidCell(e.GetPosition(this)))
            {
                MapClick(GetGridPosition(e.GetPosition(this)));
            }
        }
    }
}
