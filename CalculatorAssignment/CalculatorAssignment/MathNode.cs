namespace CalculatorAssignment
{
    /// <summary>
    /// Encapsulating class to use as I Enumerable
    /// </summary>
    public abstract class MathNode
    {
        public abstract ValueNode Calculate();
    }
    public abstract class OperatorNode : MathNode
    {
        protected OperatorNode(double Defaultval)
        {
            left = new ValueNode(Defaultval);
            right = new ValueNode(Defaultval);
        }
        protected MathNode left;
        protected MathNode right;
    }
    public class AddOperator : OperatorNode
    {
        protected AddOperator(double Defaultval) : base(Defaultval)
        {
            Defaultval = 0;
        }

        public override ValueNode Calculate()
        {
            return left.Calculate() + right.Calculate();
        }
    }
    public class SubTractOperator : OperatorNode
    {
        protected SubTractOperator(double Defaultval) : base(Defaultval)
        {
            Defaultval = 0;
        }

        public override ValueNode Calculate()
        {
            return left.Calculate() - right.Calculate();
        }
    }
    class DivideOperator : OperatorNode
    {
        public DivideOperator(double Defaultval) : base(Defaultval)
        {
            Defaultval = 0;
        }
        public override ValueNode Calculate()
        {
            try
            {
                return left.Calculate() / right.Calculate();
            }
            catch (System.ArgumentException)
            {
                System.Windows.Forms.MessageBox.Show("Cannot Divide By Zero");
                return new ValueNode(0);
            }
        }
    }
    class MultiplyOperator : OperatorNode
    {
        public MultiplyOperator(double defaultValue) : base(defaultValue)
        {
            defaultValue = 0;
        }
        public override ValueNode Calculate()
        {
            return left.Calculate() * right.Calculate();
        }
    }
}