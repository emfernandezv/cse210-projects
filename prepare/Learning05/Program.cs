using System;

class Program
{
    static void Main(string[] args)
    {   
        List<Shape> shapes = new List<Shape>();

        Square testSquare = new Square("White",10);
        shapes.Add(testSquare);
        //Console.WriteLine(testSquare.GetColor());
        //Console.WriteLine(testSquare.GetArea());

        Rectangle testRectangle = new Rectangle("Black",5,10);
        shapes.Add(testRectangle);
        //Console.WriteLine(testRectangle.GetColor());
        //Console.WriteLine(testRectangle.GetArea());

        Circle testCircle = new Circle("Red",10);
        shapes.Add(testCircle);
        //Console.WriteLine(testCircle.GetColor());
        //Console.WriteLine(testCircle.GetArea());

        foreach(Shape s in shapes){
            Console.WriteLine($"The color is: {s.GetColor()} and the Area is: {s.GetArea()}");
        }
    }
}