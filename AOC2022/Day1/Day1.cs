using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AOC2022;

namespace AOC2022.D1
{
    public class Day1 : IDay
    {
        public string[] input {get;}
        public List<Elf> elfes;

        public Day1()
        {
            input = ReadInput.GetInputLines(GetType().Name);
            elfes = new List<Elf>();
        }

        public void Execute()
        {
            Console.WriteLine($"Part-1: {Part1()} calories");
            Console.WriteLine($"Part-2: {Part2()} calories");
        }

        public object Part1()
        {
            Elf currentElf = new Elf();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != "")
                {
                    currentElf.AddCalories(int.Parse(input[i]));
                    continue;
                }

                elfes?.Add(currentElf);
                currentElf = new Elf();
            }

            // append last elf outside of loop
            elfes?.Append(currentElf);
            int maxCalories = 0;

            if (elfes?.Count > 0)
            {
                maxCalories = elfes.MaxBy(e => e.calories).calories;

            }
            return maxCalories;
        }

        public object Part2()
        {
            return elfes.OrderByDescending(e => e.calories).Take(3).Sum(e => e.calories);
        }

        public class Elf
        {
            public int calories { get; set; }

            internal void AddCalories(int calorieAmount)
            {
                calories += calorieAmount;
            }

        }
    }
}
