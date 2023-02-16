public class BreathingActivity : Activity {

    private int _breathingIn;
    private int _breathingOut;

    //CONSTRUCTOR
    public BreathingActivity(string activity, string description, int duration) : base(activity, description, duration)
    {   
        setBreathIn(5);
        setBreathOut(5);
    }
    //SETTERS
    public void setBreathIn(int time){
        _breathingIn = time;
    }
    public void setBreathOut(int time){
        _breathingOut = time;
    }
    //GETTERS
    public int getBreathIn(){
        return _breathingIn;
    }
    public int getBreathOut(){
        return _breathingOut;
    }
    //OTHER BEHAVIORS
    public void displayInMessage(){
        for (var i = getBreathIn(); i >= 0; i--){
            Console.Write("\r");
            Console.Write("Breath in... {0} {1}", i, i == 0 ? "\n" : "");
            Thread.Sleep(1000);
        }
    }
    public void displayOutMessage(){
        for (var i = getBreathOut(); i >= 0; i--){
            Console.Write("\r");
            Console.Write("Breath out... {0} {1}", i, i == 0 ? "\n" : "");
            Thread.Sleep(1000);
        }
    }

    public void displayMessage(){
        Console.WriteLine("Get ready...");
        Console.WriteLine();
        Thread.Sleep(2000);

        //TO CALCULATE HOW MANY TIMES IT HAS TO REPEAT THE ACTION
        int times = getDuration() / (getBreathIn() + getBreathOut());

        for(int i = 1; i <= times ; i++){
            displayInMessage();
            displayOutMessage();
            Console.WriteLine();   
        }
        Console.WriteLine(getMessage());
        Thread.Sleep(5000);
        Console.Clear();
    }
}