using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace TicTacToeV2
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Page
    {


        public GameWindow()
        {
            InitializeComponent();
        }

        private void TogglePlayerStart(object sender, RoutedEventArgs e)
        {
            Button Target = sender as Button;
            // get your players
            Player2[] Players = PlayerList.Children.Cast<Player2>().ToArray();
            // Can't play without players
            if (Players.Length > 0)
            {
                // get your field Size
                int Fieldsize = (int)FieldSizeSlider.Value;
                // Get your score Threshold
                int WinThreshold = (int)WinThresholdSlider.Value;
                Field.StartGame(Players, Fieldsize, WinThreshold);
                Target.Click += TogglePlayerEnd;
                Target.Click -= TogglePlayerStart;
                Target.Content = "Stop Game";
            }

        }

        private void TogglePlayerEnd(object sender, RoutedEventArgs e)
        {
            Button Caller = sender as Button;
            Field.EndGame();
            Caller.Click += TogglePlayerStart;
            Caller.Click -= TogglePlayerEnd;
            Caller.Content = "Start Game";
        }

        private void AddPlayer_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            IEnumerable<int> IDs = from plyr in PlayerList.Children.Cast<Player2>() select plyr.ID;
            int[] idArray = IDs.ToArray();
            int newID;
            if (idArray.Length <= 0)
            {
                PlayerList.Children.Add(new Player2(rand.Next(10, 99)));
            }
            else
            {
                do
                {
                    newID = rand.Next(10, 99);
                } while (idArray.Contains(newID));
                PlayerList.Children.Add(new Player2(newID) { PlayerColor = GetRandomColor() });
            }
            InvalidateVisual();
        }

        private Color GetRandomColor()
        {
            Random R = new Random();
            byte Red = GetRandomByte(R);
            byte Blue = GetRandomByte(R);
            byte Green = GetRandomByte(R);
            Color Result = Color.FromRgb(Red, Green, Blue);
            return Result;
        }
        private byte GetRandomByte(Random r)
        {
            return (byte)(r.Next(10, 25) * 10);
        }

        private void WinThresholdSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (WinThresholdSlider.Value > FieldSizeSlider.Value)
            {
                WinThresholdSlider.Value = FieldSizeSlider.Value;
            }
        }
    }
}
