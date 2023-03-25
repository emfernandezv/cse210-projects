public class Expense : Financial{
    public Expense(string name, double amount, DateTime date) : base(name, amount, date){}

    public override double GetAmount(){
        return _amount * -1;
    }
    public override string ToString(){
        return string.Format("{0}: -{1:C} ({2})", GetName(), GetAmount(), GetDate());
    }
}
