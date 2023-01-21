using System;
public class Journal {

    public string _menuOption;
    public List<string> _answers = new List<string>();
    public List<string> _questions = new List<string>();

    public void Menu(){

        Console.WriteLine("MAIN MENU");
        Console.WriteLine("1. Write new entry");
        Console.WriteLine("2. Display previous entries");
        Console.WriteLine("3. Load files");
        Console.WriteLine("4. Save answers");
        Console.WriteLine("5. Quit");
        Console.WriteLine("What would you like to do?: ");

        _menuOption = Console.ReadLine();

        while( _menuOption != "1" && _menuOption != "2" && _menuOption != "3" && _menuOption != "4" && _menuOption != "5"){
            Console.WriteLine("Please choose a valid option.");
            Console.Write("What would you like to do?: ");
            _menuOption = Console.ReadLine();
        }

        switch (_menuOption){
            case "1":
                WriteEntry();
                Menu();
                break;
            case "2":
                DisplayEntries();
                Menu();
                break;
            case "3":
                LoadFiles();
                Menu();
                break;
            case "4":
                SaveFiles();
                Menu();    
                break;                
            default:
                Exit();
                break;
        }
    }

    public void WriteEntry(){
       
        // Loading the questions
        FileHandler objectHandler = new FileHandler ();
        objectHandler.ReadQuestionaryFile();
        _questions = objectHandler._list;
        // Generating random prompt
        Writer questionObject = new Writer();
        questionObject.PromptGenerator(_questions);
        string _question = questionObject._question;

        // getting response
        string _answer = Console.ReadLine();

        //Getting current date            
        DateTime _theCurrentTime = DateTime.Now;
        string _dateText = _theCurrentTime.ToShortDateString();

        // Getting response
        _answers.Add($"{_dateText};{_question};{_answer}");

        // Confirmation message
        Console.WriteLine("The entry was recorded successfully!!");
        Console.WriteLine();
    }

    public void DisplayEntries(){
        // initializing the object to handle the Responses TXT file
        Writer answerFileObject = new Writer();

        // reading the array
        answerFileObject.WriteEntries(_answers);
    }

    public void LoadFiles() {
        // Loading the questions
        FileHandler objectHandler = new FileHandler ();
        objectHandler.ReadFile("What's the file's name to load?");

        //setting the read list to the local list
        _answers = objectHandler._list;

        // Confirmation message
        Console.WriteLine("You information has been loaded");
        Console.WriteLine();

     }

    public void SaveFiles(){
        //Setting list to save
        FileHandler objectHandler = new FileHandler ();
        objectHandler._list = _answers;

        //Saving answers
        objectHandler.SaveFile("What's the file's name to save?");
    }

    public void Exit(){
        Console.WriteLine();
        Console.WriteLine("See you Next Time!");
        System.Environment.Exit(1);
    }
}
