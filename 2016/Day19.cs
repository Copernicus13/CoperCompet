using System;
using System.Collections.Generic;
using AdventOfCode.Common;
using CoperAlgoLib.Data;

namespace AdventOfCode._2016
{
    /// <summary>
    /// http://adventofcode.com/2016/day/19
    /// </summary>
    public class Day19
    {
        public Day19(Part p)
        {
            int input = int.Parse(Console.ReadLine());
            var list = new LinkedList<int>();

            for (int i = 0; i < input; ++i)
                list.AddLast(i);

            var thief = list.First;
            LinkedListNode<int> stolen = null;

            if (p == Part.Part1)
                stolen = thief.CircularNext();
            else if (p == Part.Part2)
                stolen = list.Find(list.Count / 2);

            while (list.Count > 1)
            {
                var nextToStolen = stolen.CircularNext();
                list.Remove(stolen);
                thief = thief.CircularNext();
                if (p == Part.Part1)
                    stolen = thief.CircularNext();
                else if (p == Part.Part2)
                    stolen = list.Count % 2 == 0 ? nextToStolen.CircularNext() : nextToStolen;
            }
            Console.WriteLine(list.First.Value + 1);
        }
    }
}