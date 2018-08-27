namespace CalculatorAssignment
{
    public class ValueNode : MathNode
    {
        double Value;
        public enum valuetype { none, Euro,Percentage}
        public valuetype Valuetype;

        public ValueNode(double value)
        {
            this.Value = value;
            Valuetype = 0;
        }
        public override ValueNode Calculate()
        {
            throw new System.NotImplementedException();
        }

        public static ValueNode operator +(ValueNode a, ValueNode b)
        {
            // Add a to b
            // step 1, add double values to new valuenode
            ValueNode result = new ValueNode(a.Value + b.Value);
            //if both are percentages, treat as normal addition
            if (a.Valuetype == valuetype.Percentage & b.Valuetype == valuetype.Percentage)
                result.Valuetype = valuetype.Percentage;
            // if only one is a percentage/ devide result by 100
            if (a.Valuetype == valuetype.Percentage ^ b.Valuetype == valuetype.Percentage)
            {
                result.Value = result.Value * 0.01;
                result.Valuetype = valuetype.none;
            }
            // if one is a Euro and the other is not a number, set valuetype to Euro
            if (a.Valuetype == valuetype.Euro & b.Valuetype != valuetype.none)
                result.Valuetype = valuetype.Euro;
            return result;

        }
        public override string ToString()
        {
            string result = "";
            if(Valuetype== valuetype.Euro)
                result += "€";
            result += Value.ToString();
            if (Valuetype == valuetype.Percentage)
                result += "%";
            return result;
        }
        // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            // TODO: write your implementation of Equals() here
            // My code
            ValueNode objEval = obj as ValueNode;
            if(Valuetype != objEval.Valuetype)
            {
                return false;
            }
            else
            {
                return true;
            }

            throw new System.NotImplementedException();
            return base.Equals(obj);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            // TODO: write your implementation of GetHashCode() here
            throw new System.NotImplementedException();
            return base.GetHashCode();
        }


    }

}