public class Reference{

    private string _bookName;
    private int _chapter;
    private int _verse1;
    private int _verse2;

    //GETTERS
    private string GetBookName(){
        return _bookName;
    }
    private string GetChapter(){
        return _chapter.ToString();
    }
    private string GetVerse(){
        string value;
        if (_verse2 > 0){
            value = $"{_verse1}-{_verse2}";
        }else {
            value = $"{_verse1}";
        }
        return value; 
    }
    public string GetReference(){
        return $"{GetBookName()} {GetChapter()}:{GetVerse()}";
    }

    //SETTERS
    public void SetBookName(string bookName){
        _bookName = bookName;
    }
    public void SetChapter( int chapter){
        _chapter = chapter;
    }
    public void SetVerse( int number, int verse){
        
        if (number==1){
            _verse1 = verse;
        }else {
            _verse2 = verse;
        } 

    }
}