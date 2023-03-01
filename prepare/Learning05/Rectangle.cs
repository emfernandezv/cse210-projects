public class Rectangle:Shape{
    
    private double _length;
    private double _width;

    public Rectangle(string color,double width, double legnth):base(color) {
        _width = width;
        _length = legnth;
    }

    public override double GetArea(){
        return _width*_length;
    }


}