using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode._2016
{
    /// <summary>
    /// http://adventofcode.com/2016/day/14
    /// </summary>
    public class Day14
    {
        private IDictionary<string, string> dictHash = new Dictionary<string, string>();

        public Day14(Part p)
        {
            string salt = Console.ReadLine();
            int cpt = 0;
            using (var md5 = MD5.Create())
            {
                for (int i = 0; i < int.MaxValue; ++i)
                {
                    string hash = CalcMd5(md5, p, string.Format("{0}{1}", salt, i));
                    char c;
                    if (hasTripleLetters(hash, out c))
                    {
                        for (int j = i + 1; j <= i + 1000; ++j)
                        {
                            hash = CalcMd5(md5, p, string.Format("{0}{1}", salt, j));
                            if (hash.Contains(new string(c, 5)))
                            {
                                ++cpt;
                                if (cpt == 64)
                                {
                                    Console.WriteLine(i);
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }

        private static bool hasTripleLetters(string line, out char c)
        {
            for (int i = 2; i < line.Length; ++i)
                if (line[i] == line[i - 2] && line[i] == line[i - 1])
                {
                    c = line[i];
                    return true;
                }
            c = '\0';
            return false;
        }

        private string CalcMd5(MD5 md5, Part p, string val)
        {
            if (!dictHash.ContainsKey(val))
            {
                string hash = val;
                int nbIteration = p == Part.Part1 ? 1 : 2017;
                for (int i = 0; i < nbIteration; ++i)
                    hash = BitConverter.ToString(md5.ComputeHash(
                        Encoding.ASCII.GetBytes(hash.ToLowerInvariant())))
                        .Replace("-", string.Empty);
                dictHash.Add(val, hash);
            }
            return dictHash[val];
        }
    }
}
