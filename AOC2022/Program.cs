using AOC2022.D1;
using AOC2022.D2;

namespace AOC2022
{
    public class AOC
    {
        readonly List<IDay> Days = new List<IDay>();

        public AOC()
        {
            Days.Add(new Day1());
            Days.Add(new Day2());
            
        }
        public static void Main()
        {
            AOC aoc = new AOC();

           foreach(IDay day in aoc.Days)
            {
                try
                {
                    day.Execute();
                }
                catch (NotImplementedException)
                {
                    Console.WriteLine($"Not implemented you faggot");
                }
            }
       
        }
    }
}