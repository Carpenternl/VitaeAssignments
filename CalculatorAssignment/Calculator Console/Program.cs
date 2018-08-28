using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Calculator_Console.MathValue;

namespace Calculator_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            ProblemSolver s = new ProblemSolver();
            MathValue a = new MathValue();
            MathValue b = new MathValue();
            for (int i = 0; i < 3; i++)
            {
                        a._valType = (Valtype) i;
                for (int j = 0; j < 3; j++)
                {
                        b._valType = (Valtype) j;
                    for (int k = 60; k < 150; k +=( 20 + new Random().Next(5, 10)))
                    {
                        a.Value = k;
                        for (int l = 58; l < 150; l += (20 + new Random().Next(5,10)))
                        {
                            b.Value = l;
                            Console.WriteLine($" {a.ToString().PadRight(5,' ')} + {b.ToString().PadRight(5,' ')} = { a + b}");
                            Console.WriteLine($" {a.ToString().PadRight(5, ' ')} - {b.ToString().PadRight(5, ' ')} = { a - b}");
                            Console.WriteLine($" {a.ToString().PadRight(5, ' ')} / {b.ToString().PadRight(5, ' ')} = { a / b}");
                            Console.WriteLine($" {a.ToString().PadRight(5, ' ')} * {b.ToString().PadRight(5, ' ')} = { a * b}");
                        }
                    }
                }
            }
            Console.ReadLine();
        }
        
    }
}
