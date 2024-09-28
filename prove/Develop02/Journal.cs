public class Journal
{
    // List to store journal entries
    public List<Entry> Entries { get; set; }
    public Journal()
    {
        Entries = new List<Entry>();
    }

    // Add a new entry to the journal
    public void AddEntry(Entry entry)
    {
        Entries.Add(entry);
    }

    // Display all entries in the journal
    public void DisplayJournal()
    {
        foreach (var entry in Entries)
        {
            Console.WriteLine(entry);
        }
    }

    // Save the journal entries to a file
    public void SaveJournal(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in Entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }
        Console.WriteLine($"Journal saved to {filename}");
    }

    // Load the journal entries from a file
    public void LoadJournal(string filename)
    {
        if (File.Exists(filename))
        {
            Entries.Clear();
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split('|');
                    if (parts.Length == 3)
                    {
                        var entry = new Entry(parts[1], parts[2]) { Date = parts[0] };
                        Entries.Add(entry);
                    }
                }
            }
            Console.WriteLine($"Journal loaded from {filename}");
        }
        else
        {
            Console.WriteLine($"File {filename} not found.");
        }
    }
}