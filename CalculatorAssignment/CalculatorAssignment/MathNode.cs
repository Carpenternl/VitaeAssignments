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
        public AddOperator(double Defaultval = 0) : base(Defaultval)
        {
        }

        public override ValueElement Calculate()
        {
            return left.Calculate() + right.Calculate();
        }
    }
    public class SubTractOperator : OperatorElement
    {
        public SubTractOperator(double Defaultval=0) : base(Defaultval)
        {
        }

        public override ValueElement Calculate()
        {
            return left.Calculate() - right.Calculate();
        }
    }
    public class DivideOperator : OperatorElement
    {
        public DivideOperator(double Defaultval = 1) : base(Defaultval)
        {
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
    public class MultiplyOperator : OperatorElement
    {
        public MultiplyOperator(double defaultValue = 1) : base(defaultValue)
        {
        }
        public override ValueElement Calculate()
        {
            return left.Calculate() * right.Calculate();
        }
    }
}