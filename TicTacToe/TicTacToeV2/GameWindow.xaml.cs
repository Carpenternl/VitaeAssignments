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

        private void ToggleGame_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddPlayer_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            IEnumerable<int> IDs = from plyr in PlayerList.Children.Cast<Player2>() select plyr.ID;
            int[] idArray = IDs.ToArray();
            int newID;
            if (idArray.Length<=0)
            {
                PlayerList.Children.Add(new Player2(rand.Next(10,99)));
            }
            else
            {
                do
                {
                    newID = rand.Next(10,99);
                } while (idArray.Contains(newID));
                PlayerList.Children.Add(new Player2(newID));
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
