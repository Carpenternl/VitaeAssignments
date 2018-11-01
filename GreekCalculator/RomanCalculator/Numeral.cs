using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanCalculator
{
    public static class Numeral
    {
        public static int[] IntegerValues = { 1, 5, 10, 50, 100, 500, 1000 };
        public static char[] CharacterValues = { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };

        /// <summary>
        /// Convert an integer to a POSITIVE roman numeral
        /// </summary>
        public static string ToString(int value)
        {
            int AbsValue = Math.Abs(value);
            char[] RomanNumerals = GetRomanNumerals(AbsValue);
            string RomanNumeralString = Formatted(RomanNumerals);
            return RomanNumeralString;
        }
        /// <summary>
        /// converts an int to an unformatted roman numeral 439 => CCCCXXXVIIII
        /// </summary>
        private static char[] GetRomanNumerals(int value)
        {
            List<char> RomValues = new List<char>();
            while (value > 0)
            {
                for (int i = IntegerValues.Length - 1; i >= 0; i--)
                {
                    while (IntegerValues[i] <= value)
                    {
                        RomValues.Add(ToCharacter(IntegerValues[i]));
                        value -= IntegerValues[i];
                    }
                }
            }
            return RomValues.ToArray();
        }
        /// <summary>
        /// Formats an unformatted roman numeral CCCCXXXVIIII(439) => CDXXXIX
        /// </summary>
        private static string Formatted(char[] roms)
        {
            List<int> intvalues = new List<int>();
            // Extract the integer Values;
            for (int i = 0; i < roms.Length; i++)
            {
                intvalues.Add(ToInt(roms[i].ToString()));
            }
            // Converts CCCCXXXVIIII => CDXXXVIV
            Remove4Pairs(roms, intvalues);
            // Converts CDXXXVIV => CDXXXIX
            CleanupPass(roms, intvalues);
            // Build the string
            StringBuilder strngBldr = new StringBuilder();
            foreach (int item in intvalues)
            {
                strngBldr.Append(ToCharacter(item));
            }
            return strngBldr.ToString();

        }
        
        private static void CleanupPass(char[] roms, List<int> intvalues)
        {
            for (int i = 0; i < intvalues.Count - 2; i++)
            {
                if (roms[i] != 'M')
                {
                    Removesplits(intvalues, i);
                }
            }
        }
        /// <summary>
        /// Converts CCCCXXXVIIII => CDXXXVIV
        /// </summary>
        private static void Remove4Pairs(char[] roms, List<int> intvalues)
        {
            for (int i = 0; i < intvalues.Count - 3; i++)
            {
                if (roms[i] != 'M')
                {
                    FindFourInARow(intvalues, i);
                }
            }
        }

        private static void FindFourInARow(List<int> intvalues, int i)
        {
            if (intvalues[i] == intvalues[i + 1] & intvalues[i + 2] == intvalues[i + 3] & intvalues[i] == intvalues[i + 2])
            {
                char c = ToCharacter(intvalues[i]);
                char n = Shift(c);

                intvalues[i + 1] = ToInt(n);
                intvalues.RemoveRange(i + 2, 2);
            }
        }
        private static void Removesplits(List<int> list, int i)
        {
            if (list[i] == list[i + 2] & list[i]> list[i+1])
            {
                char c = ToCharacter(list[i]);
                char n = Shift(c);
                list[i + 2] = n;
                list.RemoveAt(i);
            }
        }
        private static char Shift(char c)
        {
            int key = CharacterValues.ToList().IndexOf(c);
            return CharacterValues[key + 1];
        }




        /// <summary>
        /// Convert a roman numeral string to an integer
        /// </summary>
        public static int ToInt(string value)
        {
            // 1: set to uppercase
            string UpperCaseValue = value.ToUpper();
            string ValidString = RemoveInvalidChars(UpperCaseValue, "MDCLXVI");
            int[] NumeralValues = ToInteger(ValidString);
            if (ValidFormat(NumeralValues))
            {
                int myResult = 0;
                for (int i = 0; i < NumeralValues.Length; i++)
                {
                    int Current = NumeralValues[i];
                    if (i < NumeralValues.Length - 1)
                    {
                        int Next = NumeralValues[i + 1];
                        if (Current < Next)
                        {
                            myResult -= Current;
                            continue;
                        }
                    }
                    myResult += Current;
                }
                return myResult;
            }
            else
            {
                return 0;
            }
        }

        private static bool ValidFormat(int[] numeralValues)
        {
            for (int i = 0; i < numeralValues.Length - 2; i++)
            {
                int a = numeralValues[i];
                int b = numeralValues[i + 1];
                int c = numeralValues[i + 2];
                if (!(a >= b & a >= c))
                {
                    return false;
                }
            }
            return true;
        }

        private static int[] ToInteger(string validString)
        {
            List<int> values = new List<int>();
            foreach (var c in validString)
            {
                values.Add(ToInt(c));
            }
            return values.ToArray();
        }

        private static string RemoveInvalidChars(string value, string compareables)
        {
            StringBuilder Result = new StringBuilder();
            foreach (char c in value)
            {
                if (compareables.Contains(c))
                {
                    Result.Append(c);
                }
            }
            return Result.ToString();
        }

        private static void ShowError(string value)
        {
            ValueWarningWindow w = new ValueWarningWindow();
            w.ErrorMessage.Content = $"entered Value: {value} is invalid";
            w.ShowDialog();
        }

        private static char ToCharacter(int value)
        {
            int Key = IntegerValues.ToList().IndexOf(value);
            return CharacterValues[Key];
        }
        private static int ToInt(char value)
        {
            int Key = CharacterValues.ToList().IndexOf(value);
            return IntegerValues[Key];
        }
    }
}
