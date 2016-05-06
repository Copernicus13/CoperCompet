using System;
using System.Collections.Generic;
using System.Linq;

namespace GoogleCodeJam.Y2016.Round1a
{
    public class RankAndFile
    {
        public RankAndFile()
        {
            int T = int.Parse(Console.ReadLine());

            for (int nbCase = 1; nbCase <= T; ++nbCase)
            {
                int N = int.Parse(Console.ReadLine());

                IList<int> list = new List<int>();
                for (int i = 0; i < 2 * N - 1; ++i)
                {
                    string s = Console.ReadLine();
                    for (int c = 0; c < N; ++c)
                        list.Add(int.Parse(s.Split(' ')[c]));
                }

                var res = list.GroupBy(c => c)
                    .Where(grp => grp.Count() %2 == 1)
                    .OrderBy(grp => grp.Key)
                    .Select(grp => grp.Key)
                    .ToList();

                Console.WriteLine(string.Format("Case #{0}: {1}", nbCase, string.Join(" ", res)));
            }
        }

        //public class MyComparer : IComparer<string>
        //{
        //    public int Compare(string x, string y)
        //    {
        //        for (int i = 0; i < x.Split(' ').Length; ++i)
        //            if (!EqualityComparer<int>.Default.Equals(int.Parse(x.Split(' ')[i]), int.Parse(y.Split(' ')[i])))
        //                return Comparer<int>.Default.Compare(int.Parse(x.Split(' ')[i]), int.Parse(y.Split(' ')[i]));

        //        return 0;
        //    }
        //}
    }
}
