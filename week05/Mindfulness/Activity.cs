using System;
using System.Threading;

namespace Mindfulness
{
    public abstract class Activity
    {
        protected string _name;
        protected string _description;
        protected int _durationSeconds;

        protected Activity(string name, string description)
        {
            _name = name;
            _description = description;
            _durationSeconds = 0;
        }

        // Common starting behavior: show name, description and prompt for duration.
        public void Start()
        {
            Console.Clear();
            Console.WriteLine($"--- {_name} ---");
            Console.WriteLine();
            Console.WriteLine(_description);
            Console.WriteLine();

            _durationSeconds = PromptForDuration();

            Console.WriteLine();
            Console.WriteLine("Get ready...");
            PauseWithSpinner(3);
        }

        private int PromptForDuration()
        {
            int seconds = 0;
            while (true)
            {
                Console.Write("Enter duration in seconds: ");
                var input = Console.ReadLine();
                if (int.TryParse(input, out seconds) && seconds > 0)
                    return seconds;
                Console.WriteLine("Please enter a positive integer.");
            }
        }

        protected void ShowSpinner(int seconds)
        {
            char[] spinner = new char[] { '|', '/', '-', '\\' };
            int delay = 250; // ms
            int iterations = Math.Max(1, (seconds * 1000) / delay);
            for (int i = 0; i < iterations; i++)
            {
                Console.Write(spinner[i % spinner.Length]);
                Thread.Sleep(delay);
                Console.Write("\b \b");
            }
        }

        protected void ShowCountdown(int seconds)
        {
            for (int i = seconds; i >= 1; i--)
            {
                string s = i.ToString();
                Console.Write(s);
                Thread.Sleep(1000);
                for (int j = 0; j < s.Length; j++)
                    Console.Write("\b \b");
            }
        }

        protected void PauseWithSpinner(int seconds)
        {
            ShowSpinner(seconds);
        }

        // Common ending behavior.
        public void End()
        {
            Console.WriteLine();
            Console.WriteLine("Well done!");
            Console.WriteLine($"You completed the {_name} for {_durationSeconds} seconds.");
            PauseWithSpinner(3);
        }

        public abstract void Run();
    }
}