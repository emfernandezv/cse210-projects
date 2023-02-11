using System;
using System.IO; 

public class FileHandler {

    public string ReadFile(){
        List<string> list = new List<string> ();
        String scripture;
        string fileName = "scriptures.txt";
        string[] lines = System.IO.File.ReadAllLines(fileName);
        string[] array = lines[0].Split("/");
        list =  array.ToList();
        scripture = list[Randomizer(list.Count())];
        return scripture;
    }
    public int Randomizer(int max){
        // Getting a random value from 0 to the size of the array +1 
        Random rnd = new Random();
        int index  = rnd.Next(0, max);
        return index;
    }
   
}