using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1,101);
        
        int guess = 0;

        while (guess != magicNumber)
        {
            Console.Write("What is your guess?: ");
            string guessString = Console.ReadLine();
            guess = int.Parse(guessString);

            if (guess < magicNumber)
                {
                Console.WriteLine("Higher");
                }
            else if (guess > magicNumber)
                {
                Console.WriteLine("Lower");
                }
            else
            {
                Console.WriteLine("You guessed it!");
            }
 
        }
    }
}