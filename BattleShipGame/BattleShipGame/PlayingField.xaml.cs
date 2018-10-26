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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BattleShipGame
{
    /// <summary>
    /// Interaction logic for GameField.xaml  
    /// </summary>
    [ContentProperty(nameof(Children))]
    public partial class PlayingField : UserControl
    {
        #region Static Values
        private static int MinimumRows = 10;
        private static int MinimumCollumns = 10;
        private static int MaximumRows =20;
        private static int MaximumCollumns = 20;
        #endregion
        //Properties of the PlayingField
        #region Properties
        // Property used to access Children from a child panel
        #region Children
        public UIElementCollection Children
        {
            get { return (UIElementCollection)GetValue(ChildrenProperty.DependencyProperty); }
            private set { SetValue(ChildrenProperty, value); }
        }
        public static readonly DependencyPropertyKey ChildrenProperty =
            DependencyProperty.RegisterReadOnly(nameof(Children) , typeof(UIElementCollection), typeof(PlayingField), new PropertyMetadata());
        #endregion
        // Property used to position elements on the grid
        #region ElementPosition
        public static Point GetElementPosition(DependencyObject obj)
        {
            return (Point)obj.GetValue(ElementPositionProperty);
        }
        public static void SetElementPosition(DependencyObject obj, Point value)
        {
            obj.SetValue(ElementPositionProperty, value);
        }
        public static readonly DependencyProperty ElementPositionProperty =
            DependencyProperty.RegisterAttached("ElementPosition", typeof(Point), typeof(PlayingField),
                new PropertyMetadata(new Point(0, 0),ElemntPositionChanged, CoerceElemntPositn));
        #region ElementPositionLogic
        // This function gets called every time the Property header changes.
        private static object CoerceElemntPositn(DependencyObject d, object baseValue)
        {
            // get the size of the grid
            Size _grid = (Size)d.GetValue(BoardSizeProperty);
            // We can assume that the value is a point, convert the basevalue
            Point EnteredValue = (Point)baseValue;
            double CurrentX = CoerseRange(0, EnteredValue.X, _grid.Width);
            double CurrentY = CoerseRange(0, EnteredValue.Y, _grid.Height);
            return new Point(CurrentX, CurrentY);
        }
        // This function will coarse our value within a range
        #region CoerseRange
        /// <summary>
        /// Makes sure your value moves within your defined range
        /// </summary>
        /// <param name="min">the minimum value required</param>
        /// <param name="arg">the value to compare</param>
        /// <param name="max">the maximum value needed</param>
        /// <returns>Returns arg or the min/max value based upon difference </returns>
        public static double CoerseRange(double min, double arg,double max)
        {
            double Arg0 = Math.Max(arg, min);
            double Arg1 = Math.Min(Arg0, max);
            return Arg1;
        }
        #endregion
        // the Dependency Property changed, update the Grid Position
        private static void ElemntPositionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIElement target = d as UIElement;
            Point ePoint = (Point)e.NewValue;
            Grid.SetColumn(target, (int)ePoint.X);
            Grid.SetRow(target, (int)ePoint.Y);

            //throw new NotImplementedException();
        }

        #endregion
        // ElementPositionLogic
        #endregion
        // Property used to setup the grid-layout and labels.
        #region BoardSize
        public Size BoardSize
        {
            get { return (Size)GetValue(BoardSizeProperty); }
            set { SetValue(BoardSizeProperty, value); }
        }
        // Using a DependencyProperty as the backing store for BoardSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BoardSizeProperty =
            DependencyProperty.Register("BoardSize", typeof(Size), typeof(PlayingField), new PropertyMetadata(new Size(10,10),BZChanged,CoerceBoardSizeProperty));
        #region BoardSizeLogic
        private static object CoerceBoardSizeProperty(DependencyObject d, object baseValue)
        {
            Size BaseValueSize = (Size)baseValue;
            int ResultX = (int)CoerseRange(MinimumCollumns, BaseValueSize.Width, MaximumCollumns); // MinW < BaseValue.Width < MaxW
            int ResultY = (int)CoerseRange(MinimumRows, BaseValueSize.Height, MaximumRows); // MinH < BaseValue.Height < MaxH
            Size Result = new Size(ResultX, ResultY);
            return Result;
        }
        private static void BZChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PlayingField P = d as PlayingField;
            Grid PG = P.Gridbody;
            Size End = (Size)e.NewValue;
            int X = (int)End.Width;
            int Y = (int)End.Height;
            RefreshGrid(P, X, Y);
            PG.RowDefinitions[1].Height = new GridLength(Y, GridUnitType.Star);
            PG.ColumnDefinitions[1].Width = new GridLength(X, GridUnitType.Star);
        }
        /// <summary>
        /// Logic for 'redrawing' the grid.
        /// </summary>
        /// <param name="P"></param>
        /// <param name="rows"></param>
        /// <param name="collumns"></param>
        private static void RefreshGrid(PlayingField P, int rows, int collumns)
        {
            ResetColumns(P.HorizLabels.ColumnDefinitions, rows);
            ResetRows(P.VertiLabels.RowDefinitions, collumns);
            ResetColumns(P.GridContent.ColumnDefinitions, rows);
            ResetRows(P.GridContent.RowDefinitions, collumns);
        }
        /// <summary>
        /// Clears the Collection and creates n amount of new definitions
        /// </summary>
        /// <param name="rows">The collection to refresh</param>
        /// <param name="n">the amount of rows required</param>
        private static void ResetRows(RowDefinitionCollection rows, int n)
        {
            rows.Clear();
            for (int i = 0; i < n; i++)
            {
                rows.Add(new RowDefinition());
            }
        }
        /// <summary>
        /// Clears the Collection and Creates n amount of new definitions
        /// </summary>
        /// <param name="collumns">The collection to refresh</param>
        /// <param name="n">the amount of collumns required</param>
        private static void ResetColumns(ColumnDefinitionCollection collumns, int n)
        {
            collumns.Clear();
            for (int i = 0; i < n; i++)
            {
                collumns.Add(new ColumnDefinition());
            }
        }
        #endregion
        // BoardSize
        #endregion
        // Property used to set the size of elements on the grid
        #region ElementSize


        public static Size GetElementSize(DependencyObject obj)
        {
            return (Size)obj.GetValue(ElementSizeProperty);
        }

        public static void SetElementSize(DependencyObject obj, Size value)
        {
            obj.SetValue(ElementSizeProperty, value);
        }

        // Using a DependencyProperty as the backing store for ElementSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ElementSizeProperty =
            DependencyProperty.RegisterAttached("ElementSize", typeof(Size), typeof(PlayingField), new PropertyMetadata(default(Size)));
        //private static object CoerceElemntPositn(DependencyObject d, object baseValue)
        //{
        //    // get the size of the grid
        //    Size _grid = (Size)d.GetValue(BoardSizeProperty);
        //    // We can assume that the value is a point, convert the basevalue
        //    Point EnteredValue = (Point)baseValue;
        //    double CurrentX = CoerseRange(0, EnteredValue.X, _grid.Width);
        //    double CurrentY = CoerseRange(0, EnteredValue.Y, _grid.Height);
        //    return new Point(CurrentX, CurrentY);
        //}

        //public static double CoerseRange(double min, double arg, double max)
        //{
        //    double Arg0 = Math.Max(arg, min);
        //    double Arg1 = Math.Min(Arg0, max);
        //    return Arg1;
        //}

        //private static void ElemntPositionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    UIElement target = d as UIElement;
        //    Point ePoint = (Point)e.NewValue;
        //    Grid.SetColumn(target, (int)ePoint.X);
        //    Grid.SetRow(target, (int)ePoint.Y);

        //    //throw new NotImplementedException();
        //}

        #endregion

        #endregion

        Border ShipPreviewPosition = new Border() { BorderThickness = new Thickness(2), BorderBrush = new SolidColorBrush(Colors.Purple) };
        public PlayingField()
        {
            InitializeComponent();
            // This piece of code allows the control to hold elements in another userControl
            this.Children = GridContent.Children;    // https://stackoverflow.com/questions/9094486/adding-children-to-usercontrol
            PositionChanged += PlayingField_PositionChanged;
        }
        // Event handler that gets called when the cursor moves to a different Cell.
        private void PlayingField_PositionChanged(object sender, MouseEventArgs e)
        {
            PlayingField F = sender as PlayingField;
            Point P = F.LastGridPoint;

        }

        #region events
        public delegate void MousePositionChanged(object sender, MouseEventArgs e);
        public event MousePositionChanged PositionChanged;
        #endregion

        // Public Functions used to interact with the Grid
        #region Public Functions
        #endregion



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
            double PX = position.X;
            double PY = position.Y;
            Grid _grid = this.GridContent;
            // The space must be within the box
            if (PX < 0 | PY < 0 | position.X + area.Width > _grid.ColumnDefinitions.Count | position.Y + area.Height > _grid.RowDefinitions.Count)
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

        private void GridContent_MouseMove(object sender, MouseEventArgs e)
        {
            Point Raw = e.GetPosition(GridContent);
            Point Snapped = Snap(Raw);
            debug.Content = Snapped.ToString();
            bool space = CheckPosition((int)Snapped.X, (int)Snapped.Y);
            debug.Content += $"\n {space.ToString()}";
            bool bigspace = CheckSpace(new Point((int)Snapped.X, (int)Snapped.Y), new Size(2, 2));
            debug.Content += $"\n{bigspace.ToString()}";
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


        private Size GetElementSize(Point pR1, Point pR2)
        {
            double absWidth = pR2.X - pR1.X;
            double absHeight = pR2.Y - pR1.Y;
            Size result = new Size(absWidth, absHeight);
            return result;
        }
        private Size PointToSize(Point TopLeft, Point BottomRight)
        {
            double Width = Math.Abs(TopLeft.X - BottomRight.X);
            double height = Math.Abs(TopLeft.Y - BottomRight.Y);
            Size Result = new Size((int)Width, (int)Height);
            return Result;
        }

        internal void FindSpace(UserControl dragElement)
        {
            //CurrentPostion of de draggable;
            Point TopLeftCornerOfShip = dragElement.TranslatePoint(default(Point), this.GridContent);
            Size ShipsizeinGridUnits = new Size(width: Grid.GetColumnSpan(dragElement), height: Grid.GetRowSpan(dragElement));
            Point SnappedLeftCornerOfShip = Snap(TopLeftCornerOfShip);
            Point SnapTest = new Point(SnappedLeftCornerOfShip.X + 1, SnappedLeftCornerOfShip.Y + 1);
            double resx = SnapTest.X;
            if (TopLeftCornerOfShip.X / 11 - SnappedLeftCornerOfShip.X < SnapTest.X - TopLeftCornerOfShip.X)
            {
                resx = SnappedLeftCornerOfShip.X;
            }
            double resy = SnapTest.Y;
            if (TopLeftCornerOfShip.Y / 11 - SnappedLeftCornerOfShip.Y < SnapTest.Y - TopLeftCornerOfShip.Y)
            {
                resy = SnappedLeftCornerOfShip.Y;

            }
            Grid.SetRowSpan(ShipPreviewPosition, (int)ShipsizeinGridUnits.Height);
            Grid.SetColumnSpan(ShipPreviewPosition, (int)ShipsizeinGridUnits.Width);

            SetElementPosition(ShipPreviewPosition, new Point((int)resx, (int)resy));
        }

        private Size PointToSize(double x1, double y1, double x2, double y2)
        {
            double Width = Math.Abs(x1 - x2);
            double Height = Math.Abs(y1 - y2);
            Size Result = new Size(Width, Height);
            return Result;
        }
        private Point SizeToPoint(Point TopLeft, Size s)
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

        internal UIElement GetFieldSize()
        {
            return GridContent;
        }

        /// <summary>
        /// Returns the renderSize of a single Tile
        /// </summary>
        /// <returns>Size in pixels</returns>
        public Size GetTileSize()
        {
            Grid _Grid = GridContent;
            double Width = _Grid.ActualWidth;
            double Height = _Grid.ActualHeight;
            double TileColumns = _Grid.ColumnDefinitions.Count;
            double TileRows = _Grid.RowDefinitions.Count;
            double TileWidth = Width / TileColumns;
            double TileHeight = Height / TileRows;
            Size Result = new Size(TileWidth, TileHeight);
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
        /// <summary>
        /// Returns the row and and column location of the cursor on the field.
        /// </summary>
        /// <param name="raw"></param>
        /// <returns></returns>
        public Point Snap(Point raw)
        {
            Grid _grid = GridContent;
            double SnappedX = raw.X * _grid.ColumnDefinitions.Count / _grid.ActualHeight;
            double SnappedY = raw.Y * _grid.RowDefinitions.Count / _grid.ActualHeight;
            return new Point(SnappedX,SnappedY);
        }
        /// <summary>
        ///  Returns the row and and column location of the cursor on the field rounded to integers
        /// </summary>
        /// <param name="raw"></param>
        public Point SnapInt(Point raw)
        {
            Point Snapped = Snap(raw);
            return new Point(Math.Floor(Snapped.X),Math.Floor(Snapped.Y));
        }
        public Point CurrentGridPosition { get; private set; }
        // checks if the mouse has moved to a different cell during a mousemove, reducing event calls
        private void MouesMovedEvent(object sender, MouseEventArgs e)
        {
            Point CursorPosition = e.GetPosition(GridContent);
            Point NewGridPosition = SnapInt(CursorPosition);
            if(NewGridPosition != CurrentGridPosition)
            {
                CurrentGridPosition = NewGridPosition;
                PositionChanged(this, e);
            }
        }
    }
}
