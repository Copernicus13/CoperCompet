using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode._2021
{
    /// <summary>
    /// http://adventofcode.com/2021/day/1
    /// </summary>
    public class Day01
    {
        public Day01(Part p)
        {
            int result = 0;
            IList<int> listMeasurements = new List<int>();
            string line;
            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
                listMeasurements.Add(int.Parse(line));

            if (p == Part.Part1)
            {
                for (int i = 1; i < listMeasurements.Count; ++i)
                    if (listMeasurements[i] > listMeasurements[i - 1])
                        ++result;
            }
            else if (p == Part.Part2)
            {
                var listArray = listMeasurements.ToArray();
                for (int i = 1; i < listArray.Length - 2; ++i)
                    if (listArray[i..(i + 3)].Sum() > listArray[(i - 1)..(i + 2)].Sum())
                        ++result;
            }

            Console.WriteLine(result);
        }
    }
}
