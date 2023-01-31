using System;
public class Journal {

    public List<Entry> _entries = new List<Entry>();
    
    public void WriteEntry(){
        
        // Generating random prompt
        Writer questionObject = new Writer();
        string question = questionObject.PromptGenerator();
        // getting response
        string answer = Console.ReadLine();
        //Getting current date            
        DateTime theCurrentTime = DateTime.Now;
        string dateText = theCurrentTime.ToShortDateString();
        // writting the entry on the List<Entry>, already formatted
        Entry newEntry = new Entry();
        newEntry._finalAnswer = $"{dateText};{question};{answer}";
        _entries.Add(newEntry);

        // Confirmation message
        Console.WriteLine("The entry was recorded successfully!!");
        Console.WriteLine();
    }

    public void DisplayEntries(){
        // initializing the object to handle the Responses TXT file
        Writer answerFileObject = new Writer();
        // reading the array
        answerFileObject.WriteEntries(_entries);
    }

    public void LoadFiles() {
        // Loading the questions
        FileHandler objectHandler = new FileHandler ();
        //setting the read list to the local list
        _entries = objectHandler.ReadFile("What's the file's name to load?");
        // Confirmation message
        Console.WriteLine("You information has been loaded");
        Console.WriteLine();
     }

    public void SaveFiles(){
        //Setting list to save
        FileHandler objectHandler = new FileHandler ();
        //Saving answers
        objectHandler.SaveFile("What's the file's name to save?",_entries);
        // Confirmation message
        Console.WriteLine("You information has been loaded");
        Console.WriteLine();
    }

    public void Exit(){
        Console.WriteLine();
        Console.WriteLine("See you Next Time!");
        System.Environment.Exit(1);
    }
}
