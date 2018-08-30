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

namespace TicTacToeGame
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Page
    {
        Player[] Players;
        public GameWindow()
        {
            InitializeComponent();
        }




        public string OwnerName
        {
            get { return (string)GetValue(OwnerNameProperty); }
            set { SetValue(OwnerNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OwnerID.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OwnerNameProperty =
            DependencyProperty.Register("OwnerID", typeof(string), typeof(GameWindow), new PropertyMetadata("NONE"));





        private void StartButtonClick(object sender, RoutedEventArgs e)
        {
            string GStart = "Start game";
            string gStop = "Stop Game";
            if ((string)GameToggle.Content == GStart)
            {
                GameToggle.Content = gStop;
                BeginGame();
            }
            else
            {
                GameToggle.Content = GStart;
                EndGame();
            }
        }
        /// <summary>
        /// stop The Game
        /// </summary>
        private void EndGame()
        {
            GameGrid.Children.Clear();
            GameGrid.RowDefinitions.Clear();
            GameGrid.ColumnDefinitions.Clear();
            Settings.IsEnabled = true;
        }
        /// <summary>
        /// Start The Game
        /// </summary>
        private void BeginGame()
        {
            Settings.IsEnabled = false;
            SetupGrid();
            for (int X = 0; X < FieldSize.Value; X++)
            {
                for (int Y = 0; Y < FieldSize.Value; Y++)
                {
                    GameGrid.Children.Add(CreateButton(X, Y));
                }
            }
        }

        private UIElement CreateButton(int x, int y)
        {
            Button addB = new Button();
            addB.SetValue(Grid.RowProperty, y);
            addB.SetValue(Grid.ColumnProperty, x);
            //addB.SetValue(OwnerIDProperty,$"{x},{y}");
            addB.Click += FieldButtonClick;
            return (UIElement)addB;

        }

        private void FieldButtonClick(object sender, RoutedEventArgs e)
        {
            Button target = sender as Button;
            string Owner = (string)target.GetValue(OwnerNameProperty);
        }

        private void SetupGrid()
        {
            for (int i = 0; i < FieldSize.Value; i++)
            {
                GameGrid.RowDefinitions.Add(new RowDefinition());
                GameGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }

        private void AddPlayerClick(object sender, RoutedEventArgs e)
        {
            Player newbie = new Player(PlayerList.Children.Count);
            if (Players == null)
            {
                Players = new Player[1];
                Players[0] = newbie;
            }
            else
            {
                List<Player> VariablePlayers = Players.ToList<Player>();
                VariablePlayers.Add(newbie);
                Players = VariablePlayers.ToArray();
            }
            PlayerItem NewbieItem = new PlayerItem();
            NewbieItem.PlayerName = newbie.Name;
            PlayerList.Children.Add(NewbieItem);
        }
    }
}
