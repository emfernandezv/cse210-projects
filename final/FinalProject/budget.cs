public class Budget{
    public List<Financial> transactions;
    public Budget(){
        transactions = new List<Financial>();
    }
    public void AddTransaction(Financial transaction){
        transactions.Add(transaction);
    }    
    public double GetTotal(string type){
        double totalValue = 0;
        foreach (Financial transaction in transactions){
            if(type == "income"){
                if (transaction is Income){
                    totalValue += transaction.getAmount();
                }
            }else{
                if (transaction is Expense){
                    totalValue += transaction.getAmount();
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
        return transactions;
    }
}