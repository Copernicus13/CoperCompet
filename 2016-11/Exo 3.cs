using System;
using System.Collections.Generic;

namespace BattleDev._2016_11
{
    public class Exo3
    {
        public struct st
        {
            public int x;
            public int y;
            public int z;
        }

        public Exo3()
        {
            int N = int.Parse(Console.ReadLine());

            var t = new List<st>();

            for (int i = 0; i < N; ++i)
            {
                string line = Console.ReadLine();
                var e = new st();
                e.x = int.Parse(line.Split(' ')[0]);
                e.y = int.Parse(line.Split(' ')[1]);
                e.z = int.Parse(line.Split(' ')[2]);
                t.Add(e);
            }

            for (int i = 0; i < t.Count; ++i)
                for (int j = 0; j < t.Count; ++j)
                {
                    if (i == j)
                        continue;
                    if (Touche(t[i], t[j]))
                    {
                        Console.WriteLine("KO");
                        return;
                    }
                }

            Console.WriteLine("OK");
        }

        private bool Touche(st st1, st st2)
        {
            var e = Math.Sqrt(Math.Pow(st2.x - st1.x, 2) + Math.Pow(st2.y - st1.y, 2));
            if (e < st2.z && e + st1.z < st2.z)
                return false;
            if (e < st1.z && e + st2.z < st1.z)
                return false;
            if (e - (st2.z + st1.z) > 0)
                return false;
            return true;
        }
    }
}
