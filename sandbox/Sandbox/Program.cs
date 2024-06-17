using System;

class Program
{
    
    

    static double CalculateCircleArea(double radius) 
    {
        double area = 0;
        area = Math.PI * radius *radius;
        return area; 
    }

    static void Main(string[] args)
    {
         
        Console.WriteLine("Hello Sandbox World!");
        double area = CalculateCircleArea(10);
        Console.WriteLine($"F3: The circle's area is: {area.ToString("F3")}");
        Console.WriteLine($"F10: The circle's area is: {area.ToString("F10")}");
        Console.WriteLine($"E: The circle's area is: {area.ToString("E")}");
        Console.WriteLine($"C2: The circle's area is: {area.ToString("C2")}");
        
        int x = 65536;
        Console.WriteLine($"N: The circle's area is: {x.ToString("N")}");
        Console.WriteLine($"X: The circle's area is: {x.ToString("B")}");
        x = 65536;
        Console.WriteLine($"X: The circle's area is: {x.ToString("X")}");


        for(int j=0; j < 10; j++)
        {
            Console.WriteLine   (j);
        }

        // int userAge = -1;
        
        // while (userAge < 0 || userAge > 120)
        // {
        //     Console.WriteLine("Please input your age (0-120)");
        //     userAge = int.Parse(Console.ReadLine());
        // }

        // int userAge2;

        // do
        // {
        //     Console.WriteLine("Please input your age (0-120)");
        //     userAge2 = int.Parse(Console.ReadLine());
        // } while (userAge2 < 0 || userAge2 > 120);

        // for(int i = -10234; i < 100000; i+= 1000) // for i in range 100
        // {
        //     Console.WriteLine("" + i);
        // }

        // List<int> myNumbers = new List<int>{1,2,3,4,5,6,7,8};
        // List<string> myNames = new List<string>();
        
        // myNames.Add("Bob");
        // myNames.Add("Billy");
        // myNames.Add("Betty");

        // myNumbers.Add(12);

        // foreach(string name in myNames)
        // {
        //     Console.WriteLine("" + name );
        // }


    }

}