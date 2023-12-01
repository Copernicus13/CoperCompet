using System;
using System.Collections.Generic;

namespace BattleDev._2015_11
{
    public class Exo3
    {
        public Exo3()
        {
            int N = int.Parse(Console.ReadLine());
            string line = Console.ReadLine();
            IList<int> list = new List<int>();
            IList<string> str = new List<string>();
            int res1 = 0;
            int res2 = int.MaxValue;

            for (int i = 0; i < 26; ++i)
                list.Add(int.Parse(line.Split(' ')[i]));

            for (int i = 0; i < N; ++i)
                str.Add(Console.ReadLine());

            foreach (var s in str)
                if (Calcul(list, s) > res1)
                    res1 = Calcul(list, s);

            foreach (var s in str)
                if (Calcul(list, s) == res1 && s.Length < res2)
                    res2 = s.Length;

            Console.WriteLine("{0} {1}", res1, res2);
        }

        private int Calcul(IList<int> list, string s)
        {
            int total = 0;
            foreach (var c in s)
                total += list[c - 'A'];
            return total;
        }
    }
}
