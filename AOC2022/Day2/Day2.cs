using AOC2022;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2022.D2
{
    public class Day2 : IDay
    {
        public string[] input { get; }
        Game _game;

        public Day2()
        {
            input = ReadInput.GetInputLines(GetType().Name, true);
        }

        public void Execute()
        {
            Console.WriteLine($"Part-1 {Part1()}");
        }

        public object Part1()
        {
            _game = new Game();

            foreach (string line in input)
            {
                string[] roundGuide = line.Split(" ");
                _game.Round(roundGuide[0], roundGuide[1]);
            }
            return "";
        }

        public object Part2()
        {
            throw new NotImplementedException();
        }
    }

    public class Game
    {
        Player _player;
        Oppenent _oppenent;

        public Game()
        {
            _player = new Player(0);
            _oppenent = new Oppenent();
        }


        public void Round(string playerShape, string opponentShape)
        {
            _player._shape = playerShape;
            _oppenent._shape = opponentShape;
        }

        public bool isWin(string playerShape, string opponentShape)
        {
            bool win = false;

            if(playerShaper)

            return true;
        }
    }

    public class Player
    {
        public int _score { get; set; }
        public Dictionary<char, int> shapeScores = new Dictionary<char, int>()
        {
            {'Y', 2 },
            {'X', 1 },
            {'Z', 3 }
        };

        public string _shape { get; set; }

        public Player(int score, string[] shapes)
        {
            _score = score;

        }
    }

    public class Oppenent
    {
        public string _shape { get; set; }

        public Oppenent()
        {

        }
    }
}
