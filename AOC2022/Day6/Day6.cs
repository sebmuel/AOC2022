using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2022.D6
{
    public class Day6 : IDay
    {
        public string[] input { get; }
        public string InputText { get; }

        public Day6()
        {
            InputText = ReadInput.GetInputText(GetType().Name);
        }

        public void Execute()
        {
            Console.WriteLine($"Part-1: {Part1()}");
            Console.WriteLine($"Part-2: {Part2()}");
        }

        public object Part1()
        {
            return FindMarkerPosition(4, InputText);
        }

        public object Part2()
        {
            return FindMarkerPosition(14, InputText);
        }

        public static int FindMarkerPosition(int sequenzLength, string input)
        {
            int markerPosition = 0;
            char[] chars = input.ToCharArray();
            for(int i = 0; i < chars.Length; i++)
            {
                char[] sequenz = chars.Skip(i).Take(sequenzLength).ToArray();
                if(sequenz.Length == sequenz.Distinct().Count())
                {
                    markerPosition = i + sequenzLength;
                    break;
                }
            }

            return markerPosition;
        }
    }
}
