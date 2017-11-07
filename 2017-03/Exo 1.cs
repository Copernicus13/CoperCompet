using System;

namespace BattleDev._2017_03
{
    public class Exo1
    {
        public Exo1()
        {
            int N = int.Parse(Console.ReadLine());

            if (N >= 10)
                Console.WriteLine("JOB");
            else
                Console.WriteLine("ECHEC");
        }
    }
}
