using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the program!");

        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();

        Console.Write("Please enter your favorite number: ");
        string numberAnswer = Console.ReadLine();
        int favoriteNumber = int.Parse(numberAnswer);

        int favoriteNumberSquared = favoriteNumber * favoriteNumber;

        Console.WriteLine($"{name}, the square of your number is {favoriteNumberSquared}");


    }
}