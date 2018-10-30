using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanCalculator
{
    public static class Numeral
    {
        public enum Romans { I = 1, V = 5, X = 10, L = 50, C = 100, D = 500, M = 1000 }
        public static readonly Romans[] Possible = { Romans.I, Romans.V, Romans.X, Romans.L, Romans.C, Romans.D, Romans.M };
        public static char[] DataString = { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };
        public static int[] PossibleValue = { 1, 5, 10, 50, 100, 500, 1000 };

        //Convert an integer to a string
        public static string ToString(int value)
        {
            List<int> intValues = new List<int>();
            // 1. get The Absolute value, to make conversion easier;
            int AbsValue = Math.Abs(value);
            // 2. Peform a basic Conversion Pass
            Romans[] RomanValues = RawConvert(AbsValue);
            Romans[] FormattedRomanValues = FormatRomans(RomanValues);
            StringBuilder d = new StringBuilder();
            foreach (var item in FormattedRomanValues)
            {
                d.Append(item);
            }
            return d.ToString();
        }

        private static Romans[] FormatRomans(Romans[] romanValues)
        {
            romanValues = RemoveSetPatterns(romanValues);
            romanValues = RemoveSplitPatterns(romanValues);
            return romanValues;
        }

        private static Romans[] RemoveSplitPatterns(Romans[] romanValues)
        {
            List<Romans> Result = romanValues.ToList();
            for (int Index = 1; Index < Result.Count - 1; Index++)
            {
                if (FourPlusFive(Result[Index - 1], Result[Index], Result[Index + 1]))
                {
                    int Key = Possible.ToList().IndexOf(Result[Index + 1]);
                    if (Key < PossibleValue.Length - 1)
                    {
                        Result[Index + 1] = Possible[Key + 1];
                        Result.RemoveAt(Index - 1);
                    }
                }
            }
            return Result.ToArray();
        }

        private static bool FourPlusFive(Romans romans1, Romans romans2, Romans romans3)
        {
            if (romans1 == romans3 & romans2 != romans1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static Romans[] RemoveSetPatterns(Romans[] romanValues)
        {
            List<Romans> Result = romanValues.ToList();
            for (int i = 3; i < Result.Count; i++)
            {
                if (FourInARow(Result, i))
                {
                    //Set found, get value
                    int valueKey = Possible.ToList().IndexOf(Result[i]);
                    if (valueKey < PossibleValue.Length - 1)
                    {
                        Result[i] = Possible[valueKey + 1];
                        Result.RemoveRange(i - 2, 2);
                    }
                }
            }
            return Result.ToArray();
        }

        private static bool FourInARow(List<Romans> Result, int i)
        {
            return Result[i] == Result[i - 1] & Result[i - 2] == Result[i - 3] & Result[i] == Result[i - 2];
        }

        private static Romans[] RawConvert(int absValue)
        {
            List<Romans> Result = new List<Romans>();

            while (absValue > 0)
            {
                for (int Key = PossibleValue.Length - 1; Key >= 0; Key--)
                {
                    while (PossibleValue[Key] <= absValue)
                    {
                        Result.Add((Romans)PossibleValue[Key]);
                        absValue -= PossibleValue[Key];
                    }
                }
            }
            return Result.ToArray();
        }

        private static Romans[] RawConvert(char[] workableCharacters)
        {
            List<Romans> Result = new List<Romans>();
            for (int i = 0; i < workableCharacters.Length; i++)
            {
                char item = workableCharacters[i];
                int itemKey = DataString.ToList().IndexOf(item);
                Result.Add(Possible[itemKey]);
            }
            return Result.ToArray();
        }
        public static int ToInt(string value)
        {
            // 1: Get our characters
            char[] characters = value.ToCharArray();
            // 2: Remove invalid Characters
            char[] WorkableCharacters = RemoveInvalidCharacters(characters);
            // 3: Convert To Roman Characters
            Romans[] RomanCharacters = RawConvert(WorkableCharacters);
            // 4: Simplyfy Roman Characters (Remove character overuse)
            RomanCharacters = Simplify(RomanCharacters);
            foreach (var item in RomanCharacters)
            {
                Console.Write(item.ToString());
            }
            Console.Write("\n");
            return 0;
            
        }

        private static Romans[] Simplify(Romans[] romanCharacters)
        {
            List<Romans> Result = romanCharacters.ToList();
            int Offset = 1;
            // TODO
            return Result.ToArray();
        }

        private static Romans[] Replace(int Amount, Romans newNum)
        {
            Romans[] Result = new Romans[Amount];
            for (int Index = 0; Index < Amount; Index++)
            {
                Result[Index] = newNum;
            }
            return Result;
        }

        private static char[] RemoveInvalidCharacters(char[] characters)
    {
        List<Char> Result = new List<char>();
        for (int i = 0; i < characters.Length; i++)
        {
            if (DataString.Contains(characters[i]))
            {
                Result.Add(characters[i]);
            }
        }
        return Result.ToArray();
    }
}
}
