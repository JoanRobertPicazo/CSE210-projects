using System;
using System.Collections.Generic;

public class Scripture
{
    // attributes, private
    private List<Word> _words;
    private Reference _reference;

    // single verse
    public Scripture(string name, int chapter, int verse, string text)
    {
        _reference = new Reference(name, chapter, verse);
        SetupWords(text);
    }

    // verse range
    public Scripture(string name, int chapter, int startVerse, int endVerse, string text)
    {
        _reference = new Reference(name, chapter, startVerse, endVerse);
        SetupWords(text);
    }

    // split verse
    private void SetupWords(string text)
    {
        _words = new List<Word>();
        string[] wordsArray = text.Split(' ');
        foreach (string word in wordsArray)
        {
            _words.Add(new Word(word));
        }
    }

    // hide some words
    public bool HideSomeWords()
    {
        Random random = new Random();
        int wordsToHide = random.Next(1, 4); // hide 1 to 3 words

        List<Word> visibleWords = _words.FindAll(word => !word.IsHidden());
        if (visibleWords.Count == 0)
        {
            return true; // no more words to hide
        }

        for (int i = 0; i < wordsToHide; i++)
        {
            if (visibleWords.Count == 0)
            {
                break;
            }

            int index = random.Next(visibleWords.Count);
            visibleWords[index].SetIsHidden(true);
            visibleWords.RemoveAt(index);
        }

        return NumberOfHiddenWords() == _words.Count;
    }

    // number of hidden words
    private int NumberOfHiddenWords()
    {
        int count = 0;
        foreach (Word word in _words)
        {
            if (word.IsHidden())
            {
                count++;
            }
        }
        return count;
    }

    // show scripture
    public void ShowScripture()
    {
        Console.Clear();
        Console.WriteLine($"{_reference.GetReference()}");
        foreach (Word word in _words)
        {
            Console.Write(word.GetRenderedText() + " ");
        }
        Console.WriteLine();
    }

    // scripture reference as a string
    public string GetScriptureReference()
    {
        return _reference.GetReference();
    }
}
