public abstract class Financial{
    protected string _name;
    protected double _amount;
    protected DateTime _date;

    public Financial(string name, double amount, DateTime date){
        setName(name);
        setAmount(amount);
        setDate(date);
    }
    public string getName(){
        return _name;
    }
    public virtual double getAmount(){
        return _amount;
    }
    public string getDate(){
        return _date.ToShortDateString();
    }
    private void setName(string name){
        _name = name;
    }
    private void setAmount(double amount){
        _amount = amount;
    }
    private void setDate(DateTime date){
        _date = date;
    }
    public abstract override string ToString();

    
}