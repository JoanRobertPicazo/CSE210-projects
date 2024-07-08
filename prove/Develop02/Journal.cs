using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void AddEntry(string prompt, string response, string date)
    {
        entries.Add(new Entry(prompt, response, date));

    }
    public void DisplayEntries()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine(entry);
            Console.WriteLine(); //Separeate each entry when displayed by 1 line
        }
    }
    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename)) //StreamWriter to save enties to a file
        {
            foreach (var entry in entries)
            {
                outputFile.WriteLine($"{entry.Prompt}|{entry.Response}|{entry.Date}");
            }
        }
    }
    public void LoadFromFile(string filename)
    {
        entries.Clear();
        string[] lines = System.IO.File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split(",");
            AddEntry(parts[0], parts[1], parts[2]);
        }
    }
}