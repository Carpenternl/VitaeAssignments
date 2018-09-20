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
    /// Interaction logic for GameMap.xaml
    /// </summary>
    public partial class GameMap : UserControl
    {
        private string horizontalLabels = "0abcdefghij";
        public readonly int size = 11;
        public delegate void MapClickHandler(Point gridIndex);
        public event MapClickHandler Mapclick;
        public delegate void MapHoverHandler(Point GridIndex);
        public event MapHoverHandler MapHover;

        public List<MapCell> CellData;
        public GameMap()
        {
            InitializeComponent();
            BuildGrid();
            CellData = new List<MapCell>(size);
            BindEvents();
        }

        public bool SpaceAvailable(int x,int y)
        {
           IEnumerable<MapCell> result = CellData.Where<MapCell>(Target => Target.MapPosition.X == x & Target.MapPosition.Y == y);
            if (result.Count() > 0)
            {
                return false;
            }
            return true;
        }
        public void AddCell(MapCell ToAdd)
        {
            CellData.Find(f => f.MapPosition == ToAdd.MapPosition);
        }

        private void BindEvents()
        {
            Mapclick += GameMap_Mapclick;
            MapHover += GameMap_MapHover;
        }

        private void GameMap_MapHover(Point GridIndex)
        {
            //Do Nothing
        }

        private void GameMap_Mapclick(Point gridIndex)
        {
            //Do Nothing
        }

        private void BuildGrid()
        {
            for (int i = 0; i < size; i++)
            {
                Body.ColumnDefinitions.Add(new ColumnDefinition());
                Body.RowDefinitions.Add(new RowDefinition());
            }
            for (int x = 1; x < size; x++)
            {
                Label TopLabel = new Label();
                Label LeftLabel = new Label();
                LeftLabel.Content = x.ToString();
                TopLabel.Content = horizontalLabels[x];
                buildLabel(TopLabel, x, 0);
                buildLabel(LeftLabel, 0, x);

            }
        }

        private void buildLabel(Label target, int x, int y)
        {
            target.VerticalAlignment = VerticalAlignment.Center;
            target.HorizontalAlignment = HorizontalAlignment.Center;
            setGridPos(target, x, y);
            Body.Children.Add(target);
        }
        public static void setGridPos(UIElement element, int x, int y)
        {
            Grid.SetColumn(element, x);
            Grid.SetRow(element, y);
        }

        public static Point ToGrid(Point RawPos, Size RawSize, Size GridSize)
        {
            double RawX = RawPos.X;
            double RawY = RawPos.Y;
            double GridX = RawX * GridSize.Width / RawSize.Width;
            double GridY = RawY * GridSize.Height / RawSize.Height;
            return new Point((int)GridX, (int)GridY);
        }
        #region events
        private void Grid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Point MouseRaw = e.GetPosition(Body);
            Point MouseGrid = ToGrid(MouseRaw, Body.RenderSize, new Size(size, size));
            Mapclick(MouseGrid);
        }

        private Point Previous = new Point(-1, -1);
        private void Body_MouseMove(object sender, MouseEventArgs e)
        {
            Point MouseRaw = e.GetPosition(Body);
            Point MouseGrid = ToGrid(MouseRaw, Body.RenderSize, new Size(size, size));
            if (MouseGrid != Previous)
            {
                Previous = MouseGrid;
                MapHover(MouseGrid);
            }
        }
        #endregion
    }
}
