using System;
using System.Collections.Generic;

public class Reflection : Activity
{
    private List<Program.FlaggedString> _prompts;
    private List<Program.FlaggedString> _questions;

    public Reflection(string name, string description) : base(name, description)
    {
        SetPromptsAndQuestions();
    }

    public override void RunActivity()
    {
        DisplayGreeting();
        var random = new Random();
        var prompt = _prompts[random.Next(_prompts.Count)];
        Console.WriteLine(prompt.GetPrompt());
        DisplaySpinner(3);

        int elapsed = 0;
        while (elapsed < Duration)
        {
            var question = _questions[random.Next(_questions.Count)];
            Console.WriteLine(question.GetPrompt());
            DisplaySpinner(5);
            elapsed += 5;
        }
        DisplayEnding();
    }

    private void SetPromptsAndQuestions()
    {
        _prompts = new List<Program.FlaggedString>
        {
            new Program.FlaggedString("Think of a time when you stood up for someone else."),
            new Program.FlaggedString("Think of a time when you did something really difficult."),
            new Program.FlaggedString("Think of a time when you helped someone in need."),
            new Program.FlaggedString("Think of a time when you did something truly selfless.")
        };

        _questions = new List<Program.FlaggedString>
        {
            new Program.FlaggedString("Why was this experience meaningful to you?"),
            new Program.FlaggedString("Have you ever done anything like this before?"),
            new Program.FlaggedString("How did you get started?"),
            new Program.FlaggedString("How did you feel when it was complete?"),
            new Program.FlaggedString("What made this time different than other times when you were not as successful?"),
            new Program.FlaggedString("What is your favorite thing about this experience?"),
            new Program.FlaggedString("What could you learn from this experience that applies to other situations?"),
            new Program.FlaggedString("What did you learn about yourself through this experience?"),
            new Program.FlaggedString("How can you keep this experience in mind in the future?")
        };
    }
}
