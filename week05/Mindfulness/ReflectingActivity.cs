using System;
using System.Collections.Generic;

namespace Mindfulness
{
    public class ReflectingActivity : Activity
    {
        private List<string> _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private List<string> _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        private Random _rand = new Random();

        public ReflectingActivity()
            : base("Reflecting Activity",
                   "This activity will help you reflect on times in your life when you have shown strength and resilience. It will prompt you to think more deeply about those times.")
        {
        }

        public override void Run()
        {
            Start();

            Console.WriteLine();
            string prompt = _prompts[_rand.Next(_prompts.Count)];
            Console.WriteLine("Consider the following prompt:");
            Console.WriteLine($"--- {prompt} ---");
            Console.WriteLine();
            Console.WriteLine("When you have something in mind, press Enter to continue.");
            Console.ReadLine();

            DateTime endTime = DateTime.Now.AddSeconds(_durationSeconds);
            while (DateTime.Now < endTime)
            {
                string q = _questions[_rand.Next(_questions.Count)];
                Console.WriteLine();
                Console.WriteLine(q);
                PauseWithSpinner(5); // pause between questions
                Console.WriteLine();
            }

            End();
        }
    }
}