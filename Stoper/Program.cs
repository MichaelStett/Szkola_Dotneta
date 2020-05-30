using System;

using static System.Console;

namespace Stoper
{
    public class MyStoper
    {
        private bool _isRunning = false;
        private DateTime? _startTime;
        private DateTime? _endTime;

        public double Time
        {
            get
            {
                if (_isRunning == false && _endTime is not null && _startTime is not null)
                {
                    return (_endTime - _startTime).Value.TotalSeconds;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public void Start()
        {
            if (_isRunning == false)
            {
                _isRunning = true;
                _startTime = DateTime.Now;
            }
            else
            {
                throw new InvalidOperationException("Stoper is running already.");
            }
        }

        public void Stop()
        {
            if (_isRunning == true)
            {
                _isRunning = false;
                _endTime = DateTime.Now;
            }
            else
            {
                throw new InvalidOperationException("Stoper is not running.");
            }
        }

        public void Restart()
        {
            _startTime = null;
            _endTime = null;
            _isRunning = false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var stoper = new MyStoper();

            while (true)
            {
                stoper.Start();

                WriteLine("Press any key to stop."); ReadKey();
                stoper.Stop();
                Clear(); WriteLine($"Elapsed: {stoper.Time}s.");

                WriteLine("Press any key to restart."); ReadKey();
                stoper.Restart();

                WriteLine("Press any key to stop."); ReadKey();
                stoper.Stop();
                Clear(); WriteLine($"Elapsed: {stoper.Time}s.");

                WriteLine("Press any key to stop."); ReadKey();
                stoper.Stop();
                Clear(); WriteLine($"Elapsed: {stoper.Time}s.");
            }
        }
    }
}
