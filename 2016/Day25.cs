using System;
using System.Collections.Generic;
using AdventOfCode.Common;

namespace AdventOfCode._2016
{
    public class Day25
    {
        private readonly IDictionary<string, int> _Dict;

        public Day25(Part p)
        {
            IList<string> instr = new List<string>();
            for (string line; !string.IsNullOrEmpty(line = Console.ReadLine()); instr.Add(line))
                ;

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
                    Console.WriteLine(a);
                    break;
                }
            }
        }

        private int getOperand(string v)
        {
            int res;
            return int.TryParse(v, out res) ? res : _Dict[v];
        }
    }
}
