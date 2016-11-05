using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleDev._2015_03
{
    public class Exo5
    {
        public Exo5()
        {
            var stack = new Stack<int>();

            var expression = Console.ReadLine();

            foreach (string c in expression.Split(' ').Reverse())
            {
                int n;
                if (!int.TryParse(c, out n))
                {
                    int x = stack.Pop();
                    int y = stack.Pop();
                    if (c == "+")
                        n = x + y;
                    else if (c == "-")
                        n = x - y;
                    else if (c == "*")
                        n = x * y;
                    else if (c == "/")
                        n = Convert.ToInt32(Math.Floor(Convert.ToDecimal(x) / y));
                }
                stack.Push(n);
            }

            Console.WriteLine(stack.Peek());
        }
    }
}
