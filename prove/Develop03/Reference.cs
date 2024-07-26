// Keeps track of the book, chapter, and verse information.
public class Reference
{
    // attributes
    private string _bookName;
    private int _chapter;
    private int _startVerseNum;
    private int _endVerseNum;

    public Reference(string name, int chapter, int verse)
    {
        _bookName = name;
        _chapter = chapter;
        _startVerseNum = verse;
        _endVerseNum = verse;
    }

    public Reference(string name, int chapter, int startVerseNum, int endVerseNum)
    {
        _bookName = name;
        _chapter = chapter;
        _startVerseNum = startVerseNum;
        _endVerseNum = endVerseNum;
    }
    public string GetReference()
    {
        if (_startVerseNum == _endVerseNum)
        {
            return $"{_bookName} {_chapter}:{_startVerseNum}";
        }
        else
        {
            return $"{_bookName} {_chapter}:{_startVerseNum}-{_endVerseNum}";
        }
    }
}