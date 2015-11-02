using System;

namespace BattleDev._2015_03
{
    public class Exo2
    {
        public Exo2()
        {
            int nbValid = 0;
            int nbLine = int.Parse(Console.ReadLine());

            for (int i = 0; i < nbLine; ++i)
            {
                string line = Console.ReadLine();

                if (line.Length == 6)
                {
                    if (char.IsLetter(line[0]) &&
                        char.IsDigit(line[1]) &&
                        char.IsLetter(line[2]) &&
                        char.IsLetter(line[3]) &&
                        char.IsLetter(line[4]) &&
                        char.IsLetter(line[5]))
                        ++nbValid;
                }
            }
            Console.WriteLine(nbValid);
        }
    }
}
