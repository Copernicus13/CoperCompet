using System;
using System.Security.Cryptography;
using System.Text;
using AdventOfCode.Common;

namespace AdventOfCode._2015
{
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
