using System;
using System.Collections.Generic;

namespace BattleDev._2017_03
{
    public struct Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class Exo5
    {
        private Tuple<char, int>[,] _Map;
        private IList<Point> ghosts = new List<Point>();
        private Point StartPoint;
        private Point TargetPoint;
        private Point[] _Dir =
            {
                new Point(0, -1), new Point(-1, 0),
                new Point(0, 1), new Point(1, 0)
            };

        public Exo5()
        {
            int N = int.Parse(Console.ReadLine());
            _Map = new Tuple<char, int>[N, N];
            IList<Point> ghosts = new List<Point>();

            for (int y = 0; y < N; ++y)
            {
                string s = Console.ReadLine();
                for (int x = 0; x < N; ++x)
                {
                    _Map[y, x] = new Tuple<char, int>(s[x], 0);
                    if (s[x] == 'C')
                        StartPoint = new Point(x, y);
                    if (s[x] == 'M')
                        ghosts.Add(new Point(x, y));
                    if (s[x] == 'O')
                        TargetPoint = new Point(x, y);
                }
            }

            bool OK = true;
            int t = 0;
            while (t < N * N)
            {
                ++t;
                foreach (var dir in _Dir)
                {
                    foreach (var g in ghosts)
                        _Map[g.Y, g.X] = new Tuple<char, int>(_Map[g.Y, g.X].Item1, t);

                }
                //var x = (current.X + dir.X) % N;
                //var y = (current.Y + dir.Y) % N;
                //if (x < 0)
                //    x = N - 1;
                //if (y < 0)
                //    y = N - 1;
            }
            if (!Fluid(t))
            {
                Console.WriteLine("0");
            }
            Console.WriteLine();
            OK = false;
        }

        private bool Fluid(int t)
        {
            return true;
        }

        //private int ShortestPath(int N, Point StartPoint, Point TargetPoint)
        //{
        //    var queue = new Queue<Point>();
        //    _Map[StartPoint.Y, StartPoint.X] = new Tuple<char, int>(_Map[StartPoint.Y, StartPoint.X].Item1, 0);
        //    queue.Enqueue(new Point(StartPoint.X, StartPoint.Y));
        //    while (queue.Any())
        //    {
        //        var current = queue.Dequeue();

        //        foreach (var dir in _Dir)
        //        {
        //            var x = (current.X + dir.X) % N;
        //            var y = (current.Y + dir.Y) % N;
        //            if (x < 0)
        //                x = N - 1;
        //            if (y < 0)
        //                y = N - 1;
        //            if (TargetPoint.X == x && TargetPoint.Y == y)
        //            {
        //                return _Map[current.Y, current.X].Item2 + 1;
        //            }

        //            if (_Map[y, x].Item1 == '.')
        //            {
        //                _Map[y, x] = new Tuple<char, int>('.', _Map[current.Y, current.X].Item2 + 1);
        //                queue.Enqueue(new Point(x, y));
        //            }
        //        }
        //    }
        //    return 0;
        //}
    }
}
