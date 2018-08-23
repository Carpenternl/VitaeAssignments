using System;
using System.Collections.Generic;

namespace CalculatorAssignment
{
    internal class MathWorker
    {
        List<MathNode> Nodes;
        public MathWorker()
        {
            Nodes = new List<MathNode>();
        }
        public void addNode(MathNode nodeToAdd)
        {
            var input = nodeToAdd.GetType();
            var a = typeof(OperatorNode);
            if (input == typeof(OperatorNode))
            {
                TryAddOperator(nodeToAdd as OperatorNode);
            }
            if(input == typeof(ValueNode))
            {
                TryAddValue(nodeToAdd as ValueNode);
            }
        }

        private void TryAddValue(ValueNode valueNode)
        {
            throw new NotImplementedException();
        }

        private void TryAddOperator(OperatorNode operatorNode)
        {
            throw new NotImplementedException();
        }
    }
}