using System;

namespace GoogleCodeJam._2022.Qualification
{
    public class _3DPrinting
    {
        public _3DPrinting()
        {
            int T = int.Parse(Console.ReadLine());

            for (int nbCase = 1; nbCase <= T; ++nbCase)
            {
                var cartridges = new ValueTuple<int, int, int, int>[3] as (int C, int M, int Y, int K)[];
                for (int i = 0; i < 3; ++i)
                {
                    var numbers = Console.ReadLine().Split(' ');
                    cartridges[i] = (int.Parse(numbers[0]), int.Parse(numbers[1]), int.Parse(numbers[2]), int.Parse(numbers[3]));
                }

                int minC = MyMin(cartridges[0].C, cartridges[1].C, cartridges[2].C);
                int minM = MyMin(cartridges[0].M, cartridges[1].M, cartridges[2].M);
                int minY = MyMin(cartridges[0].Y, cartridges[1].Y, cartridges[2].Y);
                int minK = MyMin(cartridges[0].K, cartridges[1].K, cartridges[2].K);

                Console.Write($"Case #{nbCase}: ");
                if (minC + minM + minY + minK < 1000000)
                    Console.WriteLine("IMPOSSIBLE");
                else
                {
                    int resC = minC;
                    int aim = 1000000 - minC;
                    int resM = Math.Min(minM, aim);
                    aim -= resM;
                    int resY = Math.Min(minY, aim);
                    aim -= resY;
                    int resK = Math.Min(minK, aim);
                    Console.WriteLine($"{resC} {resM} {resY} {resK}");
                }
            }
        }

        public int MyMin(int v1, int v2, int v3) => Math.Min(v1, Math.Min(v2, v3));
    }
}
