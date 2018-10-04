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
    /// Interaction logic for GameField.xaml
    /// </summary>
    public partial class GameField : UserControl
    {




        public readonly Size MapSize;

        public GameField()
        {
            InitializeComponent();
            MapSize = new Size(GridContent.ColumnDefinitions.Count, GridContent.RowDefinitions.Count);
        }
        /// <summary>
        /// Check whether the a space on the grid is occupied
        /// </summary>
        /// <param name="x"> must be 0-9</param>
        /// <param name="y">must be 0-9</param>
        /// <returns>true if space is empty</returns>
        public bool CheckPosition(int x, int y)
        {
            foreach (var item in GridContent.Children.Cast<UIElement>())
            {
                Point TopLeft = GetPosition(item);
                Size ItemSize = GetItemSize(item);
                Point BotRight = new Point(TopLeft.X + ItemSize.Width, TopLeft.Y + ItemSize.Height);
                if (x >= TopLeft.X && x < BotRight.X && y >= TopLeft.Y && y < BotRight.Y)
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Returns the Size of an item in rowspan and colspan
        /// </summary>
        /// <param name="item">The size of the item</param>
        /// <returns></returns>
        private Size GetItemSize(UIElement item)
        {
            double ColumnSpan = Grid.GetColumnSpan(item);
            double RowSpan = Grid.GetRowSpan(item);
            return new Size(ColumnSpan, RowSpan);
        }
        /// <summary>
        /// Get the position of an element
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private Point GetPosition(UIElement item)
        {
            double Column = Grid.GetColumn(item);
            double Row = Grid.GetRow(item);
            return new Point(Column, Row);
        }
        /// <summary>
        /// Checks if there are any ships occupying this space On the grid
        /// </summary>
        /// <param name="position"></param>
        /// <param name="area"></param>
        /// <returns></returns>
        public bool CheckSpace(Point position, Size area)
        {
            // The space must be within the box
            if (position.X < 0 | position.Y < 0 | position.X + area.Width > MapSize.Width | position.Y + area.Height > MapSize.Height)
            {
                return false;
            }
            else
            {
                for (int y = 0; y < area.Height; y++)
                {
                    for (int x = 0; x < area.Width; x++)
                    {
                        bool f = CheckPosition((int)(position.X + x), (int)(position.Y + y));
                        if (f == false)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
        }


        private void GridContent_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void GridContent_MouseMove(object sender, MouseEventArgs e)
        {
            Point Raw = e.GetPosition(GridContent);
            Point Snapped = Snap(Raw);
            debug.Content = Snapped.ToString();
            bool space = CheckPosition((int)Snapped.X, (int)Snapped.Y);
            debug.Content += $"\n {space.ToString()}";
            bool bigspace = CheckSpace(new Point((int)Snapped.X, (int)Snapped.Y), new Size(2, 2));
            debug.Content += $"\n{bigspace.ToString()}";
            SetPreviewSize(new Point(Snapped.X-1,Snapped.Y-1), new Size(3, 3));
        }

        public void setPosition(UIElement child, Point p)
        {
            Grid.SetColumn(child, (int)p.X);
            Grid.SetRow(child, (int)p.Y);
        }
        public void setSize(UIElement child, Size s)
        {
            Grid.SetColumnSpan(child, (int)s.Width);
            Grid.SetRowSpan(child, (int)s.Height);
        }

        public void SetPreviewSize(Point p, Size s)
        {
            // Grid Top Left
            double X1 = Math.Max(0, p.X);
            double Y1 = Math.Max(0, p.Y);
            double X2 = Math.Min(10, SizeToPoint(p, s).X);
            double Y2 = Math.Min(10, SizeToPoint(p, s).Y);
            Point newTL = new Point((int)X1, (int)Y1);
            Size newSize = PointToSize(X1, Y1, X2, Y2);
            setPosition(PositionPreview, newTL);
            setSize(PositionPreview, newSize);
            PositionPreview.Stroke = new SolidColorBrush(Colors.Orange);
            PositionPreview.StrokeThickness = 3;
        }

        private Size GetElementSize(Point pR1, Point pR2)
        {
            double absWidth = pR2.X - pR1.X;
            double absHeight = pR2.Y - pR1.Y;
            Size result = new Size(absWidth, absHeight);
            return result;
        }
        private Size PointToSize(Point TopLeft, Point BottomRight)
        {
            double Width =Math.Abs(TopLeft.X - BottomRight.X);
            double height = Math.Abs(TopLeft.Y - BottomRight.Y);
            Size Result = new Size((int)Width, (int)Height);
            return Result;
        }
        private Size PointToSize(double x1, double y1, double x2, double y2)
        {
            double Width = Math.Abs(x1 - x2);
            double Height = Math.Abs(y1 - y2);
            Size Result = new Size(Width, Height);
            return Result;
        }
        private Point SizeToPoint(Point TopLeft,Size s)
        {
            double newX = TopLeft.X + s.Width;
            double newY = TopLeft.Y + s.Height;
            Point Result = new Point((int)newX, (int)newY);
            return Result;
        }
        private Point SizeToPoint(Size s, Point BottomRight)
        {
            double newX = BottomRight.X - s.Width;
            double newY = BottomRight.Y - s.Height;
            Point Result = new Point((int)newX, (int)newY);
            return Result;
        }

        private static Point ClipPoint(Point PPTL, bool insidebounds, Point PR1)
        {
            if (insidebounds)
            {
                PR1 = PPTL;
            }
            return PR1;
        }

        private bool CheckBounds(Point previewPoint, Point bottomRight, Point topLeft)
        {
            if (previewPoint.X >= topLeft.X & previewPoint.X < bottomRight.X & previewPoint.Y >= topLeft.Y & previewPoint.Y < bottomRight.Y)
            {
                return true;
            }
            return false;
        }

        private Point Snap(Point rawposition)
        {
            double SnappedX = rawposition.X * GridContent.ColumnDefinitions.Count / GridContent.ActualWidth;
            double SnappedY = rawposition.Y * GridContent.RowDefinitions.Count / GridContent.ActualHeight;
            return new Point((int)SnappedX, (int)SnappedY);
        }
    }
}
