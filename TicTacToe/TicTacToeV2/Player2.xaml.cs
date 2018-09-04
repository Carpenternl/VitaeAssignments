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

namespace TicTacToeV2
{
    /// <summary>
    /// Interaction logic for Player2.xaml
    /// </summary>
    public partial class Player2 : UserControl
    {

        public readonly int ID;

        public String PlayerName
        {
            get { return (String)GetValue(PlayerNameProperty); }
            set { SetValue(PlayerNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PlayerName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlayerNameProperty =
            DependencyProperty.Register("PlayerName", typeof(String), typeof(Player2), new PropertyMetadata("New Player"));


        public Color PlayerColor
        {
            get { return (Color)GetValue(PlayerColorProperty); }
            set { SetValue(PlayerColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PlayerColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlayerColorProperty =
            DependencyProperty.Register("PlayerColor", typeof(Color), typeof(Player2), new PropertyMetadata(Colors.Gray));

        public Player2()
        {
            InitializeComponent();
        }
        public Player2(int id)
        {
            ID = id;
            InitializeComponent();
            this.NameLabel.Content = ID;
        }

        private void Deleteclick(object sender, RoutedEventArgs e)
        {
            ((StackPanel)this.Parent).Children.Remove(this);
        }
    }
}
