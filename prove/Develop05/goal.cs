using System;

public class Goal{
	private string _name;
	private string _description;
	private int _points;
	// Getters
	public string GetName(){
		return _name;
	}
	protected string GetDescription(){
		return _description;
	}
	public int GetPoints(){
		return _points;
	}
    //setters
	private void SetName(string name){
		_name = name;
	}
	private void SetDescription(string description){
		_description = description;
	}
	private void SetPoints(int points){
		_points = points;
	}
    //other behaviors
	public Goal(string name, string description, int points){
		SetName(name);
		SetDescription(description);
		SetPoints(points);
	}
	public virtual string GetGoal(){
		return $"[ ] {_name} ({_description})";
	}
	public virtual int GetCompletedTimes(){
		return 0;
	}
	public virtual void SetCompletedTimes(int n, string load){}
	public virtual int GetTimes(){
		return 0;
	}
	public virtual void SetTimes(int times) {}
	public virtual bool GetCompleted(){
		return false;
	}
	public virtual void SetCompleted(bool completed){}
	public virtual int GetBonus(){
		return 0;
	}
	public virtual string GetFormattedText(){
		return "";
	}
}