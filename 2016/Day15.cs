using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode._2016
{
    public class Day15
    {
        public Day15(Part p)
        {
            IList<Func<int, bool>> slotsMachine = new List<Func<int, bool>>()
                {
                    new Func<int, bool>(t => (t + 16) % 17 == 0),
                    new Func<int, bool>(t => (t + 4) % 3 == 0),
                    new Func<int, bool>(t => (t + 7) % 19 == 0),
                    new Func<int, bool>(t => (t + 6) % 13 == 0),
                    new Func<int, bool>(t => (t + 7) % 7 == 0),
                    new Func<int, bool>(t => (t + 6) % 5 == 0)
                };

            if (p == Part.Part2)
                slotsMachine.Add(new Func<int, bool>(t => (t + 7) % 11 == 0));

            for (int i = 0; i < int.MaxValue; ++i)
                if (slotsMachine.All(a => a.Invoke(i)))
                {
                    Console.WriteLine(i);
                    return;
                }
        }
    }
}
