public class Report
{
    private Budget _budget;

    public Report(Budget budget){
        _budget = budget;
    }

    public void GenerateReport(){
        double totalIncome = _budget.GetTotalIncome();
        double totalExpenses = _budget.GetTotalExpenses();
        double netIncome = _budget.GetBalance();
        Console.WriteLine("----- REPORT -----");
        Console.WriteLine("Total income: " + totalIncome.ToString("C"));
        Console.WriteLine("Total expenses: " + totalExpenses.ToString("C"));
        Console.WriteLine("Net income: " + netIncome.ToString("C"));
        Console.WriteLine("------------------");
    }
}