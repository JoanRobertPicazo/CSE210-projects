using System;

class Program
{
    static void Main()
    {
        Journal journal = new Journal();

        string[] prompts = 
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What is something that happened today that you are greatful for?", // Prompts Added
            "What is something that you improved in today?",
            "What is something that you would like to remember from today?",
            "How did you acchive your daily goals?",
            "What obstacle did you overcome today?",
            "What caught you by surprise today?",
            "How were you 1% better today than you were yesterday?",
            "What did you learn today",
            "What is something that you can do better tommorow because of today",
            "What would you do differently because of today?"
        };

        while (true)
        {
            Console.WriteLine("Please select one of the following choises");
            Console.WriteLine("1. Write an entry"); //More detail in what the user is doing
            Console.WriteLine("2. Display your current entries");
            Console.WriteLine("3. Load a journal from a file");
            Console.WriteLine("4. Save your entries as a file");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do?: ");
            string choice = Console.ReadLine();

            switch(choice)
            {
                case "1":
                    Random rand = new Random();
                    string prompt = prompts[rand.Next(prompts.Length)];
                    Console.Write($"{prompt} \n> ");
                    string response = Console.ReadLine();
                    string date = DateTime.Now.ToShortDateString();
                    journal.AddEntry(prompt, response, date);
                    Console.WriteLine(); //Separate each eatry by a space for organization
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    Console.Write("Enter file name to load: ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    break;
                case "4":
                    Console.Write("What is the file name: ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("That number is not part of the choises, please type a number from 1 to 5.");
                    break;         
            }
        }
    }
}