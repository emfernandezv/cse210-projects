public class InputHandler{   
    private Budget _budget;

    public InputHandler(Budget budget){
        _budget = budget;
    }
    public Financial CreateIncome(){
        Console.WriteLine("Creating a new income...");
        Console.Write("Enter the name of the income: ");
        string name = Console.ReadLine();

        Console.Write("Enter the amount of the income: ");
        double amount = double.Parse(Console.ReadLine());

        Console.Write("Enter the date of the income (MM/DD/YYYY): ");
        DateTime date = DateTime.Parse(Console.ReadLine());

        return new Income(name, amount, date);
    }

    public Financial CreateExpense(){
        Console.WriteLine("Creating a new expense...");
        Console.Write("Enter the name of the expense: ");
        string name = Console.ReadLine();

        Console.Write("Enter the amount of the expense: ");
        double amount = double.Parse(Console.ReadLine());

        Console.Write("Enter the date of the expense (MM/DD/YYYY): ");
        DateTime date = DateTime.Parse(Console.ReadLine());

        return new Expense(name, amount, date);
    }

    public void SaveBudgetToFile(string filename){
        using (StreamWriter writer = new StreamWriter(filename)){
            foreach (Financial transaction in _budget._transactions){
                if (transaction is Income){
                    Income income = (Income)transaction;
                    writer.WriteLine($"Income,{income.getName()},{income.getAmount()},{income.getDate().ToShortDateString()}");
                } else if (transaction is Expense){
                    Expense expense = (Expense)transaction;
                    writer.WriteLine($"Expense,{expense.getName()},{expense.getAmount()},{expense.getDate().ToShortDateString()}");
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