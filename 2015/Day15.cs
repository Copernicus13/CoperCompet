using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using AdventOfCode.Common;

namespace AdventOfCode._2015
{
    public class Day15
    {
        [SuppressMessage("ReSharper", "UnusedMember.Local")]
        private enum Ingredient
        {
            Frosting,
            Candy,
            Butterscotch,
            Sugar
        }

        private struct IngredientProperties
        {
            public int Capacity;
            public int Durability;
            public int Flavor;
            public int Texture;
            public int Calories;
        }

        private readonly IDictionary<Ingredient, IngredientProperties> _dict;

        public Day15(Part p)
        {
            int nbIngredients = Enum.GetValues(typeof(Ingredient)).Length;
            _dict = new Dictionary<Ingredient, IngredientProperties>();
            string line;
            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
            {
                var words = line.Replace(",", string.Empty).Split(' ');
                _dict[S2I(words[0].TrimEnd(':'))] = new IngredientProperties
                    {
                        Calories = int.Parse(words[10]),
                        Capacity = int.Parse(words[2]),
                        Durability = int.Parse(words[4]),
                        Flavor = int.Parse(words[6]),
                        Texture = int.Parse(words[8])
                    };
            }

            long score = long.MinValue;
            for (int a = 0; a <= 100; ++a)
            {
                for (int b = 0; b <= 100 - a; ++b)
                {
                    for (int c = 0; c <= 100 - b - a; ++c)
                    {
                        int d = 100 - c - b - a;

                        var result = new IngredientProperties();
                        result.Capacity =
                            _dict[Ingredient.Frosting].Capacity * a +
                            _dict[Ingredient.Candy].Capacity * b +
                            _dict[Ingredient.Butterscotch].Capacity * c +
                            _dict[Ingredient.Sugar].Capacity * d;
                        result.Durability =
                            _dict[Ingredient.Frosting].Durability * a +
                            _dict[Ingredient.Candy].Durability * b +
                            _dict[Ingredient.Butterscotch].Durability * c +
                            _dict[Ingredient.Sugar].Durability * d;
                        result.Flavor =
                            _dict[Ingredient.Frosting].Flavor * a +
                            _dict[Ingredient.Candy].Flavor * b +
                            _dict[Ingredient.Butterscotch].Flavor * c +
                            _dict[Ingredient.Sugar].Flavor * d;
                        result.Texture =
                            _dict[Ingredient.Frosting].Texture * a +
                            _dict[Ingredient.Candy].Texture * b +
                            _dict[Ingredient.Butterscotch].Texture * c +
                            _dict[Ingredient.Sugar].Texture * d;
                        result.Calories =
                            _dict[Ingredient.Frosting].Calories * a +
                            _dict[Ingredient.Candy].Calories * b +
                            _dict[Ingredient.Butterscotch].Calories * c +
                            _dict[Ingredient.Sugar].Calories * d;
                        if (p == Part.Part1)
                            score = Math.Max(score,
                                (result.Capacity > 0 ? result.Capacity : 0) *
                                (result.Durability > 0 ? result.Durability : 0) *
                                (result.Flavor > 0 ? result.Flavor : 0) *
                                (result.Texture > 0 ? result.Texture : 0));
                        else if (p == Part.Part2)
                        {
                            if (result.Calories == 500)
                                score = Math.Max(score,
                                    (result.Capacity > 0 ? result.Capacity : 0) *
                                    (result.Durability > 0 ? result.Durability : 0) *
                                    (result.Flavor > 0 ? result.Flavor : 0) *
                                    (result.Texture > 0 ? result.Texture : 0));
                        }
                    }
                }
            }

            Console.WriteLine(score);
        }

        private static Ingredient S2I(string ingredient)
        {
            return (Ingredient)Enum.Parse(typeof(Ingredient), ingredient);
        }
    }
}