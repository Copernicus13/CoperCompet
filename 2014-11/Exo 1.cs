using System;

namespace BattleDev._2014_11
{
    public class Exo1
    {
        public Exo1()
        {
            string line1 = Console.ReadLine();
            string line2 = Console.ReadLine();

            int idx = line2.IndexOf(line1[0]);
            if (idx == -1)
            {
                Console.WriteLine("NOK 0");
                return;
            }

            for (int i = 1; i < line1.Length; ++i)
            {
                bool found = false;
                while (idx < line2.Length)
                    if (line2[idx++] == line1[i])
                    {
                        found = true;
                        break;
                    }
                if (!found)
                {
                    Console.WriteLine(string.Format("NOK {0}", i));
                    return;
                }
            }
            Console.WriteLine("OK");
        }
    }
}
