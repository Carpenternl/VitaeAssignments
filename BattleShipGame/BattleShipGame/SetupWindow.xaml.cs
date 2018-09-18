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
            Ship myship = new Ship(3);
            myship.ShipPosition = new Point(3, 3);
            foreach (var item in myship.Cells)
            {
                GameField.Body.Children.Add(item);
            }
        }

        private void BindEvents()
        {
            GameField.Mapclick += GameField_Mapclick;
            GameField.MapHover += GameField_MapHover;
        }
        int testing = 0;
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
    }
}
