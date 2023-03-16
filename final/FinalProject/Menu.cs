public class Menu{
    private InputHandler _inputHandler;
    private Budget _budget;

    public Menu(){
       _budget = new Budget();
       _inputHandler = new InputHandler(_budget);
    }

    public void Start(){
        bool exit = false;

        while (!exit){
            Console.WriteLine("\n--- WELCOME TO THE BUDGET MASTER APP ---");
            Console.WriteLine("\n--- MAIN MENU ---");
            Console.WriteLine("1. Add income");
            Console.WriteLine("2. Add expense");
            Console.WriteLine("3. Show report");
            Console.WriteLine("4. Load File");
            Console.WriteLine("5. Save File");
            Console.WriteLine("6. User Administration");
            Console.WriteLine("7. Exit");
            Console.WriteLine("Select an option: ");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option){
                case 1:
                    _budget.AddTransaction(_inputHandler.CreateIncome());
                    break;
                case 2:
                    _budget.AddTransaction(_inputHandler.CreateExpense());
                    break;
                case 3:
                    Report report = new Report(_budget);
                    report.GenerateReport();
                    break;
                case 4:
                    _budget = _inputHandler.LoadBudgetFromFile("budgetMaster.txt");
                    break;
                case 5:
                    _inputHandler.SaveBudgetToFile("budgetMaster.txt");
                    break;
                case 7:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option selected. Please try again.");
                    break;
            }
        }
        Console.WriteLine("Exiting Budget Master. Goodbye!");
    }
}