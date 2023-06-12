public class ListeningActivity : Activity
{
    private readonly Random random;
    private readonly List<string> prompts;

    public ListeningActivity()
    {
        random = new Random();
        prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public override void Start()
    {
        ShowStartingMessage();
        ShowListeningInstructions();
        PerformListeningActivity();
        ShowEndingMessage();
    }

    private void ShowListeningInstructions()
    {
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
    }

    private void PerformListeningActivity()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine(prompt);

        Console.WriteLine("You have 10 seconds to begin listing items:");
        Pause(10);

        Console.WriteLine("Start listing items:");

        int itemCount = 0;
        Stopwatch stopwatch = Stopwatch.StartNew();

        while (stopwatch.Elapsed.TotalSeconds < duration)
        {
            string item = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(item))
            {
                break;
            }
            itemCount++;
        }

        stopwatch.Stop();

        Console.WriteLine("You entered " + itemCount + " items.");
    }

    private string GetRandomPrompt()
    {
        int index = random.Next(prompts.Count);
        return prompts[index];
    }
}