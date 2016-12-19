using System;
using System.Collections.Generic;
using AdventOfCode.Common;

namespace AdventOfCode._2016
{
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
                stolen = GetNext(thief);
            else if (p == Part.Part2)
                stolen = list.Find(list.Count / 2);

            while (list.Count > 1)
            {
                var nextToDead = GetNext(stolen);
                list.Remove(stolen);
                thief = GetNext(thief);
                if (p == Part.Part1)
                    stolen = GetNext(thief);
                else if (p == Part.Part2)
                    stolen = list.Count % 2 == 0 ? GetNext(nextToDead) : nextToDead;
            }
            Console.WriteLine(list.First.Value + 1);
        }

        private LinkedListNode<int> GetNext(LinkedListNode<int> next)
        {
            return next != next.List.Last ? next.Next : next.List.First;
        }
    }
}