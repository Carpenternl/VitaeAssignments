using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorAssignment
{
    class OperatorInterperter
    {
        OperatorElement[] buffer;
        public OperatorInterperter()
        {
            buffer = new OperatorElement[2];
        }

        public void PeformLogic(OperatorElement input)
        {
            if (buffer[0] == null)
            {
                buffer[0] = input;
                return;
            }
            // second input is a '+'
            if (input.GetType() == typeof(AddOperator))
            {
                //Don't do anything if previous operator != '-' > a + - b == a - b
                if (buffer[0].GetType() == typeof(SubTractOperator))
                {
                }
            }
            if (input.GetType() == typeof(SubTractOperator))
            {
                if (buffer[0].GetType() == typeof(SubTractOperator))
                {
                    buffer[0] = new AddOperator();
                }
                if (buffer[0].GetType() == typeof(AddOperator))
                {
                    buffer[0] = input;
                }
                if (buffer[0].GetType() == typeof(MultiplyOperator) || buffer[0].GetType() == typeof(DivideOperator))
                {
                    buffer[1] = input;
                }
            }
            if (input.GetType() == typeof(DivideOperator))
            {
                if (buffer[0].GetType() == typeof(SubTractOperator))
                {
                    buffer[0] = input;
                    buffer[1] = new SubTractOperator();
                }
            }
            if (input.GetType() == typeof(MultiplyOperator))
            {
                if (buffer[0].GetType() == typeof(SubTractOperator))
                {
                    buffer[0] = input;
                    buffer[1] = new SubTractOperator();
                }
            }
        }
    }
}
