using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleDev._2017_03
{
    public class Exo2
    {
        public Exo2()
        {
            var t = new List<int>();
            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; ++i)
            {
                t.Add(int.Parse(Console.ReadLine()));
            }
            t = t.OrderBy(o => o).ToList();
            Console.WriteLine(t.Last() - t.First());
        }
    }
}
