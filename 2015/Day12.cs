using System;
using AdventOfCode.Common;

namespace AdventOfCode._2015
{
    public class Day12
    {
        public Day12(Part p)
        {
            string line = Console.ReadLine();
            long result = 0;
            if (p == Part.Part1)
            {
                var toCalc = line.Split('{', '}', '[', ']', ':', ',');
                foreach (var t in toCalc)
                {
                    int tmp;
                    if (!string.IsNullOrEmpty(t) && int.TryParse(t, out tmp))
                        result += tmp;
                }
            }
            else if (p == Part.Part2)
            {
                int length;
                result = CalcIt(line, out length);
            }
            Console.WriteLine(result);
        }

        private long CalcIt(string line, out int length)
        {
            long result = 0;
            int cptArray = 0;
            int currentNumber = 0;
            bool minus = false;
            bool isObject = false;
            if (line[0] == '{')
                isObject = true;
            for (int i = 1; i < line.Length; ++i)
            {
                if (line[i] == '-')
                    minus = true;
                else if (char.IsDigit(line[i]))
                    currentNumber = currentNumber * 10 + int.Parse(line[i].ToString());
                else
                {
                    if (currentNumber != 0)
                    {
                        result += minus ? -currentNumber : currentNumber;
                        currentNumber = 0;
                    }
                    minus = false;
                }
                if (line[i] == ']')
                    --cptArray;
                if (line[i] == '[')
                    ++cptArray;
                else if (line[i] == '{')
                {
                    int newI;
                    result += CalcIt(line.Substring(i), out newI);
                    i += newI;
                }
                else if (line[i] == '}' || line[i] == ']' && cptArray == -1)
                {
                    length = i;
                    return result;
                }
                else if (line[i] == 'r' && line[i + 1] == 'e' && line[i + 2] == 'd' &&
                    cptArray == 0 && isObject)
                {
                    int cptObj = 0;
                    for (; i < line.Length; ++i)
                    {
                        if (line[i] == '{')
                            ++cptObj;
                        else if (line[i] == '}')
                            --cptObj;
                        if (cptObj == -1)
                            break;
                    }
                    length = i;
                    return 0;
                }
            }
            length = 0;
            return 0;
        }
    }
}
