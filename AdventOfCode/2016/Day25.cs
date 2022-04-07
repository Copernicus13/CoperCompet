using System;
using System.Collections.Generic;

namespace AdventOfCode._2016
{
    /// <summary>
    /// http://adventofcode.com/2016/day/25
    /// </summary>
    public class Day25
    {
        private IDictionary<string, int> _Dict;

        public Day25()
        {
            IList<string> instr = new List<string>();
            for (string line; !string.IsNullOrEmpty(line = Console.ReadLine()); instr.Add(line))
                ;

            Part1(instr);
            Part2();
        }

        private void Part1(IList<string> instr)
        {
            for (int a = 0; a <= int.MaxValue; ++a)
            {
                _Dict = new Dictionary<string, int>();
                _Dict["a"] = a;
                bool isOK = true;
                for (int i = 0, cpt = 0, lastOut = 1; i < instr.Count && cpt < 200 && isOK; ++i)
                {
                    var words = instr[i].Split(' ');
                    try
                    {
                        switch (words[0])
                        {
                            case "cpy":
                                _Dict[words[2]] = getOperand(words[1]);
                                break;
                            case "inc":
                                ++_Dict[words[1]];
                                break;
                            case "dec":
                                --_Dict[words[1]];
                                break;
                            case "jnz":
                                if (getOperand(words[1]) != 0)
                                    i += int.Parse(words[2]) - 1;
                                break;
                            case "out":
                                {
                                    var value = getOperand(words[1]);
                                    if (value != 0 && value != 1 || value == lastOut)
                                        isOK = false;
                                    else
                                    {
                                        lastOut = value;
                                        ++cpt;
                                    }
                                }
                                break;
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                if (isOK)
                {
                    Console.WriteLine("Part1: " + a);
                    break;
                }
            }
        }

        private void Part2()
        {
            Console.WriteLine("Part2: nothing");
        }

        private int getOperand(string v)
        {
            int res;
            return int.TryParse(v, out res) ? res : _Dict[v];
        }
    }
}
