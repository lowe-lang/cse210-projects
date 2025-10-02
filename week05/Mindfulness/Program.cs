using System;

namespace Mindfulness
{
    class Program
    {
        // NOTE (creativity/extra credit): 
        // - This implementation centralizes shared behavior in Activity (spinner, countdown, prompts for duration).
        // - ListingActivity uses a non-blocking input loop (Console.KeyAvailable) so the listing truly stops when time is up.
        // - All classes keep their own prompts (no unused fields in base), and classes follow encapsulation.
        // Add a comment here on Canvas/Program.cs describing any extra features you implemented.

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Mindfulness Program");
                Console.WriteLine("-------------------");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflecting Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. Quit");
                Console.Write("Choose an option (1-4): ");
                var choice = Console.ReadLine();

                Activity activity = null;
                switch (choice)
                {
                    case "1":
                        activity = new BreathingActivity();
                        break;
                    case "2":
                        activity = new ReflectingActivity();
                        break;
                    case "3":
                        activity = new ListingActivity();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Press Enter to continue.");
                        Console.ReadLine();
                        continue;
                }

                activity.Run();
                Console.WriteLine();
                Console.WriteLine("Press Enter to return to the main menu...");
                Console.ReadLine();
            }
        }
    }
}