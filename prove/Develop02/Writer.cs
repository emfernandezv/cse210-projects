using System;
using System.IO; 
public class Writer {
               
    // WRITES IN CONSOLE A RANDOM QUESTION
    public string PromptGenerator ( ) {
        // variables declaration
        List<string> questionsList  = new List<string>();
        string question;
        // Loading the questions
        FileHandler objectHandler = new FileHandler ();
        questionsList = objectHandler.ReadQuestionaryFile();
        // Getting a random value from 0 to the size of the array +1 
        Random rnd = new Random();
        int index  = rnd.Next(0, questionsList.Count());
        //displaying the random question assigned to that index in the array
        question = questionsList[index];
        Console.WriteLine();
        Console.WriteLine(question);
        return question;
    }    

    // WRITES IN CONSOLE THE DETAILED ENTRIES
    public void WriteEntries (List<Entry> _entries) { 
        
        foreach (Entry answer in _entries){
            string[] array;
            array = answer._finalAnswer.Split(';');
            Console.WriteLine();
            //Writting each secion of the structure
            Console.WriteLine($"Date: {array[0]}");
            Console.WriteLine($"Prompt: {array[1]}");
            Console.WriteLine($"Answer: {array[2]}");
            Console.WriteLine(""); //jump line
           }
    }



}