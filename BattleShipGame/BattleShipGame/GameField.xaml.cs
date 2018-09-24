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
                if (x>=TopLeft.X && x<BotRight.X && y>=TopLeft.Y && y<BotRight.Y)
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
        public bool CheckSpace(Point position,Size area)
        {
            // The space must be within the box
            if (position.X<0 | position.Y<0 | position.X+area.Width>MapSize.Width | position.Y+area.Height>MapSize.Height)
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
                        if (f==false)
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
            Point Snapped = new Point((int)(Raw.X * GridContent.ColumnDefinitions.Count / GridContent.ActualWidth),(int)(Raw.Y * GridContent.RowDefinitions.Count / GridContent.ActualHeight));
            debug.Content = Snapped.ToString();
            bool space = CheckPosition((int)Snapped.X, (int)Snapped.Y);
            debug.Content += $"\n {space.ToString()}";
            bool bigspace = CheckSpace(new Point((int)Snapped.X, (int)Snapped.Y), new Size(2, 2));
            debug.Content += $"\n{bigspace.ToString()}"; 
        }
    }
}
