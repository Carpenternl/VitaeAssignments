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
        MathWorker myMathWorker;
        public Form1()
        {
            InitializeComponent();
            myMathWorker = new MathWorker();
        }

        private void numPad1_ValueChanged(object sender, EventArgs e)
        {
            this.textBox1.Text = this.numPad1.PrintValue();
            Console.WriteLine(numPad1.GetValue().ToString());
        }
        
    }
}
