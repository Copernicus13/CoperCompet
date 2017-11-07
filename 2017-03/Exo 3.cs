using System;

namespace BattleDev._2017_03
{
    public class Exo3
    {
        public Exo3()
        {
            int N = int.Parse(Console.ReadLine());
            string s = Console.ReadLine();

            bool b = false;
            int t = 0;
            int o = -1;
            foreach (char e in s)
            {
                if (e == '_')
                {
                    if (b)
                        ++t;
                    else
                    {
                        b = true;
                        t = 1;
                    }
                }
                else
                {
                    b = false;
                    t = 0;
                }
                o = Math.Max(o, t);
            }

            Console.WriteLine(o + 1);
        }
    }
}
