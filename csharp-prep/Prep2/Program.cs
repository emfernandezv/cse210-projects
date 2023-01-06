using System;

class Program
{
    static void Main(string[] args)
    {
        
        //declare
        double gradePerc;
        string letter, sign = "";

        //Core Requirements

        Console.WriteLine("Please insert your grade percentage:");
        gradePerc =  float.Parse(Console.ReadLine());

        if (gradePerc >= 90){
            letter = "A";
        } else if (gradePerc >= 80){
            letter = "B";
        } else if (gradePerc >= 70){
            letter = "C";
        } else if (gradePerc >= 60){
            letter = "D";
        } else {
            letter = "F";
        };

        Console.WriteLine($"You grade is: {letter}");

        if (gradePerc >= 70){
            Console.WriteLine("Congratulations, you passed!");
        } else {
            Console.WriteLine("Better luck next time. Keep practicing!");
        };

        //Stretch Challenge

        //Sign determination
        gradePerc =  Math.Round((gradePerc / 10) %1,1)*10;
        
        if (gradePerc >= 7){
            sign = "+";
        } else if (gradePerc < 3){
            sign = "-";
        };

        //No A+ Determination
        if (letter == "A" && sign == "+"){
            sign = "";
        };

        //No F+ or F- Determination
        if (letter == "F"){
            sign = "";
        }

        Console.WriteLine($"You final grade is: {letter}{sign}");

    }
}