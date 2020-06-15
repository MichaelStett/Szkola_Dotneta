using static System.Console;

namespace Roboty
{
    class Program
    {
        static void Main(string[] args)
        {
            RobotFactory.Create(5);

            RobotFactory.NameLength = (2, 3);

            foreach (var robot in RobotFactory.GetRobots())
            {
                WriteLine(robot);
            }
            WriteLine();

            RobotFactory.ResetRobot(8);

            foreach (var robot in RobotFactory.GetRobots())
            {
                WriteLine(robot);
            }
            WriteLine();

            RobotFactory.ResetRobot(RobotFactory.GetRobots()[1]);

            foreach (var robot in RobotFactory.GetRobots())
            {
                WriteLine(robot);
            }
            WriteLine();

            WriteLine(RobotFactory.Repetitions);
        }
    }
}
