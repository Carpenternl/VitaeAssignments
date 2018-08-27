namespace CalculatorAssignment
{
    /// <summary>
    /// Encapsulating class to use as I Enumerable
    /// </summary>
    public abstract class MathElement
    {
        public abstract ValueElement Calculate();
    }
    public abstract class OperatorElement : MathElement
    {
        protected OperatorElement(double Defaultval)
        {
            left = new ValueElement(Defaultval);
            right = new ValueElement(Defaultval);
        }
        protected MathElement left;
        protected MathElement right;
    }
    public class AddOperator : OperatorElement
    {
        protected AddOperator(double Defaultval) : base(Defaultval)
        {
            Defaultval = 0;
        }

        public override ValueElement Calculate()
        {
            return left.Calculate() + right.Calculate();
        }
    }
    public class SubTractOperator : OperatorElement
    {
        protected SubTractOperator(double Defaultval) : base(Defaultval)
        {
            Defaultval = 0;
        }

        public override ValueElement Calculate()
        {
            return left.Calculate() - right.Calculate();
        }
    }
    class DivideOperator : OperatorElement
    {
        public DivideOperator(double Defaultval) : base(Defaultval)
        {
            Defaultval = 0;
        }
        public override ValueElement Calculate()
        {
            try
            {
                return left.Calculate() / right.Calculate();
            }
            catch (System.ArgumentException)
            {
                System.Windows.Forms.MessageBox.Show("Cannot Divide By Zero");
                return new ValueElement(0);
            }
        }
    }
    class MultiplyOperator : OperatorElement
    {
        public MultiplyOperator(double defaultValue) : base(defaultValue)
        {
            defaultValue = 0;
        }
        public override ValueElement Calculate()
        {
            return left.Calculate() * right.Calculate();
        }
    }
}