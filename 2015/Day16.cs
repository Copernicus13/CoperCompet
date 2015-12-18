using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode._2015
{
    public class Day16
    {

#pragma warning disable 0660, 0661
        [SuppressMessage("ReSharper", "NotAccessedField.Local")]
        private class AuntProperties
        {
            public static Part Part;

            public int Id;
            public int Children;
            public int Cats;
            public int Samoyeds;
            public int Pomeranians;
            public int Akitas;
            public int Vizslas;
            public int Goldfish;
            public int Trees;
            public int Cars;
            public int Perfumes;

            public AuntProperties()
            {
                Children = -1;
                Cats = -1;
                Samoyeds = -1;
                Pomeranians = -1;
                Akitas = -1;
                Vizslas = -1;
                Goldfish = -1;
                Trees = -1;
                Cars = -1;
                Perfumes = -1;
            }

            // ReSharper disable once FunctionComplexityOverflow
            public static bool operator ==(AuntProperties x, AuntProperties y)
            {
                bool equals = true;
                if (Part == Part.Part1)
                {
                    if (x.Children != -1 && y.Children != -1)
                        equals &= x.Children == y.Children;
                    if (x.Cats != -1 && y.Cats != -1)
                        equals &= x.Cats == y.Cats;
                    if (x.Samoyeds != -1 && y.Samoyeds != -1)
                        equals &= x.Samoyeds == y.Samoyeds;
                    if (x.Pomeranians != -1 && y.Pomeranians != -1)
                        equals &= x.Pomeranians == y.Pomeranians;
                    if (x.Akitas != -1 && y.Akitas != -1)
                        equals &= x.Akitas == y.Akitas;
                    if (x.Vizslas != -1 && y.Vizslas != -1)
                        equals &= x.Vizslas == y.Vizslas;
                    if (x.Goldfish != -1 && y.Goldfish != -1)
                        equals &= x.Goldfish == y.Goldfish;
                    if (x.Trees != -1 && y.Trees != -1)
                        equals &= x.Trees == y.Trees;
                    if (x.Cars != -1 && y.Cars != -1)
                        equals &= x.Cars == y.Cars;
                    if (x.Perfumes != -1 && y.Perfumes != -1)
                        equals &= x.Perfumes == y.Perfumes;
                }
                else if (Part == Part.Part2)
                {
                    if (x.Children != -1 && y.Children != -1)
                        equals &= x.Children == y.Children;
                    if (x.Cats != -1 && y.Cats != -1)
                        equals &= x.Cats > y.Cats;
                    if (x.Samoyeds != -1 && y.Samoyeds != -1)
                        equals &= x.Samoyeds == y.Samoyeds;
                    if (x.Pomeranians != -1 && y.Pomeranians != -1)
                        equals &= x.Pomeranians < y.Pomeranians;
                    if (x.Akitas != -1 && y.Akitas != -1)
                        equals &= x.Akitas == y.Akitas;
                    if (x.Vizslas != -1 && y.Vizslas != -1)
                        equals &= x.Vizslas == y.Vizslas;
                    if (x.Goldfish != -1 && y.Goldfish != -1)
                        equals &= x.Goldfish < y.Goldfish;
                    if (x.Trees != -1 && y.Trees != -1)
                        equals &= x.Trees > y.Trees;
                    if (x.Cars != -1 && y.Cars != -1)
                        equals &= x.Cars == y.Cars;
                    if (x.Perfumes != -1 && y.Perfumes != -1)
                        equals &= x.Perfumes == y.Perfumes;
                }
                return equals;
            }

            public static bool operator !=(AuntProperties x, AuntProperties y)
            {
                return !(x == y);
            }
        }
#pragma warning restore 0660, 0661

        public Day16(Part p)
        {
            AuntProperties.Part = p;
            var list = new List<AuntProperties>();
            string line;
            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
            {
                var words = line.Split(' ');
                var prop = new AuntProperties
                    {
                        Id = int.Parse(words[1].TrimEnd(':'))
                    };
                FillProperty(prop, words[2], words[3]);
                FillProperty(prop, words[4], words[5]);
                FillProperty(prop, words[6], words[7]);
                list.Add(prop);
            }

            var result = list.Single(w => w == new AuntProperties
                {
                    Children = 3,
                    Cats = 7,
                    Samoyeds = 2,
                    Pomeranians = 3,
                    Akitas = 0,
                    Vizslas = 0,
                    Goldfish = 5,
                    Trees = 3,
                    Cars = 2,
                    Perfumes = 1
                });

            Console.WriteLine(result.Id);
        }

        private void FillProperty(AuntProperties prop, string field, string value)
        {
            value = value.TrimEnd(',');
            switch (field.TrimEnd(':'))
            {
                case "children":
                    prop.Children = int.Parse(value);
                    break;
                case "cats":
                    prop.Cats = int.Parse(value);
                    break;
                case "samoyeds":
                    prop.Samoyeds = int.Parse(value);
                    break;
                case "pomeranians":
                    prop.Pomeranians = int.Parse(value);
                    break;
                case "akitas":
                    prop.Akitas = int.Parse(value);
                    break;
                case "vizslas":
                    prop.Vizslas = int.Parse(value);
                    break;
                case "goldfish":
                    prop.Goldfish = int.Parse(value);
                    break;
                case "trees":
                    prop.Trees = int.Parse(value);
                    break;
                case "cars":
                    prop.Cars = int.Parse(value);
                    break;
                case "perfumes":
                    prop.Perfumes = int.Parse(value);
                    break;
            }
        }
    }
}
