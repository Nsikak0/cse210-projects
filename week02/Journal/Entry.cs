public class Entry
{
    public string Date { get; set; }
    public string PromptText { get; set; }
    public string EntryText { get; set; }
    public string Mood { get; set; }

    public void Display()
    {
        Console.WriteLine("----------------------------------------");
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt: {PromptText}");
        Console.WriteLine($"Mood: {Mood}");
        Console.WriteLine($"Entry: {EntryText}");
        Console.WriteLine("----------------------------------------\n");
    }
}