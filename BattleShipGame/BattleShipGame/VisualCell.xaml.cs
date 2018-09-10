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
    /// Interaction logic for VisualCell.xaml
    /// </summary>
    public partial class VisualCell : UserControl
    {
        public enum Face { North,East,South,West}
        private Face facing;
        private Point boardLocation;
        public delegate void FacingChangedHandler(object sender, Face newFace);
        public event FacingChangedHandler FacingChanged;
        public delegate void LocationChangedHandler(object sender, Point delta);
        public event LocationChangedHandler LocationChanged;

        public Point BoardLocation
        {
            get { return BoardLocation; }
            set { SetBoardLocation(value); }
        }

        private void SetBoardLocation(Point value)
        {
            if (boardLocation != value)
            {
                Point Delta = new Point(value.X - BoardLocation.X, value.Y - boardLocation.Y);
                boardLocation = value;
                LocationChanged(this, Delta);
            }
        }

        public int ShipIndex;

        public Face Facing {
            get { return facing; }
            set { SetFacing(value); }
        }

        private void SetFacing(Face value)
        {
            if(this.facing != value)
            {
                facing = value;
                //TODO Manipulate Rotation of the image
                FacingChanged(this, value);
            }
        }
        public VisualCell()
        {
            InitializeComponent();
            FacingChanged += VisualCell_FacingChanged;
            LocationChanged += VisualCell_LocationChanged;
        }

        private void VisualCell_LocationChanged(object sender, Point delta)
        {
            if (sender==this)
            {
                return;
            }
            this.SetBoardLocation(new Point(this.boardLocation.X + delta.X, this.boardLocation.Y + delta.Y));
        }

        private void VisualCell_FacingChanged(object sender, Face newFace)
        {
            if (sender == this)
            {
                return;
            }
            VisualCell Sender = sender as VisualCell;
            this.facing = newFace;
            int delta = this.ShipIndex - Sender.ShipIndex;
            //Change the cell position Based upon the Delta
            Point Origin = Sender.BoardLocation;
            switch (newFace)
            {
                case Face.East:
                    SetBoardLocation(new Point(Origin.X+delta, Origin.Y));
                    break;
                case Face.South:
                    SetBoardLocation(new Point(Origin.X, Origin.Y - delta));
                    break;
                case Face.West:
                    SetBoardLocation(new Point(Origin.X - delta, Origin.Y));
                    break;
                case Face.North:
                default:
                    SetBoardLocation(new Point(Origin.X, Origin.Y + delta));
                    break;
            }
        }

        internal void Connect(VisualCell vC2)
        {
            throw new NotImplementedException();
        }
    }
}
