using System;
using System.Collections.Generic;

namespace GoogleCodeJam._2017.Qualification
{
    public class BathroomStalls
    {
        public BathroomStalls()
        {
            int T = int.Parse(Console.ReadLine());

            for (int nbCase = 1; nbCase <= T; ++nbCase)
            {
                string str = Console.ReadLine();
                long N = long.Parse(str.Split(' ')[0]);
                long K = long.Parse(str.Split(' ')[1]);

                var list = new SortedList<long, int>();
                list.AddOrIncrement(N);
                var value1 = 0L;
                var value2 = 0L;
                for (int i = 0; i < K; ++i)
                {
                    var actual = list.Keys[list.Keys.Count - 1];
                    list.DecrementOrRemove();
                    value1 = value2 = actual / 2;
                    if (actual % 2 == 0 && actual != 0)
                        --value2;
                    list.AddOrIncrement(value1);
                    list.AddOrIncrement(value2);
                }
                Console.WriteLine("Case #{0}: {1} {2}", nbCase, value1, value2);
            }
        }
    }

    public static class Extensions
    {
        public static void AddOrIncrement(this SortedList<long, int> list, long key)
        {
            if (list.ContainsKey(key))
                ++list[key];
            else
                list.Add(key, 1);
        }

        public static void DecrementOrRemove(this SortedList<long, int> list)
        {
            --list[list.Keys[list.Keys.Count - 1]];
            if (list[list.Keys[list.Keys.Count - 1]] == 0)
                list.RemoveAt(list.Keys.Count - 1);
        }
    }
}
