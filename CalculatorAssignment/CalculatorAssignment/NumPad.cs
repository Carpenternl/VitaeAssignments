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
        // The Buffer will hold all the characters in sequence
        private List<char> Buffer;
        
        /// <summary>
        /// Gets the Current Value
        /// </summary>
        /// <returns></returns>
        public double GetValue()
        {
            double result;
            result = Convert.ToDouble(Buffer.ToArray().ToString());
            return result;
        }
        /// <summary>
        /// Set's the Value of the Numpad
        /// </summary>
        /// <param name="newVal"></param>
        public void SetValue(double newVal)
        {
            string newValString = newVal.ToString();
            Buffer.Clear();
            foreach (var CharVal in newValString)
            {
                Buffer.Add(CharVal);
            }
            ValueChanged(this, new EventArgs());
        }
        public string PrintValue()
        {
            string result = "";
            while (Buffer.Count()>1 & Buffer.Count()<3 && Buffer[0] == '0')
            {
                Buffer.RemoveAt(0);
            }
            if (Buffer.Count()>0 && Buffer[0] == ',')
            {
                Buffer.Insert(0, '0');
            }
            char[] resultArray =  Buffer.ToArray();
            StringBuilder resultbuilder = new StringBuilder();
            for (int i = 0; i < resultArray.Length; i++)
            {
                resultbuilder.Append(resultArray[i]);
            }
            result = resultbuilder.ToString();
            return result;
        }
        /// <summary>
        /// When the value is changed, this event will fire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void ValueChangedEventHandler(object sender, EventArgs e);
        public event ValueChangedEventHandler ValueChanged;

        public NumPad()
        {
            Buffer = new List<char>();
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button target = sender as Button;
            switch (target.Text[0]) 
            {
                case 'C':
                    ClearValue(target);
                    break;
                case ',':
                    ToggleComma(target);
                    break;
                default:
                    AddNumber(target); 
                    break;
            }
        }

        private void AddNumber(Button target)
        {
            // Cannot Spam 0's

            Buffer.Add(target.Text[0]);
            ValueChanged(this, new EventArgs());
        }
        /// <summary>
        /// Toggles the Comma inside the value
        /// </summary>
        /// <param name="sender"></param>
        private void ToggleComma(Button sender)
        {
            if (Buffer.Contains(','))
            {
                Buffer.Remove(',');
            }
            else
            { 
                Buffer.Add(',');
            }
            if (Buffer.Count > 1)
            {
            ValueChanged(this, new EventArgs());
            }
        }

        private void ClearValue(Button target)
        {
            this.Buffer.Clear();
            ValueChanged(this, new EventArgs());
            // throw new NotImplementedException();
        }
    }
}
