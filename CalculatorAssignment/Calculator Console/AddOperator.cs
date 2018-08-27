using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_Console
{
    class AddOperator : MathOperator
    {
        
        public AddOperator()
        {
            OperatorType = mType.add;
            Left = new MathValue();
            Right = new MathValue();
        }


        public override MathValue Solve()
        {
            throw new NotImplementedException();
        }
    }
}
