using System;
using System.Linq;

namespace AdventOfCode._2015
{
    /// <summary>
    /// http://adventofcode.com/2015/day/22
    /// </summary>
    public class Day22
    {
        private class Character
        {
            public int Life;
            public int Damage;
            public int Armor;

            public new Character MemberwiseClone()
            {
                return (Character)base.MemberwiseClone();
            }
        }

        private class Wizard : Character
        {
            public int Mana;
            public Spell[] CastSpells = new Spell[] { };

            public new Wizard MemberwiseClone()
            {
                var clone = (Wizard)base.MemberwiseClone();
                clone.CastSpells = new Spell[CastSpells.Length];
                Array.Copy(CastSpells, clone.CastSpells, CastSpells.Length);
                return clone;
            }
        }

        private enum SpellType
        {
            Damage, Armor, Healing, Recharge
        }

        private struct Spell : IEquatable<Spell>
        {
            private readonly int _id;
            public readonly int Cost;
            public readonly int[] Values;
            public readonly SpellType[] Types;
            public readonly int Cycles;
            public readonly bool Instant;
            public int ActualCycle;

            public Spell(int id, int cost, int value, SpellType type, int cycles = -1)
                : this(id, cost, new int[] { value }, new SpellType[] { type }, cycles)
            {
            }

            public Spell(int id, int cost, int[] values, SpellType[] types, int cycles = -1)
            {
                _id = id;
                Cost = cost;
                Values = values;
                Types = types;
                Cycles = cycles;
                ActualCycle = cycles;
                Instant = cycles == -1;
            }

            public bool Equals(Spell other)
            {
                return _id == other._id;
            }
        }

        private readonly Spell[] _spells =
            {
                new Spell(1, 53, 4, SpellType.Damage),
                new Spell(2, 73, new int[] { 2, 2 }, new SpellType[] { SpellType.Damage, SpellType.Healing }),
                new Spell(3, 113, 7, SpellType.Armor, 6),
                new Spell(4, 173, 3, SpellType.Damage, 6),
                new Spell(5, 229, 101, SpellType.Recharge, 5)
            };

        private int _min;
        private Part _part;

        public Day22(Part p)
        {
            _part = p;
            _min = int.MaxValue;
            var boss = new Character();
            boss.Life = int.Parse(Console.ReadLine().Split(' ')[2]);
            boss.Damage = int.Parse(Console.ReadLine().Split(' ')[1]);

            var me = new Wizard
                {
                    Life = 50,
                    Mana = 500
                };

            LaunchGame(me, boss, 0);

            Console.WriteLine(_min);
        }

        private void LaunchGame(Wizard me, Character boss, int totalCost)
        {
            for (int i = 0; i < _spells.Length; ++i)
            {
                int currentCost = totalCost;
                Wizard copyMe = me.MemberwiseClone();
                Character copyBoss = boss.MemberwiseClone();

                if (_part == Part.Part2)
                {
                    --copyMe.Life;
                    if (copyMe.Life <= 0)
                        continue;
                }

                // Effects before player
                if (Round(copyMe, copyBoss, currentCost))
                    continue;

                // Is current spell possible ?
                if (copyMe.Mana < _spells[i].Cost)
                    continue;
                if (copyMe.CastSpells.Contains(_spells[i]))
                    continue;

                // Attack from player
                copyMe.Mana -= _spells[i].Cost;
                currentCost += _spells[i].Cost;
                if (_spells[i].Instant)
                {
                    Spell oneSpell = _spells[i];
                    Cast(copyMe, copyBoss, ref oneSpell);
                    if (_min > currentCost && copyBoss.Life <= 0)
                    {
                        _min = currentCost;
                        continue;
                    }
                }
                else
                {
                    var tmp = copyMe.CastSpells.ToList();
                    tmp.Add(_spells[i]);
                    copyMe.CastSpells = tmp.ToArray();
                }

                // Effects before boss
                if (Round(copyMe, copyBoss, currentCost))
                    continue;

                // Attack from boss
                copyMe.Life -= copyBoss.Damage > copyMe.Armor ? copyBoss.Damage - copyMe.Armor : 1;
                if (copyMe.Life <= 0)
                    continue;

                // Next turn
                if (currentCost < _min)
                    LaunchGame(copyMe, copyBoss, currentCost);
            }
        }

        private bool Round(Wizard me, Character boss, int totalCost)
        {
            if (me.CastSpells.Length == 0)
                return false;

            for (int i = 0; i < me.CastSpells.Length; ++i)
                Cast(me, boss, ref me.CastSpells[i]);

            var tmp = me.CastSpells.ToList();
            if (tmp.Any(r => r.ActualCycle == 0 && r.Cost == 113))
                me.Armor = 0;
            tmp.RemoveAll(r => r.ActualCycle <= 0);
            me.CastSpells = tmp.ToArray();

            if (boss.Life > 0)
                return false;

            if (_min > totalCost)
                _min = totalCost;

            return true;
        }

        private static void Cast(Wizard me, Character boss, ref Spell spell)
        {
            for (int i = 0; i < spell.Types.Length; ++i)
            {
                switch (spell.Types[i])
                {
                    case SpellType.Armor:
                        if (spell.ActualCycle == spell.Cycles)
                            me.Armor += spell.Values[i];
                        else if (spell.ActualCycle == 0)
                            me.Armor -= spell.Values[i];
                        break;
                    case SpellType.Damage:
                        boss.Life -= spell.Values[i];
                        break;
                    case SpellType.Healing:
                        me.Life += spell.Values[i];
                        break;
                    case SpellType.Recharge:
                        me.Mana += spell.Values[i];
                        break;
                }
                --spell.ActualCycle;
            }
        }
    }
}