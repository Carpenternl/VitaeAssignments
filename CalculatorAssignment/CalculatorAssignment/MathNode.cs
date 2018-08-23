namespace CalculatorAssignment
{
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
}