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
        Game Game;
        Game GameTwo;

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
            Game = new Game(new Player(0), new Oppenent());

            foreach (string line in input)
            {
                string[] roundGuide = line.Split(" ");
                Game.Player.Score += Game.Round(roundGuide[1], roundGuide[0]);
            }
            return Game.Player.Score;
        }

        public object Part2()
        {
            GameTwo = new Game(new Player(0), new Oppenent());

            foreach (string line in input)
            {
                string[] roundGuide = line.Split(" ");
                GameTwo.Player.Score = GameTwo.RoundPartTwo(roundGuide[1], roundGuide[0]);
            }
            return GameTwo.Player.Score;
        }
    }

    public class Game
    {
        public Player Player { get; }
        public Oppenent Opponent;

        public Game(Player player, Oppenent oppenent)
        {
            Player = player;
            Opponent = oppenent;
        }

        public int Round(string playerShape, string opponentShape)
        {
            Player.shape = Player.mapping[char.Parse(playerShape)];
            Opponent.shape = Opponent.mapping[char.Parse(opponentShape)];
            return CalcPoints();
        }

        public int CalcPoints()
        {
            int points = 0;

            if (Player.shape == Shapes.Paper)
            {
                if (Opponent.shape == Shapes.Paper)
                {
                    points += 3 + Player.shapeScores[Player.shape];

                }
                else if (Opponent.shape == Shapes.Siccor)
                {
                    points += Player.shapeScores[Player.shape];
                }
                else
                {
                    points += 6 + Player.shapeScores[Player.shape];
                }

            }
            else if (Player.shape == Shapes.Siccor)
            {
                if (Opponent.shape == Shapes.Paper)
                {
                    points += 6 + Player.shapeScores[Player.shape];

                }
                else if (Opponent.shape == Shapes.Siccor)
                {
                    points += 3 + Player.shapeScores[Player.shape];
                }
                else
                {
                    points += Player.shapeScores[Player.shape];
                }

            }
            // player has rock
            else
            {
                if (Opponent.shape == Shapes.Paper)
                {
                    points += Player.shapeScores[Player.shape];

                }
                else if (Opponent.shape == Shapes.Siccor)
                {
                    points += 6 + Player.shapeScores[Player.shape];
                }
                else
                {
                    points += 3 + Player.shapeScores[Player.shape];
                }

            }

            return points;
        }

        // PART 2 Methods
        public int RoundPartTwo(string playerShape, string opponentShape)
        {
            Opponent.shape = Opponent.mapping[char.Parse(opponentShape)];
            Player.Condition = Player.mappingPartTwo[char.Parse(playerShape)];
            CalcPointsPartTwo();
            return Player.Score;
        }

        public void CalcPointsPartTwo()
        {
            if (Player.Condition == Condition.DRAW)
            {
                if (Opponent.shape == Shapes.Siccor)
                {
                    Player.Score += 3 + Player.shapeScores[Shapes.Siccor];
                }
                else if (Opponent.shape == Shapes.Paper)
                {
                    Player.Score += 3 + Player.shapeScores[Shapes.Paper];
                }
                else
                {
                    Player.Score += 3 + Player.shapeScores[Shapes.Rock];
                }
            }
            else if (Player.Condition == Condition.LOOSE)
            {
                if (Opponent.shape == Shapes.Siccor)
                {
                    Player.Score += 0 + Player.shapeScores[Shapes.Paper];
                }
                else if (Opponent.shape == Shapes.Paper)
                {
                    Player.Score += 0 + Player.shapeScores[Shapes.Rock];
                }
                else
                {
                    Player.Score += 0 + Player.shapeScores[Shapes.Siccor];
                }
            }
            else
            {
                if (Opponent.shape == Shapes.Siccor)
                {
                    Player.Score += 6 + Player.shapeScores[Shapes.Rock];
                }
                else if (Opponent.shape == Shapes.Paper)
                {
                    Player.Score += 6 + Player.shapeScores[Shapes.Siccor];
                }
                else
                {
                    Player.Score += 6 + Player.shapeScores[Shapes.Paper];
                }
            }
        }
    }

    public class Player
    {
        public int Score { get; set; }
        public Condition Condition;

        public Dictionary<Shapes, int> shapeScores = new Dictionary<Shapes, int>()
        {
            {Shapes.Rock , 1 },
            {Shapes.Paper , 2 },
            {Shapes.Siccor , 3 }
        };

        public Dictionary<char, Shapes> mapping = new Dictionary<char, Shapes>()
        {
            {'Y', Shapes.Paper },
            {'X', Shapes.Rock },
            {'Z', Shapes.Siccor }
        };

        public Dictionary<char, Condition> mappingPartTwo = new Dictionary<char, Condition>()
        {
            {'Y', Condition.DRAW },
            {'X', Condition.LOOSE },
            {'Z', Condition.WIN }
        };

        public Shapes shape { get; set; }

        public Player(int score)
        {
            this.Score = score;

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

    public enum Condition
    {
        WIN,
        LOOSE,
        DRAW
    }
}
