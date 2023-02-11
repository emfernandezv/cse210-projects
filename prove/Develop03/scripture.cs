public class Scripture{

    private string _word;
    private string _reference;
    private List<Word> _listWord = new List<Word>();
    private int _totalWords;
    private int _totalHiddenWords;
    private bool _isAllHidden;
    
    public Scripture(){
        // Constructor populates the scripture to use
        GetScripture();
        _isAllHidden = false;
    }
    public void Execute(){
        WordHiding();
        ScriptureDisplay();
    }
    private void GetScripture( ){
        FileHandler objecthandler = new FileHandler();
        string scripture = objecthandler.ReadFile();
        ParseReference(scripture);
        ParseWord(scripture);
        ScriptureDisplay();
    }
    private void ParseReference(string scripture){
        string[] array = scripture.Split("|");
        int index;
        
        // PARSE REFERENCE
        Reference refe = new Reference();
        //Diviging the String using "the blank space" to separate Book name vs the rest
        // index1 will store the index place of the rest
        string[] book = array[0].Split(" ");

        if (book.Length > 2){
            // book names with a space like 1 Nephi
            refe.SetBookName($"{book[0]} {book[1]}");
            index = 2;
        }else{
            refe.SetBookName(book[0]);
            index = 1;
        }
        // Dividing the chapter number vs the rest by the ":"
        string[] chapter = book[index].Split(":");
        refe.SetChapter(Int16.Parse(chapter[0]));
        //Dividing verses using the "-"
        string[] verses = chapter[1].Split("-");
        refe.SetVerse(1, Int16.Parse(verses[0]));
        if (verses.Length > 1){
            refe.SetVerse(1, Int16.Parse(verses[1]));
        }
        _reference = refe.GetReference();
    }
    private void ParseWord(string scripture){
        string[] array = scripture.Split("|");
        //Dividing each word using the blank space to separate each word
        string[] word = array[1].Split(" ");
        for (int i=0; i < word.Length ;i++){
            //PARSE WORD
            Word wording = new Word();
            wording.SetWord(word[i]);
            _listWord.Add(wording);
        }
        _totalWords = _listWord.Count;
    }
    private void ScriptureDisplay(){
        Console.Clear();
        List<string> listOfWords = new List<string>();
        foreach(Word word in _listWord){
            listOfWords.Add(word.GetWord());
        }
        _word = string.Join(" ", listOfWords);
        Console.Clear();
        Console.WriteLine($"{_reference}: {_word}");
    }
    private void WordHiding(){
        FileHandler objecthandler = new FileHandler();
        int randomIndex = objecthandler.Randomizer(_totalWords);
        if (_totalHiddenWords < _totalWords){
            if ( _listWord[randomIndex].GetIsHidden() == false){
                _listWord[randomIndex].SetIsHidden();
                _totalHiddenWords++;
            }else{
                WordHiding();
            }
        }else{
            _isAllHidden = true;
        }
    }

    public bool getIsAllHidden(){
        return _isAllHidden;
    }

}