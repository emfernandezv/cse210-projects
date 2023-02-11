public class Scripture{

    private string _word;
    private string _reference;
    private List<Word> _listWord = new List<Word>();
    private int _totalwords;
    private int _totalHiddenWords;
    

    public Scripture(){
        // Constructor populates the scripture to use
        getScripture();
    }

    public void execute(){
        hideScriptureWord();
        dispWord();
    }

    private void getScripture( ){
        FileHandler objecthandler = new FileHandler();
        string scripture = objecthandler.ReadFile();
        parseReference(scripture);
        parseWord(scripture);
        dispWord();
    }

    private void parseReference(string scripture){
        string[] array = scripture.Split("|");
        int index;
        
        // PARSE REFERENCE
        Reference refe = new Reference();
        //Diviging the String using "the blank space" to separate Book name vs the rest
        // index1 will store the index place of the rest
        string[] book = array[0].Split(" ");

        if (book.Length > 2){
            // book names with a space like 1 Nephi
            refe.setBookName($"{book[0]} {book[1]}");
            index = 2;
        }else{
            refe.setBookName(book[0]);
            index = 1;
        }

        // Dividing the chapter number vs the rest by the ":"
        string[] chapter = book[index].Split(":");
        refe.setChapter(Int16.Parse(chapter[0]));

        //Dividing verses using the "-"
        string[] verses = chapter[1].Split("-");
        refe.setVerse(1, Int16.Parse(verses[0]));
        if (verses.Length > 1){
            refe.setVerse(1, Int16.Parse(verses[1]));
        }

        _reference = refe.getReference();
    }

    private void parseWord(string scripture){
        string[] array = scripture.Split("|");

        //Dividing each word using the blank space to separate each word
        string[] word = array[1].Split(" ");
        for (int i=0; i < word.Length ;i++){
            //PARSE WORD
            Word wording = new Word();
            wording.setWord(word[i]);
            _listWord.Add(wording);
        }
        _totalwords = _listWord.Count;
    }

    private void dispWord(){
        Console.Clear();
        List<string> listOfWords = new List<string>();
        foreach(Word word in _listWord){
            listOfWords.Add(word.getWord());
        }
        _word = string.Join(" ", listOfWords);
        Console.Clear();
        Console.WriteLine($"{_reference}: '{_word}'");
    }

    private void hideScriptureWord(){

        Random random = new Random();
        int randomIndex = random.Next(0, _totalwords);

        if (_totalHiddenWords < _totalwords){
            if ( _listWord[randomIndex].getIsHidden() == false){
                _listWord[randomIndex].setIsHidden();
                _totalHiddenWords++;
            }else{
                hideScriptureWord();
            }
        }else{
            System.Environment.Exit(1);
        }
    }
}