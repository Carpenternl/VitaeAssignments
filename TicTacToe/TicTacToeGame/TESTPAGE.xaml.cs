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
    /// Interaction logic for TESTPAGE.xaml
    /// </summary>
    public partial class TESTPAGE : Page
    {
        public TESTPAGE()
        {
            InitializeComponent();
            
        }

        private void MyGameFrame0_Loaded(object sender, RoutedEventArgs e)
        {
            Random f = new Random();

            Player P1 = new Player("Hugo", Colors.Green, f.Next(1000,9999));
            Player P2 = new Player("Arthur", Colors.Red, f.Next(1000,9999));
            Player P3 = new Player("Birgit", Colors.Yellow, f.Next(1000, 9999));
            Player[] pls = { P1, P2,P3};
            MyGameFrame0.StartGame(10, 10,pls);
        }
    }
}
