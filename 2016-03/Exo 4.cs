using System;
using System.Collections.Generic;

namespace BattleDev._2016_03
{
    public class Exo4
    {
        public Exo4()
        {
            int n = int.Parse(Console.ReadLine());
            IList<int> list = new List<int>();

            for (int i = 0; i < n; ++i)
                list.Add(int.Parse(Console.ReadLine()));

            for (int i = 0; i < n; ++i)
            {
                int res = 0;
                int big1 = 0;
                int big2 = 0;
                for (int j = i - 1; j >= 0; --j)
                {
                    if (list[j] > big1)
                        ++res;
                    big1 = Math.Max(list[j], big1);
                }
                for (int j = i + 1; j < n; ++j)
                {
                    if (list[j] > big2)
                        ++res;
                    big2 = Math.Max(list[j], big2);
                }
                Console.WriteLine(res);
            }
        }
    }
}
