using System;
using HackerCup.Common.Data;

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
                    Math.Pow(point.x - center.x, 2) + Math.Pow(point.y - center.y, 2));

                if (distFromCenter - radius > 0.0000001d)
                    Console.WriteLine(string.Format("Case #{0}: white", nbCase));
                else if (point.x == center.x && point.y == center.y && P > 0)
                    Console.WriteLine(string.Format("Case #{0}: black", nbCase));
                else
                {
                    double angle = (double)P / 100 * 360;
                    double distFromStart = Math.Sqrt(
                        Math.Pow(point.x - start.x, 2) +
                        Math.Pow(point.y - center.y - distFromCenter, 2));
                    double anglePoint = 180 - 2 *
                        (Math.Acos(distFromStart / (2 * distFromCenter)) * 180 / Math.PI);
                    if (point.x < center.x)
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
