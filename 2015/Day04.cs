using System;
using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode._2015
{
    /// <summary>
    /// http://adventofcode.com/2015/day/4
    /// </summary>
    public class Day04
    {
        public Day04(Part p)
        {
            string line = Console.ReadLine();
            long result;
            string startWith = "00000";
            if (p == Part.Part2)
                startWith += "0";

            for (result = 1; ; ++result)
                using (var md5 = MD5.Create())
                {
                    if (BitConverter.ToString(
                            md5.ComputeHash(Encoding.ASCII.GetBytes(string.Format("{0}{1}", line, result))))
                            .Replace("-", string.Empty).StartsWith(startWith))
                        break;
                }
            Console.WriteLine(result);
        }
    }
}
