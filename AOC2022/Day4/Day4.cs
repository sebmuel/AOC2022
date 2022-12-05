using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace AOC2022.D4
{
    public class Day4 : IDay
    {
        public string[] input { get; }
        List<ElfPair> Pairs { get; }

        public Day4()
        {
            input = ReadInput.GetInputLines(GetType().Name);
            Pairs = new List<ElfPair>();
        }

        public void Execute()
        {
            Console.WriteLine($"Part-1: {Part1()}");
            Console.WriteLine($"Part-2: {Part2()}");
        }

        public object Part1()
        {
            int contains = 0;
            foreach (string line in input)
            {
                // split line on ","
                string[] sectionAssignment = line.Split(",");

                // create tuples for the sectionrange example: 1-6 -> {{1,6}}
                Tuple<int, int> sectionRangeOne = new
                    (int.Parse(sectionAssignment[0].Split("-")[0]),
                    int.Parse(sectionAssignment[0].Split("-")[1]));

                Tuple<int, int> sectionRangeTwo = new
                    (int.Parse(sectionAssignment[1].Split("-")[0]),
                    int.Parse(sectionAssignment[1].Split("-")[1]));

                Elf elfOne = new(sectionRangeOne);
                Elf elfTwo = new(sectionRangeTwo);

                ElfPair elfPair = new(elfOne, elfTwo);
                Pairs.Add(elfPair);

                if (elfPair.CheckSections())
                {
                    contains++;
                }
            }
            return contains;
        }

        public object Part2()
        {
            int contains = 0;
            foreach(ElfPair pair in Pairs)
            {
                if (pair.CheckSectionsDetailed())
                {
                    contains++;
                }
            }
            return contains;
        }
    }

    public class Elf
    {
        public int[] Sections { get; set; }

        public Elf(Tuple<int, int> sections)
        {
         
            Sections = ListSections(sections.Item1, sections.Item2);
        }

        private static int[] ListSections(int start, int end)
        {
            return Enumerable.Range(start, (end - start) + 1).ToArray();
        }

        public void ShowSections(string name)
        {
            foreach (int section in Sections)
            {
                Console.WriteLine($"{name}: {section}");
            }
        }
    }

    public class ElfPair
    {
        readonly Elf ElfOne;
        readonly Elf ElfTwo;

        public ElfPair(Elf elfOne, Elf elfTwo)
        {
            ElfOne = elfOne;
            ElfTwo = elfTwo;
        }

        public bool CheckSections()
        {
            if(ElfOne.Sections.Length > ElfTwo.Sections.Length)
            {
                return !ElfTwo.Sections.Except(ElfOne.Sections).Any();
            }
            else
            {
                return !ElfOne.Sections.Except(ElfTwo.Sections).Any();
            }
        }

        public bool CheckSectionsDetailed()
        {
            return ElfOne.Sections.Intersect(ElfTwo.Sections).Any();
        }
    }
}
