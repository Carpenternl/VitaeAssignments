using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorAssignment
{
    class MathBuilder
    {
        List<MathElement> MathNodes { get; set; }
        public MathBuilder()
        {
            MathNodes = new List<MathElement>();
        }
        public void AddNode(MathElement newNode)
        {
            MathElement PreviousNode = MathNodes[MathNodes.Count - 1];
        }
    }
}
