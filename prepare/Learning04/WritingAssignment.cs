public class WritingAssignment : Assignment{

    private string _title;

    public WritingAssignment(){
        setTitle("Unknown title");
    }

    public WritingAssignment(string name, string topic, string title) : base( name, topic){
        setTitle(title);
    }

    public void setTitle(string title){
        _title = title;
    }

    public string getTitle(){
        return _title;
    }

    public string getWritingInformation(){
        return $"{getTitle()} by {getName()}";
    }
}