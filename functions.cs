using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkHelper
{
    class functions
    {
        public static int Multiply(int num1, int num2)
        {
            return num1 * num2;
        }
        public static int Divide(int num1, int num2)
        {
            return num1 / num2;
        }
        public static int Add(int num1, int num2)
        {
            return num1 + num2;
        }
        public static int Subtract(int num1, int num2)
        {
            return num1 - num2;
        }
        public static int Solve(int num1, int num2, string op)
        {
            switch (op)
            {
                case "*":
                    return Multiply(num1, num2);

                case "x":
                    return Multiply(num1, num2);

                case "/":
                    return Divide(num1, num2);

                case "-":
                    return Subtract(num1, num2);

                case "+":
                    return Add(num1, num2);

                default:
                    return 0;
            }
        }
    }
}
