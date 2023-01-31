using System;
using System.IO; 

public class FileHandler {

    private string _fileName;

    public List<string> ReadQuestionaryFile(){
        List<string> list = new List<string> ();
        _fileName = "Questionary.txt";
        string[] lines = System.IO.File.ReadAllLines(_fileName);
        foreach (string line in lines){
            string[] array = line.Split("|");
            list =  array.ToList();
        }
        return list;
    }

    public List<Entry> ReadFile(string question){
        List<Entry> entryList = new List<Entry> ();
        Console.WriteLine();
        Console.WriteLine(question);
        //_fileName = "Responses.txt";
        _fileName = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(_fileName);
        for (int i = 0; i < lines.Length ;i++){
            string value = lines[i];
            Entry newEntry = new Entry();
            newEntry._finalAnswer = value;
            entryList.Add(newEntry);
        }
        return entryList;
    }

    public void SaveFile(string question,List<Entry> entryList){
        Console.WriteLine();
        Console.WriteLine(question);
        //string _fileName = "Responses.txt";
        _fileName = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(_fileName)){
           //Getting Values
           foreach (Entry line in entryList){
            string[] array = line._finalAnswer.Split(";");
            //Writting each secion of the structure
            outputFile.WriteLine($"{array[0]};{array[1] };{array[2]}");
           }
        }
    }
}