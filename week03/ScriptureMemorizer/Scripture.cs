using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private readonly Reference _reference;
    private readonly List<Word> _words;
    private readonly Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference ?? throw new ArgumentNullException(nameof(reference));
        ArgumentException.ThrowIfNullOrWhiteSpace(text);
        _words = text.Split((char[])null, StringSplitOptions.RemoveEmptyEntries)
                     .Select(word => new Word(word))
                     .ToList();
        _random = new Random();
    }

    public void HideRandomWords(int count = 2)
    {
        if (count < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(count));
        }

        List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();

        for (int i = 0; i < count && visibleWords.Count > 0; i++)
        {
            int index = _random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }

    public string GetDisplayText()
    {
        return $"{_reference.GetDisplayText()}{Environment.NewLine}{Environment.NewLine}" +
               string.Join(" ", _words.Select(word => word.GetDisplayText()));
    }
}