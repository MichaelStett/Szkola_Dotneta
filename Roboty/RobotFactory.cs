using System;
using System.Collections.Generic;
using System.Linq;

namespace Roboty
{
    public static class RobotFactory
    {
        const string Letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string Numbers = "0123456789";

        public static int Repetitions = 0;
        public static (int Letter, int Number) NameLength = (2, 3);

        private static readonly List<Robot> _robots = new List<Robot>();
        private static readonly List<string> _types = new List<string>
        {
            "Translator", "CoffeeMaking", "Bartender",
        };


        static RobotFactory()
        { }

        public static void Create(int count)
        {
            do
            {
                var success = TryCreateUnique(out var robot);

                if (success)
                {
                    _robots.Add(robot);
                    count--;
                }
                else
                {
                    Repetitions++;
                }

            } while (count > 0);
        }

        private static bool TryCreateUnique(out Robot robot)
        {
            var random = new Random();

            var randomLetters = Letters.GetRandom(NameLength.Letter);
            var randomNumbers = Numbers.GetRandom(NameLength.Number);

            var name = randomLetters + randomNumbers;

            var isUnique = !_robots.Any(r => r.Name == name);

            robot = new Robot
            {
                Name = name,
                Type = _types[random.Next(_types.Count)]
            };

            return isUnique;
        }

        public static List<Robot> GetRobots(int count = -1)
        {
            if (count < 0)
            {
                count = _robots.Count;
            }

            return _robots.Take(count).ToList();
        }

        public static void ResetRobot(Robot robot)
        {
            bool success;

            do
            {
                success = TryCreateUnique(out var newRobot);

                if (success)
                {
                    newRobot.Type = robot.Type;
                    _robots.Replace(robot, newRobot);
                }
                else
                {
                    Repetitions++;
                }

            } while (!success);
        }

        public static void ResetRobot(int index)
        {
            if (index < _robots.Count)
            {
                ResetRobot(_robots[index]);
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
