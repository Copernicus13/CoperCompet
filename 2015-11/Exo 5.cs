using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleDev._2015_11
{
    public class Exo5
    {
        public Exo5()
        {
            string line = Console.ReadLine();

            int res = line.Length;
            for (int i = 1; i < line.Length; ++i)
                if (string.Join(string.Empty, Enumerable.Repeat(line.Substring(0, i), line.Length / i)) == line)
                {
                    Console.WriteLine(i);
                    break;
                }
        }
    }
}
