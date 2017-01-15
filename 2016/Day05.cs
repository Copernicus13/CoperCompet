using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode._2016
{
    /// <summary>
    /// http://adventofcode.com/2016/day/5
    /// </summary>
    public class Day05
    {
        public Day05(Part p)
        {
            string line = Console.ReadLine();
            long cpt = 1;
            char[] res = new char[8];

            using (var md5 = MD5.Create())
            {
                for (int i = 0; i < 8; ++i)
                {
                    while (++cpt < long.MaxValue)
                    {
                        string hash = BitConverter.ToString(md5.ComputeHash(
                            Encoding.ASCII.GetBytes(string.Format("{0}{1}", line, cpt))))
                            .Replace("-", string.Empty);
                        if (hash.StartsWith("00000"))
                        {
                            if (p == Part.Part1)
                            {
                                res[i] = hash[5];
                                break;
                            }
                            else if (p == Part.Part2)
                            {
                                int pos = int.Parse(hash.Substring(5, 1), NumberStyles.AllowHexSpecifier);
                                if (pos < 8 && res[pos] == '\0')
                                {
                                    res[pos] = hash[6];
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine(res);
        }
    }
}
