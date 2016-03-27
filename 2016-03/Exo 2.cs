using System;
using System.Collections.Generic;

namespace BattleDev._2016_03
{
    public class Exo2
    {
        public struct MyPoint
        {
            public float Lat;
            public float Lng;

            public MyPoint(float x, float y)
            {
                Lat = x;
                Lng = y;
            }
        }

        public Exo2()
        {
            string line = Console.ReadLine();
            float fromLat = float.Parse(line.Split(' ')[0]);
            float fromLng = float.Parse(line.Split(' ')[1]);
            float toLat = float.Parse(line.Split(' ')[2]);
            float toLng = float.Parse(line.Split(' ')[3]);
            int nbPeople = int.Parse(Console.ReadLine());

            List<MyPoint> list = new List<MyPoint>();

            for (int i = 0; i < nbPeople; ++i)
            {
                line = Console.ReadLine();
                list.Add(new MyPoint(float.Parse(line.Split(' ')[0]), float.Parse(line.Split(' ')[1])));
            }

            int res = 0;
            foreach (var f in list)
            {
                if (f.Lat >= fromLat && f.Lat <= toLat &&
                    f.Lng >= fromLng && f.Lng <= toLng)
                    ++res;
            }
            Console.WriteLine(res);
        }
    }
}
