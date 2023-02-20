public class ListingActivity : Activity
{   private string _prompt;
    private List<string> _activities = new List<string>();
    public ListingActivity(int activity, string description) : base(activity, description)
    {   Tools ini = new Tools();
        SetPrompt(ini.Randomizer(3));
    }
    //SETTERS
    private void SetPrompt(string prompt){
        _prompt = prompt;
    }
    private void AddActivity(string activity){
        _activities.Add(activity);
    }
    //GETTERS
    private string GetPrompt(){
        return _prompt;
    }
    private string GetActivity(int index){
        return _activities[index];
    }

    public void Execute(){
        //DISPLAY INITIAL MESSAGE
        DisplayInitialMessage(0);
        //EXECUTING
        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine($"--- {GetPrompt()} ---");
        Console.WriteLine();
        for (var i = 5; i >= 0; i--){
            Console.Write("\r");
            Console.Write("You can start writing in... {0} {1}", i, i == 0 ? "\n" : "");
            Thread.Sleep(1000);
        }

        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(GetDuration());
        DateTime currentTime = DateTime.Now;
        while(currentTime < futureTime){
            Console.Write("> ");
            string input = Console.ReadLine();
            AddActivity(input);
            currentTime = DateTime.Now;
        }
        Console.WriteLine($"You listed {_activities.Count()} items!");
        //display final message
        DisplayFinalMessage();
    }
}