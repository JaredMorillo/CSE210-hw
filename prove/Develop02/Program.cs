using System;
class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool done = false;
        Random rand = new Random();
        while (!done)
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Add new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Exit");
            string choice = Console.ReadLine();
            switch (choice)
            {
                    case "1":
                    string[] prompts = {
                        "Who was the most interesting person I interacted with today?",
                        "What was the best part of my day?",
                        "How did I see the hand of the Lord in my life today?",
                        "What was the strongest emotion I felt today?",
                        "If I had one thing I could do over today, what would it be?"
                    };
                    string prompt = prompts[rand.Next(prompts.Length)];
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.WriteLine("Enter your response:");
                    string response = Console.ReadLine();
                    JournalEntry entry = new JournalEntry
                    {
                        Prompt = prompt,
                        Response = response,
                        Date = DateTime.Now.ToString()
                    };
                    journal.AddEntry(entry);
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    Console.WriteLine("Enter filename to save to:");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    break;
                case "4":
                    Console.WriteLine("Enter filename to load from:");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    break;
                case "5":
                    done = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}



class JournalEntry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }
}



class Journal
{
    private List<JournalEntry> entries;
    public Journal()
    {
        entries = new List<JournalEntry>();
    }
    public void AddEntry(JournalEntry entry)
    {
        entries.Add(entry);
    }
    public void DisplayEntries()
    {
        foreach (JournalEntry entry in entries)
        {
            Console.WriteLine($"{entry.Date} - {entry.Prompt}\n > {entry.Response}");
        }
    }
    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (JournalEntry entry in entries)
            {
                writer.WriteLine($"{entry.Date},{entry.Prompt},{entry.Response}");
            }
        }
    }
    public void LoadFromFile(string filename)
    {
        entries.Clear();
        using (StreamReader reader = new StreamReader(filename))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] fields = line.Split(',');
                JournalEntry entry = new JournalEntry
                {
                    Date = fields[0],
                    Prompt = fields[1],
                    Response = fields[2]
                };
                entries.Add(entry);
            }
        }
    }
}
