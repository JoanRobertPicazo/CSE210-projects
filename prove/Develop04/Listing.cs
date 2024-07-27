using System;
using System.Collections.Generic;

public class Listing : Activity
{
    private List<Program.FlaggedString> _prompts;

    public Listing(string name, string description) : base(name, description)
    {
        SetPrompts();
    }

    public override void RunActivity()
    {
        DisplayGreeting();
        var random = new Random();
        var prompt = _prompts[random.Next(_prompts.Count)];
        Console.WriteLine(prompt.GetPrompt());
        DisplaySpinner(3);

        int elapsed = 0;
        List<string> items = new List<string>();
        while (elapsed < Duration)
        {
            Console.Write("List an item: ");
            items.Add(Console.ReadLine());
            elapsed += 2; // approximate time for user input
        }
        Console.WriteLine($"You listed {items.Count} items.");
        DisplayEnding();
    }

    private void SetPrompts()
    {
        _prompts = new List<Program.FlaggedString>
        {
            new Program.FlaggedString("Who are people that you appreciate?"),
            new Program.FlaggedString("What are personal strengths of yours?"),
            new Program.FlaggedString("Who are people that you have helped this week?"),
            new Program.FlaggedString("When have you felt the Holy Ghost this month?"),
            new Program.FlaggedString("Who are some of your personal heroes?")
        };
    }
}
