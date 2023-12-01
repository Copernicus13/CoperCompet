using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleDev._2015_11
{
    public class Exo4
    {
        public Exo4()
        {
            string line = Console.ReadLine();
            int N = int.Parse(line.Split(' ')[0]);
            int M = int.Parse(line.Split(' ')[1]);

            bool[,] list = new bool[N, M];

            for (int i = 0; i < N; ++i)
            {
                line = Console.ReadLine();
                for (int j = 0; j < M; ++j)
                    list[i, j] = line[j] == 'x' ? true: false;
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < N; ++i)
            {
                IList<bool> l = new List<bool>();
                for (int j = 0; j < M; ++j)
                    l.Add(list[i,j]);
                l.Add(false);
                sb.Append(GetIt(l) + " ");
            }
            for (int i = 0; i < M; ++i)
            {
                IList<bool> l = new List<bool>();
                for (int j = 0; j < N; ++j)
                    l.Add(list[j, i]);
                l.Add(false);
                sb.Append(GetIt(l) + " ");
            }
            Console.WriteLine(sb.Remove(sb.Length - 1, 1).ToString());
        }

        private string GetIt(IList<bool> list)
        {
            StringBuilder sb = new StringBuilder();
            int cpt = 0;
            foreach (bool b in list)
            {
                if (b)
                    ++cpt;
                else
                {
                    if (cpt != 0)
                    {
                        if (sb.Length != 0)
                            sb.Append("-" + cpt);
                        else
                            sb.Append(cpt);
                        cpt = 0;
                    }
                }
            }

            return sb.ToString() == string.Empty ? "." : sb.ToString();
        }
    }
}
