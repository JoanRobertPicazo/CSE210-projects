using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    private static List<Goal> goals = new List<Goal>(); // list of goals
    private static int points = 0; // total points

    public static void Main(string[] args)
    {
        bool quit = false; // quit flag

        while (!quit)
        {
            Menu.DisplayMainMenu(); // display menu
            int choice = int.Parse(Console.ReadLine()); // read choice

            switch (choice)
            {
                case 1:
                    CreateGoal();
                    break;
                case 2:
                    ListGoals();
                    break;
                case 3:
                    SaveGoals();
                    break;
                case 4:
                    LoadGoals(); 
                    break;
                case 5:
                    RecordEvent();
                    break;
                case 6:
                    quit = true; // set quit flag
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    private static void CreateGoal()
    {
        Menu.DisplayCreateGoalMenu(); // display create goal menu
        int choice = int.Parse(Console.ReadLine()); // read choice

        switch (choice)
        {
            case 1:
                Console.Write("Enter name: ");
                string name = Console.ReadLine();
                Console.Write("Enter description: ");
                string description = Console.ReadLine();
                Console.Write("Enter points: ");
                int points = int.Parse(Console.ReadLine()); // read points
                goals.Add(new SimpleGoal(name, description, points, false)); // add simple goal
                break;
            case 2:
                Console.Write("Enter name: ");
                name = Console.ReadLine();
                Console.Write("Enter description: ");
                description = Console.ReadLine();
                Console.Write("Enter points: ");
                points = int.Parse(Console.ReadLine());
                goals.Add(new EternalGoal(name, description, points)); // add eternal goal
                break;
            case 3:
                Console.Write("Enter name: ");
                name = Console.ReadLine();
                Console.Write("Enter description: ");
                description = Console.ReadLine();
                Console.Write("Enter points: ");
                points = int.Parse(Console.ReadLine()); // read points
                Console.Write("Enter required completions: ");
                int requiredCompletions = int.Parse(Console.ReadLine()); // read completions
                Console.Write("Enter bonus points: ");
                int bonusPoints = int.Parse(Console.ReadLine()); // read bonus points
                goals.Add(new ChecklistGoal(name, description, points, requiredCompletions, bonusPoints)); // add checklist goal
                break;
            default:
                Console.WriteLine("Invalid choice."); // invalid choice
                break;
        }
    }

    private static void ListGoals()
    {
        Console.WriteLine("The goals are:");
        int count = 1; // goal counter

        foreach (Goal goal in goals)
        {
            string status = goal.IsComplete ? "[X]" : "[ ]"; // goal status
            string goalInfo = $"{count}. {status} {goal.Name} ({goal.Description}) - {goal.Points} points"; // goal info
            if (goal is ChecklistGoal checklistGoal)
            {
                goalInfo += $" -- Currently completed: {checklistGoal.CurrentCompletions}/{checklistGoal.RequiredCompletions}"; // checklist goal info
            }
            Console.WriteLine(goalInfo); // display goal info
            count++; // increment counter
        }
    }

    private static void SaveGoals()
    {
        Console.Write("Enter the filename to save the goals: ");
        string filename = Console.ReadLine(); // read filename

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(points); // write points
            foreach (Goal goal in goals)
            {
                writer.WriteLine(goal.SaveGoal()); // write goal
            }
        }
    }

    private static void LoadGoals()
    {
        Console.Write("Enter the filename to load the goals: ");
        string filename = Console.ReadLine(); // read filename

        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename); // read lines
            points = int.Parse(lines[0]); // read points
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(':'); // split line
                string goalType = parts[0]; // goal type
                string[] goalParts = parts[1].Split(','); // goal parts

                Goal goal;
                switch (goalType)
                {
                    case "SimpleGoal":
                        goal = new SimpleGoal(); // create simple goal
                        break;
                    case "EternalGoal":
                        goal = new EternalGoal(); // create eternal goal
                        break;
                    case "ChecklistGoal":
                        goal = new ChecklistGoal(); // create checklist goal
                        break;
                    default:
                        throw new FormatException("Unknown goal type."); // unknown type
                }

                goal.LoadGoal(goalParts); // load goal
                goals.Add(goal); // add goal
            }
        }
        else
        {
            Console.WriteLine("File not found."); // file not found
        }
    }

    private static void RecordEvent()
    {
        Console.WriteLine("Select a goal to record an event:");
        ListGoals(); // list goals
        int choice = int.Parse(Console.ReadLine()); // read choice
        if (choice > 0 && choice <= goals.Count)
        {
            goals[choice - 1].RecordEvent(); // record event
            points += goals[choice - 1].Points; // add points
        }
        else
        {
            Console.WriteLine("Invalid choice."); // invalid choice
        }
    }
}
