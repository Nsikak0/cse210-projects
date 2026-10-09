using System;
using System.Collections.Generic;

public class ScriptureLibrary
{
    private readonly List<Scripture> _scriptures;
    private readonly Random _random;

    public ScriptureLibrary()
    {
        _scriptures = new List<Scripture>
        {
            new Scripture(
            new Reference("John", 3, 16),
            "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),

            new Scripture(
            new Reference("Proverbs", 3, 5, 6),
            "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."),

            new Scripture(
            new Reference("Psalm", 23, 1),
            "The Lord is my shepherd; I shall not want."),

            new Scripture(
            new Reference("Philippians", 4, 13),
            "I can do all things through Christ which strengtheneth me.")
        };

        _random = new Random();
    }

    public Scripture GetRandomScripture()
    {
        int index = _random.Next(_scriptures.Count);
        return _scriptures[index];
    }
}