using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No journal entries available.");
            return;
        }

        Console.WriteLine("\n=== Journal Entries ===");

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("A filename is required to save the journal.");
            return;
        }

        try
        {
            string json = JsonSerializer.Serialize(_entries, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(filename, json);
            Console.WriteLine($"Journal saved successfully to {filename}.");
        }
        catch (Exception ex) when (
            ex is IOException ||
            ex is UnauthorizedAccessException ||
            ex is ArgumentException ||
            ex is NotSupportedException)
        {
            Console.WriteLine($"Error saving journal: {ex.Message}");
        }
    }

    public void LoadFromFile(string filename)
    {
        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("A filename is required to load the journal.");
            return;
        }

        try
        {
            string json = File.ReadAllText(filename);
            List<Entry> loadedEntries = JsonSerializer.Deserialize<List<Entry>>(json);

            if (loadedEntries == null)
            {
                Console.WriteLine("The file does not contain a valid journal.");
                return;
            }

            _entries = loadedEntries;
            Console.WriteLine($"Journal loaded successfully from {filename}.");
        }
        catch (Exception ex) when (
            ex is IOException ||
            ex is UnauthorizedAccessException ||
            ex is ArgumentException ||
            ex is NotSupportedException ||
            ex is JsonException)
        {
            Console.WriteLine($"Error loading journal: {ex.Message}");
        }
    }

    public void ShowStatistics()
    {
        Console.WriteLine($"\nTotal Journal Entries: {_entries.Count}");
    }
}