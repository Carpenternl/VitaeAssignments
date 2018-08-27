namespace Calculator_Console
{
    class MathValue : MathItem
    {
        public enum ValueType
        {
            none,valuta,Percentage
        }
        public override MathValue Solve()
        {
            return this;
        }
        public override string ToString()
        {
            string Result = "";
            return "VALUETYPESTRINGNOTIMPLEMENTEDYET";
            
        }
    }
}