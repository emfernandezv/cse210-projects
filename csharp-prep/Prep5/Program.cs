using System;

class Program
{
    static void Main(string[] args)
    {
        string name; 
        int num,result;
        static void DisplayWelcome(){
            Console.WriteLine("Welcome to the program!");
        };

        string PrompUserName(){
            Console.Write("What is your name?: ");
            string name = Console.ReadLine();
            //Console.WriteLine($"Your name is {name}");
            return name;
        };

        int PrompUserNumber(){
            Console.Write("What is your favorite number?: ");
            int favNumber = int.Parse(Console.ReadLine());
            //Console.WriteLine($"Your favorite number is {favNumber}");
            return favNumber;
        };

        int SquareNumber( int value){
            int result = value * value;
            return result;
        };


        static void DisplayResult (string nam, int res){
             Console.WriteLine($"{nam}, the square of your number is {res}");
        };

        DisplayWelcome();
        name = PrompUserName();
        num = PrompUserNumber();
        result = SquareNumber(num);
        DisplayResult(name,result);
    }
}