using System;
using AdventOfCode.Common;

namespace AdventOfCode._2015
{
    public class Day08
    {
        public Day08(Part p)
        {
            string line;
            int result = 0;
            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
            {
                if (p == Part.Part1)
                {
                    result += line.Length;
                    int retrench = line.Length - 2;
                    for (int i = 1; i < line.Length - 2; ++i)
                        if (line[i] == '\\')
                        {
                            if (line[i + 1] == 'x')
                            {
                                i += 2;
                                retrench -= 2;
                            }
                            ++i;
                            --retrench;
                        }
                    result -= retrench;
                }
                else if (p == Part.Part2)
                {
                    int add = line.Length + 2;
                    for (int i = 0; i < line.Length; ++i)
                        if (line[i] == '"' || line[i] == '\\')
                            ++add;
                    result += add - line.Length;
                }
            }
            Console.WriteLine(result);
        }
    }
}
