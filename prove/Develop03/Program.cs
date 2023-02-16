using System;

class Program
{
    static void Main(string[] args)
    {   //DECLARE VARIABLES
        string _menuOption;
       // create the object Scripture
        Scripture script = new Scripture(); 
        // displaying the menu from the object
        _menuOption = Menu();
        //Validate option is correct
        while ( _menuOption != "quit" && script.getIsAllHidden() != true){
            script.Execute();
            _menuOption = Menu();
        }
        //if the option was quit then exits
        ProgramTermination();
        //repeating menu
        static string Menu(){
            string menuOption;
            Console.WriteLine("Press enter to continue or type 'quit' to finish:");
            menuOption = Console.ReadLine();
            return menuOption;
        }

        static void ProgramTermination(){
            System.Environment.Exit(1);
        }
    }
}