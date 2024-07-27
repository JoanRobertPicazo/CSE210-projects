using System;
using System.Threading;

public class Activity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    protected int Duration;

    public Activity(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void DisplayGreeting()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {Name}\n{Description}\n");
        ObtainDuration();
        Console.WriteLine("Get ready...");
        Thread.Sleep(3000); // pause for 3 seconds
    }

    public void DisplayEnding()
    {
        Console.WriteLine($"Well done!!\n\nYou have completed another {Duration} seconds of the {Name}.");
        Thread.Sleep(3000); // pause for 3 seconds
    }

    protected void ObtainDuration()
    {
        Console.Write("How long, in seconds would you like for your session?: ");
        Duration = int.Parse(Console.ReadLine());
    }

    public virtual void RunActivity()
    {
        DisplayGreeting();
        // To be overridden by derived classes
        DisplayEnding();
    }

    protected void DisplaySpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write("/");
            Thread.Sleep(250);
            Console.Write("\b|");
            Thread.Sleep(250);
            Console.Write("\b-");
            Thread.Sleep(250);
            Console.Write("\b\\");
            Thread.Sleep(250);
            Console.Write("\b");
        }
    }
}
