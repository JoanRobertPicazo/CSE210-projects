// Keeps track of a single word and whether it is shown or hidden.
using System;

public class Word
{
    private string _word;
    private bool _hidden;

    public Word(string word) // Constructor
    {
    _word = word;
    _hidden = false;
    }

    public bool IsHidden()
    {
        return _hidden;
    }

    public void SetIsHidden(bool hidden)
    {
        _hidden = hidden;
    }

    public string GetWord()
    {
        return _word;
    }

    public int GetWordLength()
    {
        return _word.Length;
    }

    public string GetRenderedText()
    {
        return _hidden ? "___" : _word;
    }
}