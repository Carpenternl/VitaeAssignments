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
    /// Interaction logic for MapCell.xaml
    /// </summary>
    public partial class MapCell : UserControl
    {
        private Point mapPosition;

        public Point MapPosition
        {
            get { return mapPosition; }
            set { setMapPosition(value); }
        }

        private void setMapPosition(Point value)
        {
            if (mapPosition != value)
            {
                mapPosition.X = (int)value.X;
                mapPosition.Y = (int)value.Y;
               // GameMap.setGridPos(this,(int) value.X,(int)value.Y);
            }
        }
        public MapCell()
        {
            InitializeComponent();
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
        }

        private void Grid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}
