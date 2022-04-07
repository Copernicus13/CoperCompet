using System;
using System.Collections.Generic;
using System.Linq;
using CoperAlgoLib.Combinatorics;
using CoperAlgoLib.Geometry;

namespace HackerCup._2017.Round1
{
    public class FightingTheZombies
    {
        public FightingTheZombies()
        {
            int T = int.Parse(Console.ReadLine());
            for (int nbCase = 1; nbCase <= T; ++nbCase)
            {
                var param = Console.ReadLine().Split(' ');
                int N = int.Parse(param[0]);
                int R = int.Parse(param[1]);
                IList<Point> list = new List<Point>();
                for (int i = 0; i < N; ++i)
                {
                    param = Console.ReadLine().Split(' ');
                    list.Add(new Point(int.Parse(param[0]), int.Parse(param[1])));
                }
                var distances = ComputeDistances(list, R);
                int res = 1;
                if (N > 1)
                {
                    var combinations = new Combinations<int>(Enumerable.Range(0, N).ToList(), 2);
                    foreach (var f in combinations)
                        res = Math.Max(res, Calc(list.Count, distances, R, f[0], f[1]));
                }
                Console.WriteLine(string.Format("Case #{0}: {1}", nbCase, res));
            }
        }

        private bool[,,] ComputeDistances(IList<Point> positions, int R)
        {
            Point[] orig =
            {
                new Point(-1, 0), new Point(-1, -1), new Point(0, 0), new Point(0, -1)
            };
            var distances = new bool[positions.Count, positions.Count, orig.Length];
            for (int i = 0; i < positions.Count; ++i)
                for (int j = 0; j < positions.Count; ++j)
                    for (int k = 0; k < orig.Length; ++k)
                    {
                        var rect = new Rectangle(
                            positions[i].X + orig[k].X * R, positions[i].Y + orig[k].Y * R, R, R);
                        if (j == i)
                            distances[i, j, k] = true;
                        else
                            distances[i, j, k] = rect.ContainsIncludingEdge(positions[j]);
                    }
            return distances;
        }

        private int Calc(int nbPoint, bool[,,] distances, int R, int point1, int point2)
        {
            int res = 0;
            ISet<int> set = new HashSet<int>();
            for (int j = 0; j < 4; ++j)
                for (int l = 0; l < 4; ++l)
                {
                    set.Clear();
                    for (int i = 0; i < nbPoint; ++i)
                        if (distances[point1, i, j])
                            set.Add(i);
                    for (int k = 0; k < nbPoint; ++k)
                        if (distances[point2, k, l])
                            set.Add(k);
                    res = Math.Max(res, set.Count);
                }
            return res;
        }
    }
}
