using System;

class Program
{
    static void Main(string[] args)
    {   //DECLARE VARIABLES
        string _menuOption;

        // create the object JournalUse
        Journal journalUse = new Journal();

        // displaying the menu from the object
        displaymenu:
        _menuOption = Menu();
        //Validate option is correct
        while ( _menuOption == "1" || _menuOption == "2" || _menuOption == "3" || _menuOption == "4"|| _menuOption == "5"){
            //MENU HANDLER
            switch (_menuOption){
                case "1":
                    journalUse.WriteEntry();
                    break;
                case "2":
                    journalUse.DisplayEntries();
                    break;
                case "3":
                    journalUse.LoadFiles();
                    break;
                case "4":
                    journalUse.SaveFiles();
                    break;                
                default:
                    journalUse.Exit();
                    break;
            }
            _menuOption = Menu();
        }
        // using goto to handle when the input is not a valid option
        Console.WriteLine("The option you entered is invalid.");
        goto displaymenu;

        static string Menu(){
            string menuOption;
            Console.WriteLine("MAIN MENU");
            Console.WriteLine("1. Write new entry");
            Console.WriteLine("2. Display previous entries");
            Console.WriteLine("3. Load files");
            Console.WriteLine("4. Save answers");
            Console.WriteLine("5. Quit");
            Console.WriteLine("What would you like to do?: ");
            menuOption = Console.ReadLine();
            return menuOption;
        }

    }
}