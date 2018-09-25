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
    /// Interaction logic for AddShipButtonControl.xaml
    /// </summary>
    public partial class AddShipButtonControl : UserControl
    {

        public Shiptype NewShipType
        {
            get { return (Shiptype)GetValue(NewShipTypeProperty); }
            set { SetValue(NewShipTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NewShipType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NewShipTypeProperty =
            DependencyProperty.Register("NewShipType", typeof(Shiptype), typeof(AddShipButtonControl), new PropertyMetadata(Shiptype.Scout));
        public int ShipCount
        {
            get { return (int)GetValue(ShipCountProperty); }
            set { SetValue(ShipCountProperty, value); }
        }
        // Using a DependencyProperty as the backing store for ShipTotal.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShipCountProperty =
            DependencyProperty.Register("ShipCount", typeof(int), typeof(AddShipButtonControl), new PropertyMetadata(0));


        public AddShipButtonControl()
        {
            InitializeComponent();
        }
    }
}
