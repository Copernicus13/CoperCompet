using System;
using System.Collections.Generic;

namespace BattleDev._2015_11
{
    public class Exo1
    {
        public Exo1()
        {
            int nbLine = int.Parse(Console.ReadLine());
            int moyenne = 0;

            for (int i = 0; i < nbLine; ++i)
            {
                string line = Console.ReadLine();
                moyenne += int.Parse(line);
            }

            Console.WriteLine(moyenne / nbLine);
        }
    }
}
