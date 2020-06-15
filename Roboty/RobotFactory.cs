using System;
using System.Collections.Generic;
using System.Linq;

namespace Roboty
{
    public static class RobotFactory
    {
        public static int Repetitions = 0;
        public static (int Letter, int Number) NameLength = (2, 3);

        private static List<Robot> _robots = new List<Robot>();
        private static Random _random = new Random();

        private static List<string> _types = new List<string>
            {
                "Translator",
                "CoffeeMaking",
                "Bartender",
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
            string letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numbers = "0123456789";

            var randomletters = letters.GetRandom(NameLength.Letter);
            var randomnumbers = numbers.GetRandom(NameLength.Number);

            var newRobot = new Robot
            {
                Name = new string(randomletters + randomnumbers),
                Type = _types[_random.Next(_types.Count)]
            };

            var isUnique = !_robots.Any(r => r.Name == newRobot.Name);

            robot = newRobot;

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

                if(success)
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
            ResetRobot(_robots[index]);
        }
    }
}
