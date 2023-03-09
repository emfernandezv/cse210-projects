using System;
using System.IO;

public class EternalQuest
{
    private int _menuOption;
	private int _totalPoints = 0;
	private List<Goal> _list = new List<Goal>();
	public void Execute(){
		while (_menuOption != 6){
			Console.WriteLine();
			Console.WriteLine($"You have {_totalPoints} points.");
			Console.WriteLine();
			Console.WriteLine("Menu Options:");
			Console.WriteLine("1. Create New Goal");
			Console.WriteLine("2. List Goals");
			Console.WriteLine("3. Save Goals");
			Console.WriteLine("4. Load Goals");
			Console.WriteLine("5. Record Event");
			Console.WriteLine("6. Quit");
			Console.Write("Select a choice from the menu: ");
			_menuOption = Int32.Parse(Console.ReadLine());
            while(_menuOption > 6 || _menuOption <=0){
                Console.Write("Please enter a valid option.");
                _menuOption = Int32.Parse(Console.ReadLine());
            }
            switch (_menuOption){
                case 1:
                    SelectGoal();
                    break;
                case 2:
                    ListGoals();
                    break;
                case 3:
                    SaveGoals();
                    break;
                case 4:
                    LoadGoals();
                    break;
                case 5:
                    RecordEvent();
                    break;
                default:
                    continue;
            }
        }		
	}
	private void SelectGoal(){
	    int goalChoice;
		Console.WriteLine("The types of goals are:");
		Console.WriteLine("  1. Simple Goal");
		Console.WriteLine("  2. Eternal Goal");
		Console.WriteLine("  3. Checklist Goal");
		Console.Write("Which type of goal would you like to create? ");
		goalChoice = Int32.Parse(Console.ReadLine());
        while(goalChoice > 3 || goalChoice <=0){
            Console.Write("Please enter a valid choice: ");
            goalChoice = Int32.Parse(Console.ReadLine());
        }
        GoalCreator(goalChoice);
	}
    private void GoalCreator(int type){
        string name;
		string description;
		int points;
        Console.Write("What is the name of your Goal? ");
		name = Console.ReadLine();
        while (name.Length <= 0){
            Console.Write("Please enter a valid name: ");
            name = Console.ReadLine();
        }
		Console.Write("What is a short description of it? ");
		description = Console.ReadLine();
        while (description.Length <= 0){
            Console.Write("Please enter a valid description: ");
            description = Console.ReadLine();
        }
		Console.Write("What is the amount of points associated with this goal? ");
		points = Int32.Parse(Console.ReadLine());
        while (points <= 0){
            Console.Write("Please enter a valid amount of points: ");
            points = Int32.Parse(Console.ReadLine());
        }
        switch(type){
            case 1:
                SimpleGoal simple = new SimpleGoal(name, description, points);
		        _list.Add(simple);
	            Execute();
                break;
            case 2:
                EternalGoal eternal = new EternalGoal(name, description, points);
                _list.Add(eternal);
                Execute();
                break;
            case 3:
                int times;
		        int bonus;
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                times = Int32.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                bonus = Int32.Parse(Console.ReadLine());
                ChecklistGoal check = new ChecklistGoal(name, description, points, times, bonus);
                _list.Add(check);
                break;
        }
    }
	private void ListGoals(){
        int counter = 1;
        int i = 0;
        Console.WriteLine();
		foreach(Goal goal in _list){
			Console.WriteLine($"{counter}. {goal.GetGoal()}");
			counter += 1;
            i+= 1;
            WriteProgress( i, _list.Count());
            if (i != _list.Count()){
                ClearCurrentConsoleLine();
            }
		}
	}
	private void RecordEvent(){
		Console.WriteLine();
		Console.WriteLine("The goals are: ");
		int counter = 1;
		foreach(Goal goal in _list){
			Console.WriteLine($"  {counter}. {goal.GetName()}");
			counter += 1;
		}
		Console.Write("Which goal did you accomplish? ");
		int index = Int32.Parse(Console.ReadLine()) - 1;
        while (index+1 <= 0){
            Console.Write("Please select a valid goal: ");
            index = Int32.Parse(Console.ReadLine());
        }
        int point = 0;
        switch(_list[index].GetType().Name){
            case "SimpleGoal":
                _list[index].SetCompleted(true);
			    _totalPoints += _list[index].GetPoints();
                point = _list[index].GetPoints();
                break;
            case "EternalGoal":
                _totalPoints += _list[index].GetPoints();
                point = _list[index].GetPoints();
                break;
            case "ChecklistGoal":
                _list[index].SetCompletedTimes(0, "noload");
                if (_list[index].GetCompletedTimes() <= _list[index].GetTimes()){
                    Console.WriteLine($"Congrats! You completed {_list[index].GetCompletedTimes()}/{_list[index].GetTimes()}!");
                    _totalPoints += _list[index].GetPoints();
                    point = _list[index].GetPoints();
                    if (_list[index].GetCompletedTimes() / _list[index].GetTimes() == 1){
                        _totalPoints += _list[index].GetBonus();
                        Console.WriteLine($"Congrats! You completed the task! You got extra  {_list[index].GetBonus()} Bonus Points!!");
                    }
                }else{
                    Console.WriteLine($"Sorry! This task is already completed. Choose a new one.");
                    RecordEvent();
                }
                break;
        }
        Console.WriteLine($"Congrats! You got {point} Points!!");
	}
	private void SaveGoals(){
		Console.WriteLine();
		Console.Write("What is the filename for the Goal file? (Please add .txt extension): ");
		string filename = Console.ReadLine();
        while (filename.Length <= 0){
            Console.Write("Please enter a valid file name: ");
            filename = Console.ReadLine();
        }
		using (StreamWriter outputFile = new StreamWriter(filename)){
			outputFile.WriteLine($"{_totalPoints}");
            int i = 0;
			foreach (Goal goal in _list){
				outputFile.WriteLine(goal.GetFormattedText());
                i+= 1;
                WriteProgress( i, _list.Count());
			}
		}
	}
	private void LoadGoals(){
		Console.WriteLine();
		Console.Write("What is the filename for the Goal file you want to load? (Please add .txt extension): ");
		string filename = Console.ReadLine();
        while (filename.Length <= 0){
            Console.Write("Please enter a valid file name: ");
            filename = Console.ReadLine();
        }
		string[] lines = System.IO.File.ReadAllLines(filename);
		_totalPoints = Int32.Parse(lines[0]);
        int i = 0;
		foreach (string line in lines.Skip(1)){
			string[] parts = line.Split(":");
			string[] content = parts[1].Split(",");
			if (parts[0] == "SimpleGoal"){
				SimpleGoal simple = new SimpleGoal(content[0], content[1], Int32.Parse(content[2]), bool.Parse(content[3]));
				_list.Add(simple);               
			} else if (parts[0] == "EternalGoal"){
				EternalGoal eternal = new EternalGoal(content[0], content[1], Int32.Parse(content[2]));
				_list.Add(eternal);
			} else if (parts[0] == "ChecklistGoal"){
				ChecklistGoal check = new ChecklistGoal(content[0], content[1], Int32.Parse(content[2]), Int32.Parse(content[3]), Int32.Parse(content[4]), Int32.Parse(content[5]));
				_list.Add(check);
			}
            i+= 1;
            WriteProgress( i, lines.Count()-1);
		}
	}

    private void WriteProgress(int progress, int total){
        //draw empty progress bar
            Console.CursorLeft = 0;
            Console.Write("[");
            Console.CursorLeft = 31;
            Console.Write("]");
            Console.CursorLeft = 1;
            float oneunit = 30.0f / total;

            //draw progress
            int position = 1;
            for (int i = 0; i < oneunit * progress; i++){
                Console.BackgroundColor = ConsoleColor.Green;
                Console.CursorLeft = position++;
                Console.Write(" ");
            }

            //draw strip bar
            for (int i = position; i <= 30; i++){
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.CursorLeft = position++;
                Console.Write(" ");
            }

            //draw totals
            Console.CursorLeft = 35;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(progress.ToString() + " of " + total.ToString() + "    ");
            Thread.Sleep(250);
    }

    public void ClearCurrentConsoleLine(){
        int currentLineCursor = Console.CursorTop;
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(new string(' ', Console.WindowWidth)); 
        Console.SetCursorPosition(0, currentLineCursor);
    }

}