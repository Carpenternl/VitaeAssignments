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

        public VesselClass NewVesselClass
        {
            get { return (VesselClass)GetValue(NewVesselClassProperty); }
            set { SetValue(NewVesselClassProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NewVesselClass.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NewVesselClassProperty =
            DependencyProperty.Register("NewVesselClass", typeof(VesselClass), typeof(AddShipButtonControl), new PropertyMetadata(VesselClass.None));



        public int Inventory
        {
            get { return (int)GetValue(InventoryProperty); }
            set { SetValue(InventoryProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Inventory.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InventoryProperty =
            DependencyProperty.Register("Inventory", typeof(int), typeof(AddShipButtonControl), new PropertyMetadata(0));

        public AddShipButtonControl()
        {
            InitializeComponent();
        }
    }
}
