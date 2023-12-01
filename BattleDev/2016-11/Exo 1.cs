using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleDev._2016_11
{
    public class Exo1
    {
        public Exo1()
        {
            int N = int.Parse(Console.ReadLine());

            IList<string> s = new List<string>();
            for (int i = 0; i < N; ++i)
                s.Add(Console.ReadLine());

            s = s.OrderBy(o => o).ToList();
            int cpt = 0;

            string last = string.Empty;
            for (int j = 0; j < N; ++j)
            {
                if (last == s[j])
                {
                    ++cpt;
                    last = string.Empty;
                }
                else
                    last = s[j];
            }

            Console.WriteLine(cpt);
        }
    }
}
