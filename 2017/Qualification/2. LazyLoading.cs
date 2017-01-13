using System;
using System.Linq;
using HackerCup.Common.Data;

namespace HackerCup._2017.Qualification
{
    public class LazyLoading
    {
        public LazyLoading()
        {
            int T = int.Parse(Console.ReadLine());
            for (int nbCase = 1; nbCase <= T; ++nbCase)
            {
                int N = int.Parse(Console.ReadLine());
                var weights = new Deque<int>();
                for (int cpt = 0; cpt < N; ++cpt)
                    weights.Add(int.Parse(Console.ReadLine()));

                int res = weights.Count(c => c >= 50);
                weights.RemoveAll(r => r >= 50);
                weights.Sort((a, b) => a > b ? -1 : a == b ? 0 : 1);
                while (weights.Any())
                {
                    ++res;
                    int actual = weights.PopFront();
                    int cpt = actual;
                    while (cpt < 50 && weights.Any())
                    {
                        cpt += actual;
                        weights.PopBack();
                    }
                    if (!weights.Any() && cpt < 50)
                        --res;
                }
                Console.WriteLine(string.Format("Case #{0}: {1}", nbCase, res));
            }
        }
    }
}
