using System;
using System.Collections.Generic;

namespace GoogleCodeJam._2022.Qualification
{
    public class d1000000
    {
        public d1000000()
        {
            int T = int.Parse(Console.ReadLine());

            for (int nbCase = 1; nbCase <= T; ++nbCase)
            {
                int N = int.Parse(Console.ReadLine());
                var S = new SortedSet<int>(new DuplicateKeyAllowedComparer<int>());
                var numbers = Console.ReadLine().Split(' ');
                for (int i = 0; i < N; ++i)
                    S.Add(int.Parse(numbers[i]));

                int result = 0;
                foreach (var d in S)
                    if (result < d)
                        ++result;

                Console.WriteLine($"Case #{nbCase}: {result}");
            }
        }

        public class DuplicateKeyAllowedComparer<TKey> : IComparer<TKey> where TKey : IComparable
        {
            public int Compare(TKey x, TKey y)
            {
                int result = x.CompareTo(y);     // Handle equality as being greater. Note: this will break Remove(key) or
                return result == 0 ? 1 : result; // IndexOfKey(key) since the comparer never returns 0 to signal key equality
            }
        }
    }
}
