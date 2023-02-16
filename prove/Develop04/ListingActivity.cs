public class ListingActivity : Activity
{   private string _prompt;
    private List<string> _activities = new List<string>();
    public ListingActivity(string activity, string description, int duration) : base(activity, description, duration)
    {   ListInitializer ini = new ListInitializer();
        setPrompt(ini.Randomizer(3));
    }
    //SETTERS
    public void setPrompt(string prompt){
        _prompt = prompt;
    }
    public void addActivity(string activity){
        _activities.Add(activity);
    }
    //GETTERS
    public string getPrompt(){
        return _prompt;
    }
    public string getActivity(int index){
        return _activities[index];
    }

    public void displayPrompt(){
        Console.WriteLine();
        Console.WriteLine("Get ready...");
        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine($"--- {getPrompt()} ---");
        Console.WriteLine();
        for (var i = 5; i >= 0; i--){
            Console.Write("\r");
            Console.Write("You can start writing in... {0} {1}", i, i == 0 ? "\n" : "");
            Thread.Sleep(1000);
        }

        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(getDuration());
        DateTime currentTime = DateTime.Now;
        while(currentTime < futureTime){
            Console.Write("> ");
            string input = Console.ReadLine();
            addActivity(input);
            currentTime = DateTime.Now;
        }
        Console.WriteLine($"You listed {_activities.Count()} items!");
        Console.WriteLine();
        Console.WriteLine(getMessage());
        Thread.Sleep(5000);
        Console.Clear();

    }
}