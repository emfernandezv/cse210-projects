public class Budget{
    public List<Financial> _transactions;
    public Budget(){
        _transactions = new List<Financial>();
    }

    public void AddTransaction(Financial transaction){
        _transactions.Add(transaction);
    }

    public double GetTotalIncome(){
        double totalIncome = 0;
        foreach (Financial transaction in _transactions){
            if (transaction is Income){
                totalIncome += transaction.getAmount();
            }
        }
        return totalIncome;
    }
    public double GetTotalExpenses(){
        double totalExpenses = 0;
        foreach (Financial transaction in _transactions){
            if (transaction is Expense){
                totalExpenses += transaction.getAmount();
            }
        }
        return totalExpenses;
    }
    public double GetBalance(){
        double totalIncome = GetTotalIncome();
        double totalExpenses = GetTotalExpenses();
        return totalIncome - totalExpenses;
    }
    public List<Financial> GetTransactions(){
        return _transactions;
    }
}