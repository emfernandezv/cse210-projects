public class Income : Financial{
    public Income(string name, double amount, DateTime date) : base(name, amount, date){}

    public override double getAmount(){
        return _amount;
    }
    public override string ToString(){
        return string.Format("{0}: {1:C} ({2})", getName(), getAmount(), getDate());
    }
}