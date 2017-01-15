using System;

namespace AdventOfCode._2015
{
    /// <summary>
    /// http://adventofcode.com/2015/day/11
    /// </summary>
    public class Day11
    {
        public Day11(Part p)
        {
            string line = Console.ReadLine();
            while (GetNext(ref line))
            {
                if (hasDoubleLetter(line) && has3IncreasingLetters(line) && noINorONorL(line))
                    break;
            }

            Console.WriteLine(line);
        }

        private bool GetNext(ref string line)
        {
            char[] chLine = line.ToCharArray();
            int i = chLine.Length - 1;
            for (bool carry = true; carry; --i)
            {
                if (i < 0)
                {
                    line = new string(chLine);
                    return false;
                }
                carry = chLine[i] == 'z';
                if (carry)
                    chLine[i] = 'a';
                else
                    ++chLine[i];
            }
            line = new string(chLine);
            return true;
        }

        private static bool hasDoubleLetter(string line)
        {
            char last = '\0';
            foreach (char c in line)
            {
                if (c == last)
                {
                    char last2 = '\0';
                    foreach (char d in line)
                    {
                        if (d == last2 && last2 != last)
                            return true;
                        last2 = d;
                    }
                }
                last = c;
            }

            return false;
        }

        private static bool has3IncreasingLetters(string line)
        {
            for (int i = 2; i < line.Length; ++i)
                if (line[i] == line[i - 2] + 2 && line[i] == line[i - 1] + 1)
                    return true;
            return false;
        }

        private static bool noINorONorL(string line)
        {
            for (int i = 0; i < line.Length; ++i)
                if (line[i] == 'i' || line[i] == 'o' || line[i] == 'l')
                    return false;
            return true;
        }
    }
}
