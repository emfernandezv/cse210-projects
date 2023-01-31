public class Fraction{
    private int _top ;
    private int _bottom;

    //CONSTRUCTORS
    public Fraction(){
        _top = 1;
        _bottom = 1;
    }

    public Fraction(int nominator  ){
        _top = nominator ;
        _bottom = 1;
    }

    public Fraction(int nominator, int denominator  ){
        _top = nominator ;
        _bottom = denominator;
    }

    //SETTERS
    public void setNominator(int nominator){
        _top = nominator;
    }

    public void setDenominator(int denominator){
        _bottom = denominator;
    }

    //GETTERS
    public int getNominator(){
        return _top;
    }

    public int getDenominator(){
        return _bottom;
    }

    //METHODS
    public string GetFractionString(){
        string variable = $"{_top}/{_bottom}";
        return variable;
    }

    public decimal GetDecimalValue (){
        decimal variable = (decimal)_top/(decimal)_bottom;
        return variable;
    }
}