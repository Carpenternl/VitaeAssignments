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
    /// Interaction logic for BattleShipStartup.xaml
    /// </summary>
    public partial class BattleShipStartup : Page
    {


        public delegate void StartGameHandler(string[] Players);
        public event StartGameHandler StartGame;

        public BattleShipStartup()
        {
            StartGame += BattleShipStartup_StartGame;
            InitializeComponent();
        }

        private void BattleShipStartup_StartGame(string[] Players)
        {
            //throw new NotImplementedException();
        }

        private void NameInputChanged(object sender, TextChangedEventArgs e)
        {
            TextBox Caller = sender as TextBox;
            if (Caller.Text.Length < 3)
            {
                Caller.Foreground = new SolidColorBrush(Colors.Red);
            }
            else
            {
                Caller.Foreground = new SolidColorBrush(Colors.Black);
            }
            UpdateButtonState();
        }

        private void UpdateButtonState()
        {
            if( PlayerName1.Text.Length>2 & PlayerName2.Text.Length > 2)
            {
                StartButton.IsEnabled = true;
            }
            else
            {
                StartButton.IsEnabled = false;
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            string[] args = { PlayerName1.Text, PlayerName2.Text };
            StartGame(args);
        }
    }
}
