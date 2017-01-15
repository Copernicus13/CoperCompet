using System;
using System.Text;

namespace AdventOfCode._2015
{
    /// <summary>
    /// http://adventofcode.com/2015/day/10
    /// </summary>
    public class Day10
    {
        public Day10(Part p)
        {
            string line = Console.ReadLine();
            int nbTimes = p == Part.Part1 ? 40 : 50;
            for (int i = 0; i < nbTimes; ++i)
            {
                line = lookAndSay(line);
            }

            Console.WriteLine(line.Length);
        }

        private string lookAndSay(string input)
        {
            StringBuilder result = new StringBuilder();
            int actualCpt = 0;
            char actualChar = '\0';
            for (int i = 0; i < input.Length; ++i)
            {
                if (input[i] != actualChar)
                {
                    if (actualChar != '\0')
                        result.AppendFormat("{0}{1}", actualCpt, actualChar);
                    actualChar = input[i];
                    actualCpt = 1;
                }
                else
                    ++actualCpt;
            }
            result.AppendFormat("{0}{1}", actualCpt, actualChar);
            return result.ToString();
        }
    }
}
