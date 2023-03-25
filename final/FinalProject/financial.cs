public abstract class Financial{
    protected string _name;
    protected double _amount;
    protected DateTime _date;

    public Financial(string name, double amount, DateTime date){
        SetName(name);
        SetAmount(amount);
        SetDate(date);
    }
    public string GetName(){
        return _name;
    }
    public virtual double GetAmount(){
        return _amount;
    }
    public string GetDate(){
        return _date.ToShortDateString();
    }
    protected void SetName(string name){
        _name = name;
    }
    protected void SetAmount(double amount){
        _amount = amount;
    }
    protected void SetDate(DateTime date){
        _date = date;
    }
    public abstract override string ToString();

    
}