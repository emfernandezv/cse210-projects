using System;
using System.IO; 

public class FileHandler {

     string _fileName;
    public List<string> _list = new List<string> ();

    public void ReadQuestionaryFile(){
        
        _fileName = "Questionary.txt";
        string[] lines = System.IO.File.ReadAllLines(_fileName);

        foreach (string line in lines){
            string[] _array = line.Split("|");
            _list =  _array.ToList();
        }
    }

    public void ReadFile(string _question){
        Console.WriteLine();
        Console.WriteLine(_question);
        //_fileName = "Responses.txt";
        _fileName = Console.ReadLine();

        string[] lines = System.IO.File.ReadAllLines(_fileName);
        for (int i = 0; i < lines.Length ;i++){
            string value = lines[i];
            value = value.Substring(0,value.Length - 1);
            _list.Add(value);
        }
    }

    public void SaveFile(string _question){
        Console.WriteLine();
        Console.WriteLine(_question);
        //string _fileName = "Responses.txt";
        _fileName = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(_fileName)){
           //Getting Values
           foreach (string line in _list){
            // separating the lines by groups 
            string[] _answersStructure;
            _answersStructure = line.Split(";");

            string _output = $"{_answersStructure[0]};{_answersStructure[1] };{_answersStructure[2]}|";
            //Writting each secion of the structure
            outputFile.WriteLine(_output);

           }
        }
    }
}