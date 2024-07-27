using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // List of activities
        List<Activity> activities = new List<Activity>
        {
            new Breathing("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing."),
            new Reflection("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life."),
            new Listing("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        };

        while (true)
        {
            int choice = Menu.DisplayMenu(activities);
            if (choice == -1)
            {
                break; // exit the program
            }
            activities[choice].RunActivity();
        }
    }

    class Menu
    {
        public static int DisplayMenu(List<Activity> activities)
        {
            Console.Clear();
            Console.WriteLine("Select an activity to begin:");
            for (int i = 0; i < activities.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {activities[i].Name}");
            }
            Console.WriteLine("Type the number of the activity or type 'quit' to exit:"); // type quit instead of number 4 in the menu
            string userInput = Console.ReadLine();
            if (userInput.ToLower() == "quit")
            {
                return -1;
            }
            if (int.TryParse(userInput, out int choice) && choice > 0 && choice <= activities.Count)
            {
                return choice - 1;
            }
            return -1; // invalid choice
        }
    }

    public class FlaggedString
    {
        private string _prompt;
        private bool _hasBeenUsed;

        public FlaggedString(string prompt)
        {
            _prompt = prompt;
            _hasBeenUsed = false;
        }

        public string GetPrompt()
        {
            return _prompt;
        }

        public bool GetHasBeenUsed()
        {
            return _hasBeenUsed;
        }

        public void SetHasBeenUsed(bool used)
        {
            _hasBeenUsed = used;
        }
    }
}
