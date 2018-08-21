using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorAssignment
{
    public partial class NumPad : UserControl
    {
        /// <summary>
        /// Toggles the comma state
        /// </summary>
        private bool hasComma { get; set; }
        //List of characters
        private List<char> Buffer { get; set; }
        private int CommaIndex;

        public delegate void ValueClearedEventHandler(object sender, EventArgs e);
        public delegate void ValueChangedEventHandler(object sender, EventArgs e);

        /// <summary>
        /// Occurs when the Value is changed
        /// </summary>
        public event ValueChangedEventHandler ValueChanged;
        /// <summary>
        /// Occurs when the Value is cleared
        /// </summary>
        public event ValueClearedEventHandler ValueCleared;
        public string GetStringValue()
        {
            char[] Bufferchars = Buffer.ToArray();
            StringBuilder result = new StringBuilder();
            foreach (var item in Bufferchars)
            {
                result.Append(item);
            }
            string bufferstring = result.ToString();
            return bufferstring;
        }
        public NumPad()
        {
            //create Buffer
            Buffer = new List<char>();
            ValueChanged += Value_Changed_event;
            InitializeComponent();
        }
        private void Value_Changed_event(object sender, EventArgs e)
        {

        }
        private void numeric_Click(object sender, EventArgs e)
        {
            Button Target = sender as Button;
            Buffer.Add(Target.Text[0]);
            ValueChanged(this, e);
        }
        private void Clear_Click(object sender, EventArgs e)
        {
            Buffer.Clear();
            ValueChanged(this, e);
        }
        private void Comma_Click(object sender, EventArgs e)
        {
            ToggleComma();
            ValueChanged(this, e);
        }
        private void ToggleComma()
        {
            if (Buffer.Contains(','))
            {
                Buffer.Remove(',');
                hasComma = false;
            }
            else
            {
                Buffer.Add(',');
                CommaIndex = Buffer.Count - 1;
                hasComma = true;
            }
        }
    }
}
