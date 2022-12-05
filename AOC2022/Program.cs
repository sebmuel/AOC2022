using AOC2022.D1;
using AOC2022.D2;
using AOC2022.D3;
using AOC2022.D4;
using AOC2022.D5;

namespace AOC2022
{
    public class AOC
    {
        readonly List<IDay> Days = new List<IDay>();

        public AOC()
        {
            Days.Add(new Day1());
            Days.Add(new Day2());
            Days.Add(new Day3());
            Days.Add(new Day4());
            Days.Add(new Day5());

        }
        public static void Main()
        {
            AOC aoc = new AOC();

            foreach (IDay day in aoc.Days)
            {
                try
                {
                    Console.WriteLine($"{day.GetType()} \n" + $"----------------------------");
                    day.Execute();
                    Console.WriteLine("----------------------------");
                    Console.WriteLine();
                }
                catch (NotImplementedException)
                {
                    Console.WriteLine($"Not implemented you faggot");
                }
            }

        }
    }
}