public class Budget{
    public List<Financial> _transactions;
    public Budget(){
        _transactions = new List<Financial>();
    }
    public void AddTransaction(Financial transaction){
        _transactions.Add(transaction);
    }    
    public double GetTotal(string type){
        double totalValue = 0;
        foreach (Financial transaction in _transactions){
            if(type == "income"){
                if (transaction is Income){
                    totalValue += transaction.GetAmount();
                }
            }else{
                if (transaction is Expense){
                    totalValue += transaction.GetAmount();
                }
            }
        }
        return totalValue;
    }
    public double GetBalance(){
        double totalIncome = GetTotal("income");
        double totalExpenses = GetTotal("expense");
        return totalIncome + totalExpenses;
    }
    public List<Financial> GetTransactions(){
        return _transactions;
    }
}