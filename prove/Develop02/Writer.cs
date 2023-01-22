using System;
using System.IO; 
public class Writer {

    public string _question;
    public List<string> _answers  = new List<string>();
    public List<string> _questionsList  = new List<string>();
    
    // WRITES IN CONSOLE A RANDOM QUESTION
    public void PromptGenerator ( ) {
        
        // Loading the questions
        FileHandler objectHandler = new FileHandler ();
        objectHandler.ReadQuestionaryFile();
        _questionsList = objectHandler._list;
        // Getting a random value from 0 to the size of the array +1 
        Random rnd = new Random();
        int index  = rnd.Next(0, _questionsList.Count());

        //displaying the random question assigned to that index in the array
        _question = _questionsList[index];
        Console.WriteLine();
        Console.WriteLine(_question);
    }    

    // WRITES IN CONSOLE THE DETAILED ENTRIES
    public void WriteEntries (List<string> _answers) { 
        
        foreach (string line in _answers){
            // separating the lines by groups 
            string[] _answersStructure;
            _answersStructure = line.Split(";");

            Console.WriteLine();
            //Writting each secion of the structure
            Console.WriteLine($"Date: {_answersStructure[0] }");
            Console.WriteLine($"Prompt: {_answersStructure[1] }");
            Console.WriteLine($"Answer: {_answersStructure[2]}");
            Console.WriteLine(""); //jump line

           }
    }



}