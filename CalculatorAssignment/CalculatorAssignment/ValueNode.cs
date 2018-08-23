using System;

namespace CalculatorAssignment
{
    public class ValueNode : MathNode
    {
        public double Value;
        public enum valuetype { none, Euro, Percentage }
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
            // Get the Raw Value
            double rawValue = a.Value + b.Value;
            ValueNode result = GetConvertedValue(a.Valuetype, b.Valuetype,rawValue);
            return result;
        }
        public static ValueNode operator -(ValueNode left, ValueNode right)
        {
            double RawValue = left.Value - right.Value;
            ValueNode result = GetConvertedValue(left.Valuetype, right.Valuetype,RawValue);
            return result;
        }
        public static ValueNode operator *(ValueNode left, ValueNode right)
        {
            double RawValue = left.Value * right.Value;
            ValueNode Result = GetConvertedValue(left.Valuetype, right.Valuetype, RawValue);
            return Result;
        }
        public static ValueNode operator /(ValueNode left, ValueNode right)
        {
            if (right.Value ==0)
            {
                throw new DivideByZeroException();
            }
            double RawValue = left.Value / right.Value;
            ValueNode Result = GetConvertedValue(left.Valuetype, right.Valuetype, RawValue);
            return Result;
        }
        private static ValueNode GetConvertedValue(valuetype a, valuetype b,double newvalue)
        {
            double ResultValue = newvalue;
            valuetype ResultValueType = valuetype.none;
            if (BothArePercentageValues(a, b))
            {
                ResultValueType = valuetype.Percentage;
            }
            if (OnlyOneIsAPercentageValue(a, b))
            {
                ResultValue = ResultValue * 0.01;
                ResultValueType = valuetype.none;
            }
            if (OnlyOneIsValutaValue(a, b)) {
                ResultValueType = valuetype.Euro;
            }
            ValueNode Result = new ValueNode(ResultValue) { Valuetype = ResultValueType };
            return Result;
        }

        private static bool OnlyOneIsValutaValue(valuetype a, valuetype b)
        {
            return a == valuetype.Euro & b != valuetype.none;
        }

        private static bool OnlyOneIsAPercentageValue(valuetype a, valuetype b)
        {
            return a == valuetype.Percentage ^ b == valuetype.Percentage;
        }

        private static bool BothArePercentageValues(valuetype a, valuetype b)
        {
            return a == valuetype.Percentage & b == valuetype.Percentage;
        }

        public override string ToString()
        {
            string result = "";
            if (Valuetype == valuetype.Euro)
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
            if (Valuetype != objEval.Valuetype)
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