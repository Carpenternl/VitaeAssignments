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
    /// Interaction logic for SetupWindow.xaml
    /// </summary>
    public partial class SetupWindow : Page
    {
        #region Properties
        private void SelectShip(object sender, MouseButtonEventArgs e)
        {
            AddShipButtonControl ShipItemSender = sender as AddShipButtonControl;
            Ship s = new Ship(ShipItemSender.NewShipType);
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
        /*
     * 
     * - Drop/ Place Ship
     * - Rotate Ship
     * - Finish Setup
     * -
     */
        public Rectangle hitbox = new Rectangle();

        public SetupWindow()
        {
            InitializeComponent();
        }
        #endregion
        private void GameField_MapHover(Point GridIndex)
        {

        }
        private void GameField_Mapclick(Point gridIndex)
        {
            PlayerNameDisplay.Content = gridIndex.ToString();
        }

        private void ScoutLabelClick(object sender, MouseButtonEventArgs e)
        {

            //Label Sender = sender as Label;
            //Point MouseOrigin = e.GetPosition(MyDragCanvas);
            //// TODO create a ship
            //Ship myShip = new Ship();
            ////myShip.RenderSize = new Size(200, 200);
            //Size grid = GameField.RenderSize;
            //Size shipnewsize = new Size(grid.Width / 11 * 2, grid.Height / 11);
            //myShip.Width = shipnewsize.Width;
            //myShip.Height = shipnewsize.Height;
            //setDragPosition(myShip, MouseOrigin, -10, -10);
            //MyDragCanvas.IsHitTestVisible = true;
            ////ContentLayout.IsHitTestVisible = false;
            //DragOverlay.Children.Insert(0,myShip);
            //DragOverlay.MouseMove += Dragging;
        }
        #region setDragPosition
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
        #endregion
        private void Dragging(object sender, MouseEventArgs e)
        {

        }

        private void StopDragging()
        {
            //DragOverlay.IsHitTestVisible = false;
            //ContentLayout.IsHitTestVisible = true;
            //DragOverlay.MouseMove -= Dragging;
            //DragOverlay.Children.Clear();
        }

        private void EndDrag(object sender, MouseButtonEventArgs e)
        {
        }

        private void AddShipButtonControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AddShipButtonControl Sender = sender as AddShipButtonControl;
            Sender.ShipCount--;
        }

        private void CreateAndDragNewShip(object sender, MouseButtonEventArgs e)
        {
            //AddShipButtonControl Sender = sender as AddShipButtonControl;
            //Shiptype TypeOfNewShip = Sender.NewShipType;
            //Ship NewShip = CreateNewShip(TypeOfNewShip,GameField.RenderSize);
            //InitializeDrag(NewShip, e.GetPosition(DragOverlay), new Point(0.5,0.5));

        }

        private void InitializeDrag(UIElement newShip, Point point1, Point point2)
        {

            //double arm = point2.X *(double) newShip.GetValue(WidthProperty);
            //double army = point2.Y * (double) newShip.GetValue(HeightProperty);
            //dragArm = new Point(-arm, -army);
            //setDragPosition(newShip, point1, dragArm.X,dragArm.Y);
            //DragOverlay.IsHitTestVisible = true;
            //ContentLayout.IsHitTestVisible = false;
            //DragOverlay.Children.Add(newShip);
            //DragOverlay.MouseMove += Dragging;
        }

        private Ship CreateNewShip(Shiptype typeOfNewShip, Size renderSize)
        {
            Ship result = new Ship(typeOfNewShip);
            double renderedWidth = renderSize.Width / 11 * Grid.GetColumnSpan(result);
            double renderedHeight = renderSize.Height / 11 * Grid.GetRowSpan(result);
            result.Width = renderedWidth;
            result.Height = renderedHeight;
            return result;
        }

        private void AddShipButtonControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Size s = (Size)e.GetPosition(sender as AddShipButtonControl);
            Ship myship = new Ship(Shiptype.Scout);
            this.ShipPanel.Children.Add(myship);
            this.MyDragCanvas.StartDragDrop(myship, s);
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
            PlayingField.SetElementPosition(P.Children[0], P.LastGridPoint);
        }
    }
    public enum Shiptype { Scout, Submarine, BattleShip, Aircraftcarrier };
}
