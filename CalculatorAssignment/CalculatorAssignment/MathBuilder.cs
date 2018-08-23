using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorAssignment
{
    class MathBuilder
    {
        List<MathNode> MathNodes { get; set; }
        public MathBuilder()
        {
            MathNodes = new List<MathNode>();
        }
        public void AddNode(MathNode newNode)
        {
            MathNode PreviousNode = MathNodes[MathNodes.Count - 1];
        }
    }
}
