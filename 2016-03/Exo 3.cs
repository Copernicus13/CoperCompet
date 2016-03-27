using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleDev._2016_03
{
    public class Exo3
    {
        public Exo3()
        {
            int n = int.Parse(Console.ReadLine());
            IList<int> list = new List<int>();
            IList<string> str = new List<string>();
            IList<string> str2 = new List<string>();

            string line = Console.ReadLine();
            for (int i = 0; i < n; ++i)
                list.Add(int.Parse(line.Split(' ')[i]));

            for (int i = 0; i < list.Sum(); ++i)
                str.Add(Console.ReadLine());

            int q = int.Parse(Console.ReadLine());

            for (int i = 0; i < q; ++i)
                str2.Add(Console.ReadLine());

            int res = 0;
            IList<string> all = new List<string>();

            foreach (var a in str.Take(list[0]).ToList())
                foreach (var b in str.Skip(list[0]).Take(list[1]).ToList())
                    foreach (var c in str.Skip(list[0] + list[1]).Take(list[2]).ToList())
                    {
                        if (n > 3)
                        {
                            foreach (var d in str.Skip(list[0] + list[1] + list[2]).Take(list[3]).ToList())
                            {
                                if (n > 4)
                                {
                                    foreach (var e in str.Skip(list[0] + list[1] + list[2] + list[3]).Take(list[4]).ToList())
                                    {
                                        all.Add(string.Format("{0} {1} {2} {3} {4}", a, b, c, d, e));
                                    }
                                }
                                else
                                {
                                    all.Add(string.Format("{0} {1} {2} {3}", a, b, c, d));
                                }
                            }
                        }
                        else
                        {
                            all.Add(string.Format("{0} {1} {2}", a, b, c));
                        }
                    }

            foreach (var t in str2)
                if (all.Contains(t))
                    ++res;

            Console.WriteLine(res);
        }
    }
}
