using AdventOfCode.Common;
using System;
using System.Linq;

namespace AdventOfCode._2016
{
    /// <summary>
    /// http://adventofcode.com/2016/day/16
    /// </summary>
    public class Day16
    {
        public Day16(Part p)
        {
            string input = Console.ReadLine();

            int diskLength = 0;
            if (p == Part.Part1)
                diskLength = 272;
            else if (p == Part.Part2)
                diskLength = 35651584;

            char[] diskData = new char[(diskLength << 1) + 1];

            for (int i = 0; i < input.Length; ++i)
                diskData[i] = input[i];

            for (int i = input.Length; i < diskData.Length; i += i + 1)
            {
                diskData[i] = '0';
                for (int j = i + 1, k = i - 1; k >= 0 && j < diskData.Length; ++j, --k)
                    diskData[j] = diskData[k] == '1' ? '0' : '1';
            }

            var res = diskData.Take(diskLength).ToArray();
            while ((res = produceDoubleLettersChecksum(res)).Length % 2 == 0)
                ;

            Console.WriteLine(res);
        }

        private static char[] produceDoubleLettersChecksum(char[] line)
        {
            var res = new char[line.Length >> 1];
            for (int i = 0; i < line.Length - 1; i += 2)
                if (line[i] == line[i + 1])
                    res[i >> 1] = '1';
                else
                    res[i >> 1] = '0';
            return res;
        }
    }
}
