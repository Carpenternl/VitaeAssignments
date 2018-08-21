using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorAssignment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void numPad1_ValueChanged(object sender, EventArgs e)
        {
            NumPad target = sender as NumPad;
            string result = target.GetStringValue();
            this.textBox1.Text = result;
        }
    }
}
