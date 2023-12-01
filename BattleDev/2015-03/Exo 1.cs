using System;

namespace BattleDev._2015_03
{
    public class Exo1
    {
        public Exo1()
        {
            int nbLine = int.Parse(Console.ReadLine());

            for (int i = 0; i < nbLine; ++i)
            {
                string line = Console.ReadLine();
                int year = int.Parse(line);
                if (year % 4 == 0 && year % 100 != 0 || year % 400 == 0)
                    Console.WriteLine("BISSEXTILE");
                else
                    Console.WriteLine("NON BISSEXTILE");
            }
        }
    }
}
