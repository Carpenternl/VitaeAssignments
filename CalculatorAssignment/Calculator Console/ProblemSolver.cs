using System;
using System.Collections.Generic;

namespace Calculator_Console
{
    internal class ProblemSolver
    {
        List<MathItem> Problem;

        public ProblemSolver()
        {
        }

        public bool AddToProblem(MathItem newMathItem)
        {
            if (Problem == null)
            {
                Problem = new List<MathItem>();
                Problem.Add(newMathItem);
                return true;
            }
            else
            {
                return tryToAddNewMathItem(newMathItem);
            }
        }
        /// <summary>
        /// Tries to add A new MathItem to the exsisting problem
        /// </summary>
        /// <param name="newMathItem"></param>
        /// <returns></returns>
        private bool tryToAddNewMathItem(MathItem newMathItem)
        {
            if(newMathItem is MathValue)
            {
                return TrytoAddnewValueItem(newMathItem as MathValue);
            }
            else
            {
                return TrytoAddnewOperatorItem(newMathItem as MathOperator);
            }
        }

        private bool TrytoAddnewOperatorItem(MathOperator mathOperator)
        {
            throw new NotImplementedException();
        }

        private bool TrytoAddnewValueItem(MathValue mathValue)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            string result = "";
            foreach (var item in Problem)
            {
                result += item.ToString();
            }
            return result;
        }
    }
}