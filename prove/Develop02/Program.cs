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
        journalUse.Menu();
        _menuOption = journalUse._menuOption;
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
            journalUse.Menu();
            _menuOption = journalUse._menuOption;
        }
        // using goto to handle when the input is not a valid option
        Console.WriteLine("The option you entered is invalid.");
        goto displaymenu;

    }
}