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
        public Rectangle hitbox = new Rectangle();
        public SetupWindow()
        {
            InitializeComponent();
            //Grid.SetRowSpan(hitbox, 3);
            //Grid.SetColumnSpan(hitbox, 3);
            //GameField.Body.Children.Add(hitbox);
            BindEvents();
            //Ship myship = new Ship(3);
            //myship.ShipPosition = new Point(3, 3);
            //foreach (var item in myship.Cells)
            //{
            //    GameField.Body.Children.Add(item);
            //}
        }

        private void BindEvents()
        {

        }
        private void GameField_MapHover(Point GridIndex)
        {
            //testing++;
            //int HitBoxX = (int)GridIndex.X - 1;
            //int HitBoxy = (int)GridIndex.Y - 1;
            //if (HitBoxX < 1 | HitBoxy < 1)
            //{
            //    HitBoxX = Math.Max(HitBoxX, 1);
            //    HitBoxy = Math.Max(HitBoxy, 1);
            //    hitbox.Fill = new SolidColorBrush(Colors.Red);
            //}
            //else
            //{
            //    hitbox.Fill = new SolidColorBrush(Colors.Green);
            //}
            //GameMap.setGridPos(hitbox, HitBoxX, HitBoxy);
            //PlayerNameDisplay.Content = GridIndex.ToString() + " " + testing.ToString();
        }
        private void GameField_Mapclick(Point gridIndex)
        {
            PlayerNameDisplay.Content = gridIndex.ToString();
        }

        private void ScoutLabelClick(object sender, MouseButtonEventArgs e)
        {

            Label Sender = sender as Label;
            Point MouseOrigin = e.GetPosition(DragOverlay);
            // TODO create a ship
            Ship myShip = new Ship();
            //myShip.RenderSize = new Size(200, 200);
            Size grid = GameField.RenderSize;
            Size shipnewsize = new Size(grid.Width / 11 * 2, grid.Height / 11);
            myShip.Width = shipnewsize.Width;
            myShip.Height = shipnewsize.Height;
            setDragPosition(myShip, MouseOrigin, -10, -10);
            DragOverlay.IsHitTestVisible = true;
            //ContentLayout.IsHitTestVisible = false;
            DragOverlay.Children.Insert(0,myShip);
            DragOverlay.MouseMove += Dragging;
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
        Point dragArm;
        private void Dragging(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Point target = e.GetPosition(DragOverlay);
                setDragPosition(DragOverlay.Children[0], target, dragArm.X, dragArm.Y);
                Point BoundPoint = e.GetPosition(GameField);
                if (BoundPoint.X > 0 & BoundPoint.Y > 0)
                {
                    ((UIElement)DragOverlay.Children[0]).SetValue(BackgroundProperty, new SolidColorBrush(Colors.Red));
                }
            }
            else
            {
                StopDragging();
            }
        }

        private void StopDragging()
        {
            DragOverlay.IsHitTestVisible = false;
            ContentLayout.IsHitTestVisible = true;
            DragOverlay.MouseMove -= Dragging;
            DragOverlay.Children.Clear();
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
            AddShipButtonControl Sender = sender as AddShipButtonControl;
            Shiptype TypeOfNewShip = Sender.NewShipType;
            Ship NewShip = CreateNewShip(TypeOfNewShip,GameField.RenderSize);
            InitializeDrag(NewShip, e.GetPosition(DragOverlay), new Point(0.5,0.5));

        }

        private void InitializeDrag(UIElement newShip, Point point1, Point point2)
        {
            
            double arm = point2.X *(double) newShip.GetValue(WidthProperty);
            double army = point2.Y * (double) newShip.GetValue(HeightProperty);
            dragArm = new Point(-arm, -army);
            setDragPosition(newShip, point1, dragArm.X,dragArm.Y);
            DragOverlay.IsHitTestVisible = true;
            ContentLayout.IsHitTestVisible = false;
            DragOverlay.Children.Add(newShip);
            DragOverlay.MouseMove += Dragging;
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


    }
    public enum Shiptype { Scout,Submarine,BattleShip,Aircraftcarrier};
}
