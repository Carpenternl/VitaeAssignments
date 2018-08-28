using System;

namespace Calculator_Console
{
    class MathValue : MathItem
    {
        public double Value;

        public enum Valtype
        {
            none, valuta, Percentage
        }
        public MathValue()
        {
            _valType = Valtype.none;
            Value = 0;
        }

        public Valtype _valType;
        public override MathValue Solve()
        {
            return this;
        }
        public override string ToString()
        {
            string Result = "";
            string valueString = Value.ToString();
            switch (_valType)
            {
                case Valtype.none:
                    break;
                case Valtype.valuta:
                    Result += "€";
                    break;
                case Valtype.Percentage:
                    Result += "%";
                    break;
                default:
                    throw new ArgumentNullException("ValueType was not identified");
            }
            Result += valueString;
            return Result;
        }
        #region OperatorOverloads
        public static MathValue operator +(MathValue a, MathValue b)
        {
            MathValue result = new MathValue();
            result.Value = a.Value + b.Value;
            DetermineValueType(a, b, result);
            return result;
        }


        public static MathValue operator -(MathValue a, MathValue b)
        {
            MathValue result = new MathValue();
            result.Value = a.Value - b.Value;
            DetermineValueType(a, b, result);
            return result;
        }
        private static void DetermineValueType(MathValue a, MathValue b, MathValue result)
        {
            if (a._valType == b._valType)
            {
                result._valType = a._valType;
            }
            if (a._valType == Valtype.valuta | b._valType == Valtype.valuta)
            {
                result._valType = Valtype.valuta;
            }
            if (a._valType == Valtype.Percentage | b._valType == Valtype.Percentage)
            {
                result._valType = Valtype.Percentage;
            }
        }
        public static MathValue operator *(MathValue a, MathValue b)
        {
            MathValue result = new MathValue();
            result.Value = a.Value * b.Value;
            if (a._valType == Valtype.Percentage ^ b._valType == Valtype.Percentage)
            {
                result.Value *= 0.01;
            }
            if (a._valType == Valtype.valuta | b._valType == Valtype.valuta)
            {
                result._valType = Valtype.valuta;
            }
            return result;
        }

        public static MathValue operator /(MathValue a, MathValue b)
        {
            if (b.Value == 0)
            {
                throw new ArgumentNullException(b.Value.ToString(), "Cannot Divide By Zero");
            }
            MathValue Result = new MathValue();
            Result.Value = a.Value / b.Value;
            if (a._valType == Valtype.Percentage ^ b._valType == Valtype.Percentage)
            {
                Result.Value /= 0.01;
            }
            if (a._valType == Valtype.valuta | b._valType == Valtype.valuta)
            {
                Result._valType = Valtype.valuta;
            }
            return Result;
        }
        #endregion

    }
}