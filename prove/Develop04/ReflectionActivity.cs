public class ReflectionActivity : Activity{

    private string _prompt;
    private string _question1;
    private string _question2;
    //CONSTRUCTOR    
    public ReflectionActivity(string activity, string description, int duration) : base(activity, description, duration){
        ListInitializer ini = new ListInitializer();
        setPrompt(ini.Randomizer(1));
        setQuestions(1,ini.Randomizer(2));
        setQuestions(2,ini.Randomizer(2));
    }
    //SETTERS
    public void setPrompt(string prompt){
        _prompt = prompt;
    }
    public void setQuestions(int number,string question){
        if (number == 1){
            _question1 = question;
        }else{
            _question2 = question;
        }
    }
    //GETTERS
    public string getPrompt(){
        return _prompt;
    }
    public string getQuestions(int number){
        if (number == 1){
            return _question1;
        }else{
            return _question2;
        }
    }
     //OTHER BEHAVIORS
    public void displayPrompt(){
        Console.WriteLine("Get ready...");
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine($"--- {getPrompt()} ---");
        Console.WriteLine("When you have something in mind, press enter to continue");
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        while(keyInfo.Key != ConsoleKey.Enter){
            keyInfo = Console.ReadKey();
        }
        Console.Clear();
    }

    public void displayQuestion(){
        ListInitializer ini = new ListInitializer();
        for(int x = 1; x <= 2; x++){
            Console.WriteLine($"> {getQuestions(x)}");
            Console.WriteLine();
            int i = getDuration()/2;
            while(i >= 0){
                ini.spinner();
                i--;
            }
            Console.WriteLine();
        }
        Console.WriteLine(getMessage());
        Thread.Sleep(5000);
        Console.Clear();
    }
}