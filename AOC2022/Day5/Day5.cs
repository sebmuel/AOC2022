using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2022.D5
{
    public class Day5 : IDay
    {
        public string[] input { get; }
        public int stackCount { get; set; }
        public List<List<char>> Stacks { get; set; }
        public int InstructionLine { get; set; }

        public Day5()
        {
            input = ReadInput.GetInputLines(GetType().Name);

        }

        public void Execute()
        {
            Console.WriteLine($"{Part1()}");
        }

        public object Part1()
        {
            BuildStacks();
            FillStacks();

            foreach (string inp in input.Skip(InstructionLine))
            {
                int move = int.Parse(inp.Substring(inp.IndexOf("move ") + 5, inp.IndexOf(" from") - inp.IndexOf("move ") - 5));
                int from = int.Parse(inp.Substring(inp.IndexOf("from ") + 5, inp.IndexOf(" to") - inp.IndexOf("from ") - 5));
                int to = int.Parse(inp.Substring(inp.IndexOf("to ") + 3, inp.Length - inp.IndexOf("to ") - 3));

                while(move > 0)
                {
                    Stacks[to -1].Insert(0, Stacks[from - 1].ElementAt(0));
                    Stacks[from - 1].RemoveAt(0);
                    move--;
                }
            }

            StringBuilder awnser = new StringBuilder();

            foreach(List<char> crate in Stacks)
            {
                awnser.Append(crate[0]);
            }
            return awnser;
        }

        public object Part2()
        {
            throw new NotImplementedException();
        }

        public void BuildStacks()
        {
            stackCount = (input[0].Length + 1) / 4;
            Stacks = new List<List<char>>();

            for (int i = 0; i < stackCount; i++)
            {
                Stacks.Add(new List<char>());
            }
            Console.WriteLine($"{stackCount} Stacks created");
        }

        public void FillStacks()
        {
            InstructionLine = 2;

            foreach (string inp in input)
            {

                if (inp.StartsWith(" 1 "))
                {
                    break;
                }

                InstructionLine++;

                for (int i = 0; i < inp.Length + 1; i += 4)
                {
                    char crate = inp.Substring(i, 3)[1];
                    if (crate != ' ')
                    {
                        Stacks[i == 0 ? 0 : i / 4].Add(crate);
                    }
                }
            }

        }
    }
}

