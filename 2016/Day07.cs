using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode._2016
{
    /// <summary>
    /// http://adventofcode.com/2016/day/7
    /// </summary>
    public class Day07
    {
        public Day07(Part p)
        {
            string line;
            int cpt = 0;
            IList<string> list = new List<string>();
            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
                list.Add(line);

            if (p == Part.Part1)
            {
                foreach (string s in list)
                    if (SupportTLS(s))
                        ++cpt;
            }

            else if (p == Part.Part2)
            {
                foreach (string s in list)
                    if (SupportSSL(s))
                        ++cpt;
            }

            Console.WriteLine(cpt);
        }

        private bool SupportTLS(string s)
        {
            bool result = false;
            bool isInsideBrackets = false;
            for (int i = 0; i < s.Length - 3; ++i)
            {
                if (s[i] == '[')
                    isInsideBrackets = true;
                else if (s[i] == ']')
                    isInsideBrackets = false;
                if (s[i] == s[i + 3] && s[i + 1] == s[i + 2] && s[i] != s[i + 1])
                {
                    if (!isInsideBrackets)
                        result = true;
                    else
                        return false;
                }
            }
            return result;
        }

        private bool SupportSSL(string s)
        {
            IList<string> areaBroadcastAccessor = new List<string>();
            IList<string> byteAllocationBlock = new List<string>();
            bool isInsideBrackets = false;
            for (int i = 0; i < s.Length - 2; ++i)
            {
                if (s[i] == '[')
                    isInsideBrackets = true;
                else if (s[i] == ']')
                    isInsideBrackets = false;
                if (s[i] == s[i + 2] && s[i + 1] != s[i + 2])
                {
                    if (!isInsideBrackets)
                        areaBroadcastAccessor.Add(s.Substring(i, 3));
                    else
                        byteAllocationBlock.Add(s.Substring(i, 3));
                }
            }
            foreach (string str in areaBroadcastAccessor)
            {
                var sb = new StringBuilder();
                sb.AppendFormat("{1}{0}{1}", str[0], str[1]);
                if (byteAllocationBlock.Contains(sb.ToString()))
                    return true;
            }
            return false;
        }
    }
}
