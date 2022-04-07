using System;
using CoperAlgoLib.Geometry;

namespace HackerCup._2017.Qualification
{
    public class ProgressPie
    {
        public ProgressPie()
        {
            int T = int.Parse(Console.ReadLine());
            PointD center = new PointD(50, 50);
            PointD start = new PointD(50, 100);
            double radius = 50;

            for (int nbCase = 1; nbCase <= T; ++nbCase)
            {
                string s = Console.ReadLine();
                int P = int.Parse(s.Split(' ')[0]);
                var point = new PointD(
                    double.Parse(s.Split(' ')[1]), double.Parse(s.Split(' ')[2]));
                double distFromCenter = Math.Sqrt(
                    Math.Pow(point.X - center.X, 2) + Math.Pow(point.Y - center.Y, 2));

                if (distFromCenter - radius > 0.0000001d)
                    Console.WriteLine(string.Format("Case #{0}: white", nbCase));
                else if (point.X == center.X && point.Y == center.Y && P > 0)
                    Console.WriteLine(string.Format("Case #{0}: black", nbCase));
                else
                {
                    double angle = (double)P / 100 * 360;
                    double distFromStart = Math.Sqrt(
                        Math.Pow(point.X - start.X, 2) +
                        Math.Pow(point.Y - center.Y - distFromCenter, 2));
                    double anglePoint = 180 - 2 *
                        (Math.Acos(distFromStart / (2 * distFromCenter)) * 180 / Math.PI);
                    if (point.X < center.X)
                        anglePoint = 360 - anglePoint;
                    if (anglePoint - angle < 0.0000001d)
                        Console.WriteLine(string.Format("Case #{0}: black", nbCase));
                    else
                        Console.WriteLine(string.Format("Case #{0}: white", nbCase));
                }
            }
        }
    }
}
