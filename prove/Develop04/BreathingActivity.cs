public class BreathingActivity : Activity {

    private int _breathingIn;
    private int _breathingOut;

    //CONSTRUCTOR
    public BreathingActivity(int activity, string description) : base(activity, description)
    {   
        SetBreathIn(5);
        SetBreathOut(5);
    }
    //SETTERS
    private void SetBreathIn(int time){
        _breathingIn = time;
    }
    private void SetBreathOut(int time){
        _breathingOut = time;
    }
    //GETTERS
    private int GetBreathIn(){
        return _breathingIn;
    }
    private int GetBreathOut(){
        return _breathingOut;
    }
    //OTHER BEHAVIORS
    private void DisplayMessage(string msg){
        Console.CursorVisible = false;
        int time;
        if (msg == "in"){
            time = GetBreathIn();
        }else {
            time = GetBreathOut();
        }
        for (var i = time; i >= 0; i--){
            Console.Write("\r");
            Console.Write($"Breath {msg}... "+"{0} {1}", i, i == 0 ? "\n" : "");
            Thread.Sleep(1000);
        }
        Console.CursorVisible = true;
    }

    public void Execute(){
        // EXCEED EXPECTATION:
        LevelInput();
        //displaying initial message
        DisplayInitialMessage(GetBreathIn() + GetBreathOut());
        //TO CALCULATE HOW MANY TIMES IT HAS TO REPEAT THE ACTION
        int times = GetDuration() / (GetBreathIn() + GetBreathOut());
        //execution of the prompt
        for(int i = 1; i <= times ; i++){
            DisplayMessage("in");
            DisplayMessage("out");
            Console.WriteLine();   
        }
        //display final message
        DisplayFinalMessage();
    }

    public void LevelInput(){
        Console.Clear();
        int level;
        Console.WriteLine("What level would you like to do?");
        Console.WriteLine("1. Beginner (5/5)");
        Console.WriteLine("2. Intermediate (3/8)");
        Console.WriteLine("3. Advanced (4/10)");
        try{
            level = Int32.Parse(Console.ReadLine());
        }catch (System.FormatException){
            level = 0;
        } 
        while (level < 0  && level > 3){
            Console.WriteLine("Please input a valid option.");
            try{
                level = Int32.Parse(Console.ReadLine());
            }catch (System.FormatException){
                level = 0;
            } 
        }
        switch(level){
            case 1:
                SetBreathIn(5);
                SetBreathOut(5);
                break;
            case 2:
                SetBreathIn(3);
                SetBreathOut(8);
                break;
            case 3:
                SetBreathIn(4);
                SetBreathOut(10);
                break;
        }
        Console.Clear();
    }
}