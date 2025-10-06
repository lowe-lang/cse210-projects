// Program.cs
using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager gm = new GoalManager();
        string dataFile = "data/goals.txt";

        while (true)
        {
            Console.WriteLine("\nEternal Quest - Menu");
            Console.WriteLine("1. Create goal");
            Console.WriteLine("2. List goals");
            Console.WriteLine("3. Record event");
            Console.WriteLine("4. Save goals");
            Console.WriteLine("5. Load goals");
            Console.WriteLine("6. Show score");
            Console.WriteLine("0. Quit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            if (choice == "0") break;
            switch (choice)
            {
                case "1":
                    CreateGoalMenu(gm);
                    break;
                case "2":
                    gm.ListGoals();
                    break;
                case "3":
                    gm.ListGoals();
                    Console.Write("Which goal number did you complete? ");
                    if (int.TryParse(Console.ReadLine(), out int n))
                        gm.RecordEvent(n - 1);
                    break;
                case "4":
                    System.IO.Directory.CreateDirectory("data");
                    gm.Save(dataFile);
                    break;
                case "5":
                    gm.Load(dataFile);
                    break;
                case "6":
                    gm.ShowScore();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    static void CreateGoalMenu(GoalManager gm)
    {
        Console.WriteLine("Choose goal type:");
        Console.WriteLine("1. Simple");
        Console.WriteLine("2. Eternal");
        Console.WriteLine("3. Checklist");
        Console.Write("Choice: ");
        var c = Console.ReadLine();
        Console.Write("Title: ");
        var title = Console.ReadLine();
        Console.Write("Description: ");
        var desc = Console.ReadLine();
        Console.Write("Points per occurence: ");
        int points = int.Parse(Console.ReadLine() ?? "0");

        switch (c)
        {
            case "1":
                gm.AddGoal(new SimpleGoal(title, desc, points));
                break;
            case "2":
                gm.AddGoal(new EternalGoal(title, desc, points));
                break;
            case "3":
                Console.Write("Required count to complete: ");
                int req = int.Parse(Console.ReadLine() ?? "0");
                Console.Write("Bonus points on completion: ");
                int bonus = int.Parse(Console.ReadLine() ?? "0");
                gm.AddGoal(new ChecklistGoal(title, desc, points, req, bonus));
                break;
            default:
                Console.WriteLine("Invalid type.");
                break;
        }
    }
}
