public class Assignment{

    private string _studentName;
    private string _topic;

    public Assignment(){
        /*_studentName = "Annonymus";
        _topic = "Unknown";*/
        setName("Annonymus");
        setTopic("Unknown");
    }

    public Assignment(string name, string topic){
        /*_studentName = name;
        _topic = topic;*/
        setName(name);
        setTopic(topic);
    }

    public void setName(string name){
        _studentName = name;
    }

    public void setTopic(string topic){
        _topic = topic;
    }

    public string getName(){
        return _studentName;
    }

    public string getTopic(){
        return _topic;
    }

    public string getSummary(){
        return $"{getName()} - {getTopic()}";
    }
}