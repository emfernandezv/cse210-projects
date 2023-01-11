using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int mainNumber = randomGenerator.Next(1, 101);

        //Console.WriteLine(" What is the magic number?");
        //int mainNumber = int.Parse(Console.ReadLine());
        Console.WriteLine(" What is your guess?");
        int guessNumber = int.Parse(Console.ReadLine());

        while (guessNumber != mainNumber){
            if (guessNumber < mainNumber){
                Console.WriteLine("Higher");
                Console.WriteLine(" What is your guess?");
                guessNumber = int.Parse(Console.ReadLine());
            } else if (guessNumber > mainNumber){
                Console.WriteLine("Lower");
                Console.WriteLine(" What is your guess?");
                guessNumber = int.Parse(Console.ReadLine());
            };
        };
    
        if (mainNumber == guessNumber) {
            Console.WriteLine("You guessed it");
             System.Environment.Exit(1);
        };
    }
}