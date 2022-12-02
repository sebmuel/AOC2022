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
        Game game;

        public Day2()
        {
            input = ReadInput.GetInputLines(GetType().Name);
        }

        public void Execute()
        {
            Console.WriteLine($"Part-1 {Part1()} points");
            Console.WriteLine($"Part-2 {Part2()} points");
        }

        public object Part1()
        {
            game = new Game();

            foreach (string line in input)
            {
                string[] roundGuide = line.Split(" ");
                game.player.score += game.Round(roundGuide[1], roundGuide[0]);
            }
            return game.player.score;
        }

        public object Part2()
        {
            game = new Game();

            foreach (string line in input)
            {
                string[] roundGuide = line.Split(" ");
                game.player.score += game.Round(roundGuide[1], roundGuide[0]);
            }
            return "";
        }
    }

    public class Game
    {
        public Player player { get; }
        public Oppenent oppenent;

        public Game()
        {
            this.player = new Player(0);
            this.oppenent = new Oppenent();
        }


        public int Round(string playerShape, string opponentShape)
        {
            player.shape = player.mapping[char.Parse(playerShape)];
            oppenent.shape = oppenent.mapping[char.Parse(opponentShape)];
            return CalcPoints();
        }

        public int CalcPoints()
        {
            int points = 0;

            if(player.shape == Shapes.Paper)
            {
                if(oppenent.shape == Shapes.Paper)
                {
                    points += 3 + player.shapeScores[player.shape]; 

                }
                else if (oppenent.shape == Shapes.Siccor)
                {
                    points += player.shapeScores[player.shape];
                }
                else
                {
                    points += 6 + player.shapeScores[player.shape];
                }
                    
            }
            else if (player.shape == Shapes.Siccor)
            {
                if (oppenent.shape == Shapes.Paper)
                {
                    points += 6 + player.shapeScores[player.shape];

                }
                else if (oppenent.shape == Shapes.Siccor)
                {
                    points += 3 + player.shapeScores[player.shape];
                }
                else
                {
                    points += player.shapeScores[player.shape];
                }

            }
            // player has rock
            else
            {
                if (oppenent.shape == Shapes.Paper)
                {
                    points += player.shapeScores[player.shape];

                }
                else if (oppenent.shape == Shapes.Siccor)
                {
                    points += 6 + player.shapeScores[player.shape];
                }
                else
                {
                    points += 3 + player.shapeScores[player.shape];
                }

            }

            return points;
        }

        public int CalcPointsPartTwo()
        {
            int points = 0;

            if (oppenent.shape == Shapes.Rock) { }
            
        }
    }

    public class Player
    {
        public int score { get; set; }
        public Dictionary<Shapes, int> shapeScores = new Dictionary<Shapes, int>()
        {
            {Shapes.Paper , 2 },
            {Shapes.Rock , 1 },
            {Shapes.Siccor, 3 }
        };

        public Dictionary<char, Shapes> mapping = new Dictionary<char, Shapes>()
        {
            {'Y', Shapes.Paper },
            {'X', Shapes.Rock },
            {'Z', Shapes.Siccor }
        };

        public Dictionary<char, int> mappingPartTwo = new Dictionary<char, int>()
        {
            {'Y', 3 },
            {'X', 0 },
            {'Z', 6 }
        };

        public Shapes shape { get; set; }

        public Player(int score)
        {
            this.score = score;

        }
    }

    public class Oppenent
    {
        public Shapes shape { get; set; }
        public Dictionary<char, Shapes> mapping = new Dictionary<char, Shapes>()
        {
            {'B', Shapes.Paper },
            {'A', Shapes.Rock },
            {'C', Shapes.Siccor }
        };


        public Oppenent()
        {

        }
    }

    public enum Shapes
    {
        Siccor,
        Rock,
        Paper
    }
}
