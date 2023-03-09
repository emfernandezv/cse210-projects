using System;

public class EternalGoal : Goal{
	public EternalGoal(string name, string description, int points) : base(name, description, points){}
	public override string GetFormattedText(){
        return $"{this.GetType().Name}:{GetName()},{GetDescription()},{GetPoints()}";
    }
}