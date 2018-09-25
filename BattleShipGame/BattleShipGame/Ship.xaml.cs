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
    /// Interaction logic for Ship.xaml
    /// </summary>
    public partial class Ship : UserControl
    {


        public Shiptype ShipTypeOf
        {
            get { return (Shiptype)GetValue(ShipTypeOfProperty); }
            set { SetValue(ShipTypeOfProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShipTypeOf.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShipTypeOfProperty =
            DependencyProperty.Register("ShipTypeOf", typeof(Shiptype), typeof(Ship), new PropertyMetadata(Shiptype.Aircraftcarrier));

        public Ship()
        {
            InitializeComponent();
        }
        public Ship(Shiptype type)
        {
            InitializeComponent();
            switch (type)
            {
                case Shiptype.Scout:
                    setGridLength(2);
                    break;
                case Shiptype.Submarine:
                    setGridLength(3);
                    break;
                case Shiptype.BattleShip:
                    setGridLength(4);
                    break;
                case Shiptype.Aircraftcarrier:
                    setGridLength(5);
                    break;
                default:
                    break;
            }

        }

        private void setGridLength(int length)
        {
            setGridLength(length, 1);
        }
        private void setGridLength(Size size)
        {
            setGridLength((int)size.Width, (int)size.Height);
        }
        private void setGridLength(int width, int height)
        {
            Grid.SetColumnSpan(this, width);
            Grid.SetRowSpan(this, height);
        }

        private void UserControl_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            int temp = Grid.GetRowSpan(this);
            Grid.SetRowSpan(this, Grid.GetColumnSpan(this));
            double temw = this.Width;
            this.Width = this.Height;
            this.Height = temw;
            Grid.SetColumnSpan(this, temp);
        }
    }
}
