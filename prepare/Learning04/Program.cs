using System;

class Program
{
    static void Main(string[] args)
    {
        
        Assignment assignment1 = new Assignment();
        Console.WriteLine(assignment1.getSummary());

        Assignment assignment2 = new Assignment("Samuel Bennett","Multiplication");
        Console.WriteLine(assignment2.getSummary());

        MathAssignment mathAssignment1 = new MathAssignment();
        Console.WriteLine(mathAssignment1.getSummary());
        Console.WriteLine(mathAssignment1.getHomeWorkList());

        MathAssignment mathAssignment2 = new MathAssignment("Roberto Rodriguez","Fractions","7.3","8-19");
        Console.WriteLine(mathAssignment2.getSummary());
        Console.WriteLine(mathAssignment2.getHomeWorkList());

        WritingAssignment writingAssignment1 = new WritingAssignment();
        Console.WriteLine(writingAssignment1.getSummary());
        Console.WriteLine(writingAssignment1.getWritingInformation());

        WritingAssignment writingAssignment2 = new WritingAssignment("Mary Waters","European History","The Causes of World War II");
        Console.WriteLine(writingAssignment2.getSummary());
        Console.WriteLine(writingAssignment2.getWritingInformation());
    }
}