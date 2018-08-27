using System;
using System.Collections.Generic;

namespace CalculatorAssignment
{
    internal class MathWorker
    {
        List<MathElement> Nodes;

        Type Divide = typeof(DivideOperator);
        Type Add = typeof(AddOperator);
        Type Subtract = typeof(SubTractOperator);
        Type Multiply = typeof(MultiplyOperator);

        public MathWorker()
        {
            Nodes = new List<MathElement>();
        }
        public void AddNode(MathElement input)
        {
            MathElement Buffer = Nodes[Nodes.Count - 1];
            if (Nodes.Count <= 0)
            {
                AddToEmptyNodes(input);
            }
            else
            {
                TryAddtoExisitingNodes(input, Buffer);
            }
        }

        private void TryAddtoExisitingNodes(MathElement input, MathElement Buffer)
        {
            if (input is OperatorElement)
            {
                if (Buffer is OperatorElement)
                {

                    TryAddOperatorToOperator(input, Buffer);
                }
                else
                {
                    Nodes.Add(input);
                }
            }
            else
            {
                AddOperatorToValue(input, Buffer);
            }
        }
        /// <summary>
        /// try and add the input if the input is a value and the buffer is an operator
        /// </summary>
        /// <param name="input"></param>
        /// <param name="Buffer"></param>
        private void AddOperatorToValue(MathElement input, MathElement Buffer)
        {
            if (Buffer is OperatorElement)
            {
                if (Buffer is SubTractOperator)
                {
                    AddNegativeInput(input);
                }
                else
                {
                    Nodes.Add(input);
                }
            }
            else
            {
                ReplaceLastNode(input);
            }
        }

        private void AddNegativeInput(MathElement input)
        {
            ValueElement valInput = input as ValueElement;
            valInput.Value = valInput.Value * -1;
            ReplaceLastNode(valInput);
        }

        private void AddToEmptyNodes(MathElement input)
        {
            if (!(input is DivideOperator))
            {
                Nodes.Add(input);
            }
        }

        private void TryAddOperatorToOperator(MathElement input, MathElement Buffer)
        {
            if (input is SubTractOperator)
            {
                if (Buffer is MultiplyOperator | Buffer is DivideOperator)
                {
                    Nodes.Add(input);
                }
                else
                {
                    ReplaceLastNode(input);
                }
            }
            else
            {
                if (Buffer is SubTractOperator)
                {
                    SwapLastNodeWithInput(Buffer, input);
                }
                else
                {
                    ReplaceLastNode(input);
                }
            }
        }

        private void ReplaceLastNode(MathElement input)
        {
            Nodes[Nodes.Count - 1] = input;
        }

        private void SwapLastNodeWithInput(MathElement buffer, MathElement input)
        {
            ReplaceLastNode(input);
            Nodes.Add(buffer);
        }
    }
}