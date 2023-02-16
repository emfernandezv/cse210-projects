public class MathAssignment : Assignment{

    private string _textbookSection;
    private string _problems;

    public MathAssignment(){
        setSection("Unknown");
        setProblems("problems!");
    }

    public MathAssignment(string name, string topic, string section, string problems) : base( name, topic){
        setSection(section);
        setProblems(problems);
    }

    public void setSection(string section){
        _textbookSection = section;
    }

    public void setProblems(string problems){
        _problems = problems;
    }

    public string getSection(){
        return _textbookSection;
    }

    public string getProblems(){
        return _problems;
    }

    public string getHomeWorkList(){
        return $"Section: {getSection()} - Problems: {getProblems()}";
    }
}