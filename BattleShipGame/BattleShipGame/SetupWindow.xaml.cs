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
        public SetupWindow()
        {
            InitializeComponent();
            GameField.MapClick += GameField_MapClick;
        }

        private void GameField_MapClick(Point Cellindex)
        {
            //throw new NotImplementedException();
        }
    }
}
