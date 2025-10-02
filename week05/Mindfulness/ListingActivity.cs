using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Mindfulness
{
    public class ListingActivity : Activity
    {
        private List<string> _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        private Random _rand = new Random();

        public ListingActivity()
            : base("Listing Activity",
                   "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        {
        }

        public override void Run()
        {
            Start();

            Console.WriteLine();
            string prompt = _prompts[_rand.Next(_prompts.Count)];
            Console.WriteLine("List as many responses as you can to the following prompt:");
            Console.WriteLine($"--- {prompt} ---");

            Console.WriteLine();
            Console.Write("You may begin in: ");
            ShowCountdown(5);
            Console.WriteLine();
            Console.WriteLine("Start listing (press Enter after each item):");

            DateTime endTime = DateTime.Now.AddSeconds(_durationSeconds);
            var items = ReadItemsUntil(endTime);

            Console.WriteLine();
            Console.WriteLine($"You entered {items.Count} item(s).");
            End();
        }

        // Non-blocking input collection until endTime.
        private List<string> ReadItemsUntil(DateTime endTime)
        {
            var result = new List<string>();
            var buffer = new StringBuilder();

            // Inform user how to stop early
            Console.WriteLine("(Tip: keep typing items and press Enter; input stops automatically when time is up.)");

            while (DateTime.Now < endTime)
            {
                if (!Console.KeyAvailable)
                {
                    Thread.Sleep(50);
                    continue;
                }

                var keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    string entry = buffer.ToString().Trim();
                    Console.WriteLine(); // move to next line in console
                    if (!string.IsNullOrEmpty(entry))
                    {
                        result.Add(entry);
                    }
                    buffer.Clear();
                }
                else if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (buffer.Length > 0)
                    {
                        buffer.Length--;
                        Console.Write("\b \b");
                    }
                }
                else
                {
                    buffer.Append(keyInfo.KeyChar);
                    Console.Write(keyInfo.KeyChar);
                }
            }

            // If user was mid-entry when time expired, add that entry if any non-empty
            if (buffer.Length > 0)
            {
                string entry = buffer.ToString().Trim();
                if (!string.IsNullOrEmpty(entry))
                    result.Add(entry);
            }

            return result;
        }
    }