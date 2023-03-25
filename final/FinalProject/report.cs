public class Report
{
    private Budget _budget;
    public List<Financial> _transactions;

    public Report(Budget budget){
        _budget = budget;
    }
    public void ReportMenu(){
        Console.Clear();
        bool exit = false;
        Tools progress = new Tools();
        while (!exit){
            Console.WriteLine("\n--- REPORT MENU ---");
            Console.WriteLine("1. Resumed Report");
            Console.WriteLine("2. Detailed Report");
            Console.WriteLine("3. Return to Main Menu");
            Console.Write("Select an option: ");
            int option = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            switch (option){
                case 1:
                    progress.Loader(3);
                    GenerateReport();
                    break;
                case 2:
                    progress.Loader(3);
                    GenerateDetailedReport();
                    break;
                case 3:
                    exit = true;
                    break;
            }
        }
    }
    public void GenerateDetailedReport(){
        _transactions = _budget.GetTransactions();
        Console.WriteLine();
        Console.WriteLine("-----------------------------");
        Console.WriteLine("------ DETAILED REPORT ------");
        Console.WriteLine("-----------------------------");
        displayDetail("income");
        displayDetail("expense");
        Console.WriteLine("---------- BALANCE ----------");
        Console.WriteLine();
        Console.WriteLine("Net income: " + _budget.GetBalance().ToString("C"));
        Console.WriteLine();
        Console.WriteLine("-----------------------------");
        Console.WriteLine("-----------------------------");
        Console.WriteLine();
    }

    public void displayDetail(string type){
        int order = 0;
        Console.WriteLine($"---------- {type.ToUpper()} ----------");
        Console.WriteLine();
        foreach (Financial transaction in _transactions){
            if (type == "income"){
                if (transaction  is Income){
                    order += 1;
                    Console.WriteLine($"{order}. {transaction.GetName().ToUpper()} | {transaction.GetDate()} | {transaction.GetAmount()}");
                }
            }else{
                 if (transaction  is Expense){
                    order += 1;
                    Console.WriteLine($"{order}. {transaction.GetName().ToUpper()} | {transaction.GetDate()} | {transaction.GetAmount()}");
                }
            }
        }
        Console.WriteLine();
        Console.WriteLine($"Total {type}: " + _budget.GetTotal(type).ToString("C"));
        Console.WriteLine();
    }
    public void GenerateReport(){
        double totalIncome = _budget.GetTotal("income");
        double totalExpenses = _budget.GetTotal("expense");
        double netIncome = _budget.GetBalance();
        Console.WriteLine();
        Console.WriteLine("------------------------");
        Console.WriteLine("-------- REPORT --------");
        Console.WriteLine("Total income: " + totalIncome.ToString("C"));
        Console.WriteLine("Total expenses: " + totalExpenses.ToString("C"));
        Console.WriteLine("Net income: " + netIncome.ToString("C"));
        Console.WriteLine("------------------------");
        Console.WriteLine("------------------------");
        Console.WriteLine();
    }
}