using System;





class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bonjour Tout Le Monde!");

        List<int> numbers = new List<int>{1,2,32};

        numbers.Add(109);
        numbers.Add(0);


        Circle myCircle = new Circle(10);
        Console.WriteLine($"{myCircle.GetArea()}");

        Circle unitCircle = new Circle(1);
        Console.WriteLine($"{unitCircle.GetCircumference()}");
        Console.WriteLine($"{unitCircle.GetDiameter()}");
    }
    
}
