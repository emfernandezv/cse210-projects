using System;

public class ChecklistGoal : Goal{
	private int _bonus;
	private int _times;
	private int _completedTimes;
	public override int GetCompletedTimes(){
		return _completedTimes;
	}
	public override void SetCompletedTimes(int n, string load){
		if (load == "load"){
			_completedTimes = n;
		} else{
			_completedTimes += 1;
		}
	}
	public override int GetTimes()	{
		return _times;
	}
	public override void SetTimes(int times){
		_times = times;
	}
	public override int GetBonus(){
		return _bonus;
	}
	public ChecklistGoal(string name, string description, int points, int times, int bonus) : base(name, description, points){
		SetTimes(times);
		_bonus = bonus;
	}
	public ChecklistGoal(string name, string description, int points, int bonus, int times, int completedTimes) : base(name, description, points)	{
		SetTimes(times);
		_bonus = bonus;
		SetCompletedTimes(completedTimes, "load");
	}
	private string x = " ";
    public override string GetGoal(){
        if (GetCompletedTimes() % GetTimes() == 0 && GetCompletedTimes() != 0){
            x = "X";
        } else{
            x = " ";
        }
        return $"[{x}] {GetName()} ({GetDescription()}) -- Currently completed: {GetCompletedTimes()}/{GetTimes()}";
    }
	public override string GetFormattedText(){
    	return $"{this.GetType().Name}:{GetName()},{GetDescription()},{GetPoints()},{GetBonus()},{GetTimes()},{GetCompletedTimes()}";
  	}
}