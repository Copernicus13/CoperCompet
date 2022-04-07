using AdventOfCode.Common;
using System;

namespace AdventOfCode._2015
{
    /// <summary>
    /// http://adventofcode.com/2015/day/21
    /// </summary>
    public class Day21
    {
        private struct Character
        {
            public int Life;
            public int Damage;
            public int Armor;
        }

        private struct Item
        {
            public int Cost;
            public int Value;

            public Item(int cost, int value)
            {
                Cost = cost;
                Value = value;
            }
        }

        private readonly Item[] _weapons =
            {
                new Item(8, 4), new Item(10, 5), new Item(25, 6), new Item(40, 7),
                new Item(74, 8)
            };

        private readonly Item[] _armors =
            {
                new Item(0, 0), new Item(13, 1), new Item(31, 2), new Item(53, 3),
                new Item(75, 4), new Item(102, 5)
            };

        private readonly Item[] _objects1 =
            {
                new Item(0, 0), new Item(25, 1), new Item(50, 2), new Item(100, 3)
            };

        private readonly Item[] _objects2 =
            {
                new Item(0, 0), new Item(20, 1), new Item(40, 2), new Item(80, 3)
            };

        public Day21(Part p)
        {
            var boss = new Character();
            boss.Life = int.Parse(Console.ReadLine().Split(' ')[2]);
            boss.Damage = int.Parse(Console.ReadLine().Split(' ')[1]);
            boss.Armor = int.Parse(Console.ReadLine().Split(' ')[1]);

            int result = (p == Part.Part1 ? int.MaxValue : int.MinValue);
            for (int a = 0; a < _weapons.Length; ++a)
                for (int b = 0; b < _armors.Length; ++b)
                    for (int c = 0; c < _objects1.Length; ++c)
                        for (int d = 0; d < _objects2.Length; ++d)
                        {
                            var me = new Character
                                {
                                    Life = 100,
                                    Damage = _weapons[a].Value + _objects1[c].Value,
                                    Armor = _armors[b].Value + _objects2[d].Value
                                };

                            if (p == Part.Part1 && Game(me, boss))
                                result = Math.Min(result, _weapons[a].Cost + _armors[b].Cost +
                                    _objects1[c].Cost + _objects2[d].Cost);
                            else if (p == Part.Part2 && !Game(me, boss))
                                result = Math.Max(result, _weapons[a].Cost + _armors[b].Cost +
                                    _objects1[c].Cost + _objects2[d].Cost);
                        }
            Console.WriteLine(result);
        }

        private bool Game(Character me, Character boss)
        {
            while (true)
            {
                boss.Life -= me.Damage > boss.Armor ? me.Damage - boss.Armor : 1;
                if (boss.Life <= 0)
                    return true;
                me.Life -= boss.Damage > me.Armor ? boss.Damage - me.Armor : 1;
                if (me.Life <= 0)
                    return false;
            }
        }
    }
}