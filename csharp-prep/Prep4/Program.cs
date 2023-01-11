using System;

class Program
{
    static void Main(string[] args)
    {
        
        List<int> numbers;
        numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int number = -1, sum = 0,smaller = 0,bigger = 0;
        while (number != 0){
            Console.WriteLine("Enter number:");
            number = int.Parse(Console.ReadLine());
            if (number != 0){
                numbers.Add(number);
            };
        };
        foreach( int num in numbers){
            sum += num;
            if (num > bigger){
                bigger = num;
            };
        };
        foreach( int num2 in numbers){
            if (bigger > num2){
                if (num2 > 0){
                    smaller = num2;
                };
            };
        };

        Console.WriteLine($"The sum is: {sum}");
        float avr = ((float)sum)/numbers.Count;
        Console.WriteLine($"The average is: {avr}");
        Console.WriteLine($"The largest number is: {bigger}");
        Console.WriteLine($"The smallest positive number is: {smaller}");
        numbers.Sort();
        Console.WriteLine("The Sorted list is:");
        foreach (int num3 in numbers){
            Console.WriteLine($"{num3}");
        };
    }
}