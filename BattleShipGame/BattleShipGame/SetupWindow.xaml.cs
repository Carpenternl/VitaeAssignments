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
    /// The Setup Window handles all the UI events for the user in order to populate a grid with ships
    /// </summary>
    public partial class SetupWindow : Page
    {
       

        /// <summary>
        /// A Collection of Ships the Player can place on the board
        /// </summary>
        public List<Ship> PlacableShips
        {
            get { return (List<Ship>)GetValue(PlacableShipsProperty); }
            set { SetValue(PlacableShipsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShipContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlacableShipsProperty =
            DependencyProperty.Register("PlacableShips", typeof(List<Ship>), typeof(SetupWindow), new PropertyMetadata(DefaultShipContent()));

        /// <summary>
        /// Returns the default amount of ships a A player has to put on the board
        /// </summary>
        private static object DefaultShipContent()
        {
            List<Ship> Result = new List<Ship>();
            int TotalCarrierShi = 1;
            int TotalBattleShip = 2;
            int TotalSubmarines = 3;
            int TotalScoutShips = 4;
            CreateShips(Result, TotalScoutShips, Shiptype.Scout);
            CreateShips(Result, TotalSubmarines, Shiptype.Submarine);
            CreateShips(Result, TotalBattleShip, Shiptype.BattleShip);
            CreateShips(Result, TotalCarrierShi, Shiptype.Aircraftcarrier);
            return Result;
        }
        /// <summary>
        /// creates a TOTALAMOUNTOFSHIPS of THISTYPE and ADDS THEM TO THE RESULT
        /// </summary>
        private static void CreateShips(List<Ship> result, int totalAmountOfShips,Shiptype thisType)
        {
            for (int i = 0; i < totalAmountOfShips; i++)
            {
                result.Add(new Ship());
            }
        }

        private void SelectShip(object sender, MouseButtonEventArgs e)
        {
            AddShipButtonControl ShipItemSender = sender as AddShipButtonControl;
            Ship s = new Ship();
            Size TileDim = playingField.GetTileSize(); // get the Size of A Tile 
            double resx = Grid.GetColumnSpan(s) * TileDim.Width;
            double resy = Math.Max(Grid.GetRow(s) * TileDim.Height, TileDim.Height);
            Size ExpectedSize = new Size(resx, resy);
            s.Width = ExpectedSize.Width;
            s.Height = ExpectedSize.Height;
            Size MousePos = new Size(resx / 2, resy / 2);
            this.ShipPanel.Children.Add(s);
            this.MyDragCanvas.StartDragDrop(s, MousePos);
        }

        public Rectangle hitbox = new Rectangle();

        

        public SetupWindow()
        {
            InitializeComponent();
        }

        private void PlaceShip(Point p, Ship s)
        {
            playingField.Children.Add(s);
            PlayingField.SetElementPosition(s, p);
        }

        private void GameField_MapHover(Point GridIndex)
        {

        }
        private void GameField_Mapclick(Point gridIndex)
        {
            PlayerNameDisplay.Content = gridIndex.ToString();
        }

        private void setDragPosition(UIElement dragElement, Point location)
        {
            setDragPosition(dragElement, location.X, location.Y, 0, 0);
        }
        private void setDragPosition(UIElement dragElement, double x, double y)
        {
            setDragPosition(dragElement, x, y, 0, 0);
        }
        private void setDragPosition(UIElement dragElement, Point location, Point offset)
        {
            setDragPosition(dragElement, location, offset.X, offset.Y);
        }
        private void setDragPosition(UIElement dragElement, Point location, double offsetX, double offsetY)
        {
            setDragPosition(dragElement, location.X, location.Y, offsetX, offsetY);
        }
        private void setDragPosition(UIElement dragElement, double x, double y, double offsetX, double offsetY)
        {
            Canvas.SetLeft(dragElement, x + offsetX);
            Canvas.SetTop(dragElement, y + offsetY);
        }
  


        private Ship CreateNewShip(Shiptype typeOfNewShip, Size renderSize)
        {
            Ship result = new Ship();
            double renderedWidth = renderSize.Width / 11 * Grid.GetColumnSpan(result);
            double renderedHeight = renderSize.Height / 11 * Grid.GetRowSpan(result);
            result.Width = renderedWidth;
            result.Height = renderedHeight;
            return result;
        }

        private void MyDragCanvas_DragQuery(object sender, MouseEventArgs e)
        {
            DragCanvas DragSender = sender as DragCanvas;
            UserControl DragElement = DragSender.MyDraggableElement;
            //Get The hitbox of the draggable Element
            
            Point DragLocation = DragElement.TranslatePoint(default(Point), this);
            Size DragSize = DragElement.RenderSize;
            Rect DragHitBox = new Rect(DragLocation, DragSize);
            var PF = playingField.GridContent;
            Point FieldLocation = PF.TranslatePoint(default(Point), this);
            Size FieldSize = PF.RenderSize;
            Rect FieldHitBox = new Rect(FieldLocation, FieldSize);
            //Check if there is a HitBoxOverLap
            bool hitboxOverlap = HitBoxOverlap(DragHitBox, FieldHitBox);
            //the Draggable Element is hovering over the FieldHitbox,
            if (hitboxOverlap)
            {
                playingField.FindSpace(DragElement);
            }
            playingField.debug.Content += $" \n touch? {hitboxOverlap}";

        }
        private bool HitBoxOverlap(UIElement elementA, UIElement elementB)
        {
            Rect RectA = new Rect()
            {
                Location = elementA.TranslatePoint(default(Point), this),
                Size = elementA.RenderSize,
            };
            Point[] PointsA = { RectA.TopLeft, RectA.TopRight, RectA.BottomRight, RectA.BottomLeft };
            Rect RectB = new Rect()
            {
                Location = elementB.TranslatePoint(default(Point), this),
                Size = elementB.RenderSize,
            };
            return HitBoxOverlap(RectA, RectB);
        }
        private bool HitBoxOverlap(Rect hitBoxA, Rect hitBoxB)
        {
            Point[] CornersA = { hitBoxA.TopLeft, hitBoxA.TopRight, hitBoxA.BottomRight, hitBoxA.BottomLeft };
            foreach (var P in CornersA)
            {
                if (P.X > hitBoxB.Left & P.X < hitBoxB.Right)
                {
                    if (P.Y > hitBoxB.Top & P.Y < hitBoxB.Bottom)
                    {
                        return true;
                    }
                }
            }
            return false;

        }
        private void Hitbl(Rect hitBoxA, Rect hitBoxB)
        {

        }

        private void playingField_PositionChanged(object sender, MouseEventArgs e)
        {
            PlayingField P = sender as PlayingField;
            PlayingField.SetElementPosition(P.Children[0], P.CurrentGridPosition);
        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            Ship a = new Ship(VesselClass.Scout);
           /// Grid.SetRowSpan(a, 4);
            PlaceShip(new Point(3, 3), a);
        }

        private void AddShipClick(object sender, MouseButtonEventArgs e)
        {
            AddShipButtonControl Target = sender as AddShipButtonControl;
            Target.Inventory--;
            Ship NewShip = new Ship(Target.NewVesselClass);
            NewShip.ShipOrientation = Orientation.Horizontal;
            playingField.Children.Add(NewShip);
            Point Spawn = playingField.GetSpawn();
            PlayingField.SetElementPosition(NewShip, new Point((int)NewShip.Vessel,(int)NewShip.Vessel));
        }
    }
    public enum Shiptype { Scout, Submarine, BattleShip, Aircraftcarrier };
}
