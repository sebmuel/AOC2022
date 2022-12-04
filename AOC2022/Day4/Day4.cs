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
        List<ElfPair> pairs { get; }

        public Day4()
        {
            input = ReadInput.GetInputLines(GetType().Name);
            pairs = new List<ElfPair>();
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
                string[] sectionAssignment = line.Split(",");

                Tuple<int, int> sectionRangeOne = new Tuple<int, int>
                    (int.Parse(sectionAssignment[0].Split("-")[0]),
                    int.Parse(sectionAssignment[0].Split("-")[1]));

                Tuple<int, int> sectionRangeTwo = new Tuple<int, int>
                    (int.Parse(sectionAssignment[1].Split("-")[0]),
                    int.Parse(sectionAssignment[1].Split("-")[1]));

                Elf elfOne = new Elf(sectionRangeOne);
                Elf elfTwo = new Elf(sectionRangeTwo);

                ElfPair elfPair = new ElfPair(elfOne, elfTwo);
                pairs.Add(elfPair);

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
            foreach(ElfPair pair in pairs)
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

        private int[] ListSections(int start, int end)
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
