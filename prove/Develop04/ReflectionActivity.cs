public class ReflectionActivity : Activity{

    private string _prompt;
    private string _question1;
    private string _question2;
    //CONSTRUCTOR    
    public ReflectionActivity(int activity, string description) : base(activity, description){
        Tools ini = new Tools();
        SetPrompt(ini.Randomizer(1));
        SetQuestions(1,ini.Randomizer(2));
        SetQuestions(2,ini.Randomizer(2));
    }
    //SETTERS
    private void SetPrompt(string prompt){
        _prompt = prompt;
    }
    private void SetQuestions(int number,string question){
        if (number == 1){
            _question1 = question;
        }else{
            _question2 = question;
        }
    }
    //GETTERS
    private string GetPrompt(){
        return _prompt;
    }
    private string GetQuestions(int number){
        if (number == 1){
            return _question1;
        }else{
            return _question2;
        }
    }
     //OTHER BEHAVIORS
    private void DisplayPrompt(){
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine($"--- {GetPrompt()} ---");
        Console.WriteLine("When you have something in mind, press enter to continue");
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        while(keyInfo.Key != ConsoleKey.Enter){
            keyInfo = Console.ReadKey();
        }
        Console.Clear();
    }

    private void DisplayQuestion(){
        Tools ini = new Tools();
        
        for(int x = 1; x <= 2; x++){
            Console.WriteLine($"> {GetQuestions(x)}");
            Console.WriteLine();
            int i = GetDuration()/2;
            ini.Loader(i);
            Console.WriteLine();
        }
    }

    public void Execute(){
        //DISPLAY INITIAL MESSAGE
        DisplayInitialMessage(0);
        //DISPLAYING FIRST PROMPT
        DisplayPrompt();
        //DISPLAYING QUESTIONS
        DisplayQuestion();
        //displayFinalMessage FINAL MESSAGE
        DisplayFinalMessage();
    }


}