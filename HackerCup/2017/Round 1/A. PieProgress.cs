using System;
using System.Collections.Generic;
using System.Linq;
using CoperAlgoLib.Data;

namespace HackerCup._2017.Round1
{
    public class PieProgress
    {
        private int[,] _Tab;

        public PieProgress()
        {
            int T = int.Parse(Console.ReadLine());
            for (int nbCase = 1; nbCase <= T; ++nbCase)
            {
                var param = Console.ReadLine().Split(' ');
                int N = int.Parse(param[0]);
                int M = int.Parse(param[1]);

                _Tab = new int[N, M];
                for (int i = 0; i < N; ++i)
                {
                    param = Console.ReadLine().Split(' ');
                    for (int j = 0; j < param.Length; ++j)
                        _Tab[i, j] = int.Parse(param[j]);
                }

                long[,] costsPerDay = new long[N, M];
                for (int i = 0; i < N; ++i)
                {
                    var list = _Tab.GetRow(i).ToList();
                    list.Sort();
                    costsPerDay[i, 0] = list[0] + 1;
                    for (int j = 1; j < M; ++j)
                        costsPerDay[i, j] = list[j] + (j + 1) * (j + 1) - j * j;
                }
                long res = Calc(costsPerDay.ToList(), N, M);
                Console.WriteLine(string.Format("Case #{0}: {1}", nbCase, res));
            }
        }

        private long Calc(IList<long> costsPerDay, int N, int M)
        {
            long res = costsPerDay[0];
            costsPerDay[0] = long.MaxValue;
            for (int i = 1; i < N; ++i)
            {
                var precMin = costsPerDay.Take(M * i).Min();
                res += Math.Min(precMin, costsPerDay[M * i]);
                if (precMin < costsPerDay[M * i])
                    costsPerDay[costsPerDay.IndexOf(precMin)] = long.MaxValue;
                else
                    costsPerDay[M * i] = long.MaxValue;
            }
            return res;
        }
    }
}
