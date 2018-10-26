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
    public enum VesselClass { None,Water,Scout,Submarine,BattleShip,AirCraft_Carrier}
    public partial class Ship : UserControl
    {
        #region Properties

        #region - VesselClass (enum)
        public VesselClass Vessel
        {
            get { return (VesselClass)GetValue(VesselProperty); }
            set { SetValue(VesselProperty, value); }
        }
        // Using a DependencyProperty as the backing store for ShipOrientation.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VesselProperty =
            DependencyProperty.RegisterAttached("Vessel", typeof(VesselClass), typeof(Ship), new PropertyMetadata(VesselClass.None,VCChanged));

        private static void VCChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Ship Target = d as Ship;
            Target.ReGrid();
        }
        #endregion
        #region - Position (Point)
        public Point Position
        {
            get { return (Point)GetValue(PositionProperty); }
            set { SetValue(PositionProperty, value); }
        }

        public static readonly DependencyProperty PositionProperty =
            DependencyProperty.Register("Position", typeof(Point), typeof(Ship), new PropertyMetadata(new Point(0,0),PositionChangedCallback,CoersePosition));

        private static void PositionChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CoersePosition(d, e.NewValue);
        }
        /// <summary>
        /// Prevents the X and Y coordinates to go below 0
        /// </summary>
        private static object CoersePosition(DependencyObject d, object baseValue)
        {
            Point TargetValue = (Point)baseValue;
            if (TargetValue.X < 0)
            {
                TargetValue.X = 0;
            }
            if (TargetValue.Y < 0)
            {
                TargetValue.Y = 0;
            }
            return TargetValue;
        }

        #endregion
        #region - ShipOrienTation (enum)
        public Orientation ShipOrientation
        {
            get { return (Orientation)GetValue(ShipOrientationProperty); }
            set { SetValue(ShipOrientationProperty, value); }
        }
        public static readonly DependencyProperty ShipOrientationProperty =
            DependencyProperty.Register("ShipOrientation", typeof(Orientation), typeof(Ship), new PropertyMetadata(Orientation.Horizontal,ShipOrientationChanged));

        private static void ShipOrientationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Ship Target = d as Ship;
            Orientation _DesiredOrientation = (Orientation)e.NewValue;
            Grid TargetGrid = Target.Frame;
            Target.ReGrid();
        }
        public void ReGrid()
        {
            Orientation OrientationArg = ShipOrientation;
            VesselClass VesselClassArg = Vessel;
            Grid Target = this.Frame;
            int Length = (int)VesselClassArg;
            Target.ColumnDefinitions.Clear();
            Target.RowDefinitions.Clear();
            switch (OrientationArg)
            {
                case Orientation.Horizontal:
                    Grid.SetColumnSpan(this, Length);
                    Grid.SetRowSpan(this, 1);
                    for (int X = 0; X < Length; X++)
                    {

                        Target.ColumnDefinitions.Add(new ColumnDefinition());
                    }
                    break;
                case Orientation.Vertical:
                    Grid.SetColumnSpan(this, 1);
                    Grid.SetRowSpan(this, Length);
                    for (int Y = 0; Y < Length; Y++)
                    {
                        Target.RowDefinitions.Add(new RowDefinition());
                    }
                    break;
                default:
                    break;
            }
        }

        

        private static void PopulateRows(Grid TargetGrid, int length)
        {

            for (int i = 0; i < length; i++)
            {
                TargetGrid.RowDefinitions.Add(new RowDefinition());
            }
        }

        private static void PopulateColumns(Grid TargetGrid, int length)
        {
            for (int i = 0; i < length; i++)
            {
                TargetGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }



        #endregion
        #endregion

        public Ship(VesselClass newVesselClass)
        {
            InitializeComponent();
            Vessel = newVesselClass;
        }

        public Ship()
        {
            InitializeComponent();
        }

        #region Tostring Methods
        public override string ToString()
        {
            string Result = (ToString(Vessel)+ToString(Position)+ToString(ShipOrientation));
            return Result;
        }
        public string ToString(VesselClass v)
        {
            return ($"VesselClass: {v} ");
        }
        public string ToString(Point p)
        {
            return ($"Position: {p}");
        }
        public string ToString(Orientation o)
        {
            return ($"Orientation: {o}");
        }
        #endregion

    }
}
