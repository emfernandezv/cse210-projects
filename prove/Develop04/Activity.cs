public class Activity{

    private string _activity;
    private string _description;
    private int _duration;
    private string _endMessage;

    //CONSTRUCTOR
    public Activity(string activity, string description, int duration){
        setActivity(activity);
        setDescription(description);
        setDuration(duration);
        setMessage($"Well done! {Environment.NewLine}{Environment.NewLine}You have completed another {duration} seconds of the {description}.");
    }

    //SETTERS
    public void setActivity(string activity){
        _activity = activity;
    }
    public void setDescription(string description){
        _description = description;
    }
    public void setDuration(int duration){
        _duration = duration;
    }
    public void setMessage(string message){
        _endMessage = message;
    }

    //GETTERS
    public string getActivity(){
        return _activity;
    }
    public string getDescription(){
        return _description;
    }
    public int getDuration(){
        return _duration;
    }
    public string getMessage(){
        return _endMessage;
    }
}