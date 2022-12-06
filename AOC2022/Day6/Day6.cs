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
            int markerPosition = 0;
            for(int i = 0; i < InputText.Length; i++)
            {
                char[] sequenz = InputText.Substring(i, 4).ToCharArray();
                if(sequenz.Length == sequenz.Distinct().Count())
                {
                    markerPosition = i + 4;
                    return markerPosition;
                }
            }
            return markerPosition;
        }

        public object Part2()
        {
            int markerPosition = 0;
            for (int i = 0; i < InputText.Length; i++)
            {
                char[] sequenz = InputText.Substring(i, 14).ToCharArray();
                if (sequenz.Length == sequenz.Distinct().Count())
                {
                    markerPosition = i + 14;
                    return markerPosition;
                }
            }
            return markerPosition;
        }
    }
}
