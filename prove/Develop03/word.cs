public class Word{

    private string _word;
    private bool _isHidden;

    //CONSTRUCTOR
    public Word(){
        _isHidden = false;
    }
    
    //GETTERS
    public string GetWord(){
         if (GetIsHidden() == true){
            string result = new String('_',_word.Length);
            return $"{result}";
        }else{
            return _word;
        }
    }
    public bool GetIsHidden(){
        return _isHidden;
    }

    //SETTERS
    public void SetWord( string word){
        _word = word;
    }
    public void SetIsHidden(){
        _isHidden = true;
    }
    public void HideWord(){
        if (GetIsHidden() == false){
            SetIsHidden();
        }
    }
}