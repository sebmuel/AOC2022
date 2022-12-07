using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2022.D7
{
    public class Day7 : IDay
    {
        public string[] input { get; }
        Tree Tree { get; set; }
        Node Root { get; set; }

        public Day7()
        {
            input = ReadInput.GetInputLines(GetType().Name);
        }

        public void Execute()
        {
            Root = new Node("/", null);
            Tree = new Tree(Root);
            Console.WriteLine($"Part-1: {Part1()} is the sum of directorys small than 100000");
            Console.WriteLine($"Part-2: {Part2()} is the sum of directorys small than 100000");
        }

        public object Part1()
        {

            Tree.BuildTree(input);
            Tree.TraverseTree(Root);
            return Tree.TraverseTree2(Root);

        }

        public object Part2()
        {
            
            return Tree.FindDirectory(Root);
        }
    }

    public class Tree
    {
        Node Root { get; set; }
        Node CurrentNode { get; set; }
    
        public Tree(Node root)
        {
            Root = root;
            CurrentNode = root;
        }

        public void BuildTree(string[] commands)
        {
            List<string> activeListing = new(); 
            for(int i = 0; i < commands.Length; i++)
            {
                if (commands[i].StartsWith("$"))
                {
                    string commandType = commands[i].Substring(2, 2);
                    if (commandType == "cd")
                    {
                        string changeTo = commands[i][5..];
                        if (changeTo == "/")
                        {

                            CurrentNode = Root;

                        }
                        else if(changeTo == "..")
                        {
                            CurrentNode = CurrentNode.Parent;

                        }
                        else
                        {
                            CurrentNode = CurrentNode.Directorys.Find(x => x.Key == changeTo);
                        }
                    }
                    else
                    {
                        List<string> listing = commands.Skip(i + 1).TakeWhile(n => !(n.StartsWith("$"))).ToList();

                        foreach (string file in listing)
                        {
                            if (file.StartsWith("dir"))
                            {
                                CurrentNode.Directorys.Add(new Node(file[4..], CurrentNode, 0, true));
                            }
                            else
                            {
                                string[] split = file.Split(" ");
                                CurrentNode.Files.Add(new Node(split[1], CurrentNode, int.Parse(split[0])));
                            }
                        }
                        i += listing.Count();
                    }

                }
            }
        }
        public int TraverseTree(Node root)
        {
            int sumFiles = 0;

            Queue<Node> nodes = new Queue<Node>();

            nodes.Enqueue(root);

            while(nodes.Count > 0)
            {
                Node node = nodes.Dequeue();

                if(node.Files.Count > 0)
                {
                    node.Size = node.Files.Sum(f => f.Size);

                    Node current = node;

                    while(current.Parent is not null)
                    {
                        current.Parent.Size += node.Size;
                        current = current.Parent;
                    }
                }

                foreach(Node n in node.Directorys)
                {
                    nodes.Enqueue(n);
                }
            }
            return sumFiles;
        }

        public int TraverseTree2(Node root)
        {
            int sumFiles = 0;

            Queue<Node> nodes = new Queue<Node>();

            nodes.Enqueue(root);

            while (nodes.Count > 0)
            {
                Node node = nodes.Dequeue();

                if (node.Size <= 100000)
                    sumFiles += node.Size;

                foreach (Node n in node.Directorys)
                {
                    nodes.Enqueue(n);
                }
            }
            return sumFiles;
        }

        public int FindDirectory(Node root)
        {
            int MAX_SPACE = 70000000;
            int atleast = 30000000;
            int available = MAX_SPACE - root.Size;

            List<Node> possibleDirectory = new();

            Queue<Node> nodes = new Queue<Node>();

            nodes.Enqueue(root);

            while (nodes.Count > 0)
            {
                Node node = nodes.Dequeue();

                if(available + node.Size >= atleast)
                {
                    possibleDirectory.Add(node);
                }

                foreach (Node n in node.Directorys)
                {
                    nodes.Enqueue(n);
                }
            }

            return possibleDirectory.Min(d => d.Size);
        }


    }


    public class Node
    {
        public string Key { get; set; }
        public Node Parent { get; set; }
        public List<Node> Directorys { get; set; }
        public List<Node> Files { get; set; }
        public int Size { get; set; }
        public bool IsDirectory { get; }

        public Node(string key, Node parent, int size = 0, bool isDirectory = false)
        {
            Key = key;
            Parent = parent;
            Directorys = new List<Node>();
            Files = new List<Node>();
            Size = size;
            IsDirectory = isDirectory;
        }
    }
}
