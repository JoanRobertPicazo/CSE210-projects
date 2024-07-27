using System;

public class Breathing : Activity
{
    public Breathing(string name, string description) : base(name, description) { }

    public override void RunActivity()
    {
        DisplayGreeting();
        int elapsed = 0;
        while (elapsed < Duration)
        {
            Console.Clear();
            Console.WriteLine("Breathe in...");
            DisplaySpinner(3);
            Console.Clear();
            Console.WriteLine("Now breathe out...");
            DisplaySpinner(3);
            elapsed += 6;
        }
        DisplayEnding();
    }
}
