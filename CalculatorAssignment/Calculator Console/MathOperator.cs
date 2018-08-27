namespace Calculator_Console
{
    abstract class MathOperator : MathItem
    {
        public enum mType
        {
            add, subtract, multiply, divide
        }
        public mType OperatorType;
        public MathItem Left;
        public MathItem Right;
        public override string ToString()
        {
            string result = "";
            result += Left.ToString();
            switch (OperatorType)
            {
                case mType.add:
                    result += "+";
                    break;
                case mType.subtract:
                    result += "-";
                    break;
                case mType.multiply:
                    result += "x";
                    break;
                case mType.divide:
                    result += '/';
                    break;
                default:
                    result = "SOMETHING WENT WRONG!";
                    return result;
            }
            result += Right.ToString();
            return result;
        }
    }
}