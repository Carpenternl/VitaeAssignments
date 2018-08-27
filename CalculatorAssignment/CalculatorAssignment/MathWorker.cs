using System;
using System.Collections.Generic;

namespace CalculatorAssignment
{
    internal class MathWorker
    {
        List<MathElement> Nodes;
        public MathWorker()
        {
            Nodes = new List<MathElement>();
        }
        public void addNode(MathElement nodeToAdd)
        {
            var input = nodeToAdd.GetType();
            var a = typeof(OperatorElement);
            if (input == typeof(OperatorElement))
            {
                TryAddOperator(nodeToAdd as OperatorElement);
            }
            if(input == typeof(ValueElement))
            {
                TryAddValue(nodeToAdd as ValueElement);
            }
        }

        private void TryAddValue(ValueElement valueNode)
        {
            throw new NotImplementedException();
        }

        private void TryAddOperator(OperatorElement operatorNode)
        {
            throw new NotImplementedException();
        }
    }
}