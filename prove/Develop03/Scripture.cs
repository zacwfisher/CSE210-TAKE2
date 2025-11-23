using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        var wordTexts = text.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        _words = new List<Word>();
        foreach (var wordText in wordTexts)
        {
            _words.Add(new Word(wordText));
        }
    }

    public bool IsCompletelyHidden => _words.All(w => w.IsHidden);

    public string DisplayScripture()
    {
        string scriptureText = _reference.DisplayReference() + "\n";
        foreach (Word word in _words)
        {
            scriptureText += word.ToString() + " ";
        }
        return scriptureText.Trim();
    }

    public void HideWords(int count)
    {
        const int wordsToHideCount = 3;

        List<Word> availableWords = _words.Where(w => !w.IsHidden).ToList();

        if (availableWords.Count == 0) return;
        
        Random rand = new Random();

        int wordsToHide = Math.Min(count, availableWords.Count);

        for (int i = 0; i < wordsToHide; i++)
        {
            int index = rand.Next(availableWords.Count);
            availableWords[index].Hide();
            availableWords.RemoveAt(index);
        }  
    }
}