using System;

public class SimpleGoal : Goal{
	private bool _completed;
	public override bool GetCompleted(){
		return _completed;
	}
	public override void SetCompleted(bool completed){
		_completed = completed;
	}
	public SimpleGoal(string name, string description, int points) : base(name, description, points){
	}
	public SimpleGoal(string name, string description, int points, bool completed) : base(name, description, points){
		SetCompleted(completed);
	}
	private string x = " ";
    public override string GetGoal(){
        if (GetCompleted()){
            x = "X";
        }
        return $"[{x}] {GetName()} ({GetDescription()})";
    }
    public override string GetFormattedText(){
        return $"{this.GetType().Name}:{GetName()},{GetDescription()},{GetPoints()},{GetCompleted()}";
    }
}