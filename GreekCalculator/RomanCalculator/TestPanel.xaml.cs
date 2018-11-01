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

namespace RomanCalculator
{
    /// <summary>
    /// Interaction logic for TestPanel.xaml
    /// </summary>
    public partial class TestPanel : Page
    {
        public TestPanel()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string text = this.Valuem.Text;
            int a = Convert.ToInt32(text);
            string c = Numeral.ToString(a);
            this.ValueRes.Content = c;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            string text = this.value2.Text;
            int a = Numeral.ToInt(text);
            if (a != 0)
            {
            string d = Numeral.ToString(a);
            this.result2d.Content = d;
            }
            this.ValueRes.Content = a;
        }
    }
}
