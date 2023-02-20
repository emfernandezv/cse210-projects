public class Activity{

    private int _activity;
    private string _description;
    private int _duration;
    private string _endMessage;
    //CONSTRUCTOR
    public Activity(int activity, string description){
        SetActivity(activity);
        SetDescription(description);
    }
    //SETTERS
    private void SetActivity(int activity){
        _activity = activity;
    }
    private void SetDescription(string description){
        _description = description;
    }
    private void SetDuration(int duration){
        SetMessage($"Well done! {Environment.NewLine}{Environment.NewLine}You have completed another {duration} seconds of the {GetDescription()}.");
        _duration = duration;
    }
    private void SetMessage(string message){
        _endMessage = message;
    }
    //GETTERS
    private int GetActivity(){
        return _activity;
    }
    private string GetDescription(){
        return _description;
    }
    public int GetDuration(){
        return _duration;
    }
    private string GetMessage(){
        return _endMessage;
    }
    //TO CONTROL THE INITIAL MESSAGE THAT ALL ACTIVITIES HAS
    public void DisplayInitialMessage(int min){
        Console.Clear();
        int number = GetActivity()-1;
        Tools ini = new Tools();
        Console.WriteLine(ini.description(number));
        Console.WriteLine();
        
        if (number != 0){
            min = 0;
        }   
        int duration = 0;    
        Console.WriteLine($"How long, in seconds, would you like for your session? Minimun {min} seconds.");
        //TO VALIDATE A NUMERIC INPUT
        try{
            duration = Int32.Parse(Console.ReadLine());
        }catch (System.FormatException){
            duration = 0;
        }               
        while (duration < min){
            Console.WriteLine($"Please chose a values > {min}.");
            try{
                duration = Int32.Parse(Console.ReadLine());
            }catch (System.FormatException){
                duration = 0;
            } 
        }
        SetDuration(duration);
        Console.WriteLine();
        Console.WriteLine("Get ready...");
        Console.WriteLine();
        ini.Loader(2);
    }
    //TO CONTROL THE FINAL MESSAGE THAT ALL ACTIVITIES HAS
    public void DisplayFinalMessage(){
        Console.WriteLine();
        Console.WriteLine(GetMessage());
        Tools ini = new Tools();
        ini.Loader(5);
        Console.Clear();
    }

}