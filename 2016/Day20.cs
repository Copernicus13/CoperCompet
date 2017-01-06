using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;
using AdventOfCode.Common.Data;

namespace AdventOfCode._2016
{
    public class Day20
    {
        public Day20(Part p)
        {
            var blackList = new List<RangeUInt>();
            string line;
            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
                blackList.Add(new RangeUInt(
                    uint.Parse(line.Split('-')[0]),
                    uint.Parse(line.Split('-')[1])));

            while (blackList.Any())
            {
                var mergedBlackList = new List<RangeUInt>();
                for (int i = 0; i < blackList.Count; ++i)
                {
                    bool merged = false;
                    for (int j = 0; j < mergedBlackList.Count; ++j)
                    {
                        var union = mergedBlackList[j].Union(blackList[i]);
                        if (union != RangeUInt.Void)
                        {
                            merged = true;
                            mergedBlackList[j] = union;
                            break;
                        }
                    }
                    if (!merged)
                        mergedBlackList.Add(blackList[i]);
                }
                if (blackList.Count == mergedBlackList.Count)
                    break;
                blackList = mergedBlackList;
            }

            blackList.Sort((x, y) => x.Minimum.CompareTo(y.Minimum));

            uint res = default(uint);
            if (p == Part.Part1)
            {
                foreach (var range in blackList)
                {
                    if (!range.ContainsValue(res))
                        break;
                    res = range.Maximum + 1;
                }
            }
            else if (p == Part.Part2)
            {
                foreach (var range in blackList)
                    res += range.Count;
                res = uint.MaxValue - res + 1;
            }
            Console.WriteLine(res);
        }
    }
}
