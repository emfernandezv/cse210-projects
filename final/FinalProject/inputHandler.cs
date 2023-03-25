public class InputHandler{   
    private Budget _budget;

    public InputHandler(Budget budget){
        _budget = budget;
    }
    public Financial CreateTransaction(string type){
        Console.WriteLine($"Creating a new {type}...");
        Console.Write($"Enter the name of the {type}: ");
        string name = Console.ReadLine();
        Console.Write($"Enter the amount of the {type}: ");
        double amount = double.Parse(Console.ReadLine());
        Console.Write($"Enter the date of the {type} (MM/DD/YYYY): ");
        DateTime date = DateTime.Parse(Console.ReadLine());
        if (type == "income"){
            return new Income(name, amount, date);
        }else{
            return new Expense(name, amount, date);
        }
    }
    public void SaveBudgetToFile(string filename){
        using (StreamWriter writer = new StreamWriter(filename)){
            foreach (Financial transaction in _budget._transactions){
                if (transaction is Income){
                    Income income = (Income)transaction;
                    writer.WriteLine($"Income,{income.GetName()},{income.GetAmount()},{income.GetDate()}");
                } else if (transaction is Expense){
                    Expense expense = (Expense)transaction;
                    writer.WriteLine($"Expense,{expense.GetName()},{expense.GetAmount()},{expense.GetDate()}");
                }
            }
        }
    }
    public Budget LoadBudgetFromFile(string filename){
        using (StreamReader reader = new StreamReader(filename)){
            string line;
            while ((line = reader.ReadLine()) != null){
                string[] fields = line.Split(',');
                if (fields.Length == 4){
                    string type = fields[0];
                    string name = fields[1];
                    double amount = double.Parse(fields[2]);
                    DateTime date = DateTime.Parse(fields[3]);
                    if (type == "Income"){
                        Income income = new Income(name, amount, date);
                        _budget.AddTransaction(income);
                    } else if (type == "Expense"){
                        Expense expense = new Expense(name, amount, date);
                        _budget.AddTransaction(expense);
                    }
                }
            }
        }
        return _budget;
    }
}