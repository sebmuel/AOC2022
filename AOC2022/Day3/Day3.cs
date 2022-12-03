using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2022.D3
{
    public class Day3 : IDay
    {
        List<Rucksack> RucksackOne { get; set; }
        List<ElvesGroup> ElvesGroupOne { get; set; }
        public string[] input { get; }

        public Day3()
        {
            input = ReadInput.GetInputLines(GetType().Name);
            ElvesGroupOne = new List<ElvesGroup>();
        }

        public void Execute()
        {
            Console.WriteLine($"Part-1: The Priortiy Sum is {Part1()}");
            Console.WriteLine($"Part-2: The Priortiy Sum is {Part2()}");
        }

        public object Part1()
        {
            int priorityCount = 0;
            RucksackOne = new List<Rucksack>();
            // build rucksack with compartments
            foreach (string line in input)
            {
                List<char> items = line.ToCharArray().ToList();
                Compartments compOne = new Compartments(items.GetRange(0, items.Count / 2));
                Compartments compTwo = new Compartments(items.GetRange((items.Count / 2), items.Count / 2));
                RucksackOne.Add(new Rucksack(compOne, compTwo));
            }

            foreach(Rucksack rucksack in RucksackOne)
            {
                priorityCount += rucksack.GetPriority();
            }

            return priorityCount;
        }

        public object Part2()
        {
            ElvesGroup elvesGroup = null;

            for (int i = 0; i < RucksackOne.Count; i++)
            {
                if(elvesGroup == null)
                {
                    elvesGroup = new ElvesGroup();
                }
            
                elvesGroup.rucksacks.Add(RucksackOne[i]);

                if (elvesGroup.rucksacks.Count > 2)
                {
                    ElvesGroupOne.Add(elvesGroup);
                    elvesGroup = new ElvesGroup();
                }
            }

            int priorityCount = 0;

            foreach(ElvesGroup group in ElvesGroupOne)
            {
                List<char> intersection = group.rucksacks.
                    Skip(1).
                    Aggregate(
                    new HashSet<char>(group.rucksacks.First().Items),
                    (intersect, next) => { intersect.IntersectWith(next.Items); return intersect; }).ToList();
                priorityCount += Rucksack.GetPriority(intersection);
            }
            return priorityCount;
        }
    }

    public class Rucksack
    {
        Compartments CompartmentOne { get; set; }
        Compartments CompartmentTwo { get; set; }

        public List<char> Items { get; set; }

        public Rucksack(Compartments compartmentOne, Compartments compartmentTwo)
        {
            CompartmentOne = compartmentOne;
            CompartmentTwo = compartmentTwo;
            Items = new List<char>(CompartmentOne.Items.Concat(CompartmentTwo.Items));
        }

        public int GetPriority()
        {
            char item = FindDuplicates();
            // lowercase
            if (item > 96)
            {
                return item - 96;
            }
            else
            {
                return item - 38;
            }
        }

        public static int GetPriority(List<char> intersections)
        {
            char item = intersections[0];
            // lowercase
            if (item > 96)
            {
                return item - 96;
            }
            else
            {
                return item - 38;
            }
        }

        private char FindDuplicates()
        {
            IEnumerable<char> duplicates = CompartmentOne.Items.Intersect(CompartmentTwo.Items);
            return duplicates.ElementAt(0);
        }
    }

    public class Compartments
    {
        public List<char> Items { get; set; }

        public Compartments(List<char> items)
        {
            Items = items;
        }
    }

    public class ElvesGroup
    {
        public List<Rucksack> rucksacks = new List<Rucksack>();
    }
}
