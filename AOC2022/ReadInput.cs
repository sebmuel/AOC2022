using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2022
{
    public static class ReadInput
    {
        static readonly string rootPath = Directory.GetParent(Environment.CurrentDirectory)?.Parent?.Parent?.FullName;
        public static string GetInputText(string path , bool test = false)
        {
            string fileName = test ? "testInput.txt" : "input.txt";
            return File.ReadAllText(@$"{rootPath}\{path}\{fileName}");
        }

        public static string[] GetInputLines(string path, bool test = false)
        {
            string fileName = test ? "testInput.txt" : "input.txt";
            return File.ReadAllLines(@$"{rootPath}\{path}\{fileName}");
        }
    }



    public interface IDay
    {
        string[] input {get;}
        public void Execute();
        public object Part1();
        public object Part2();
    }
}
