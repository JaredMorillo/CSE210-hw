public abstract class Activity
{
    protected int duration;

    public abstract void Start();

    protected void ShowStartingMessage(string activityName, string description)
    {
        Console.WriteLine("Welcome to " + activityName + "!");
        Console.WriteLine(description);
        Console.Write("Enter the duration in seconds: ");
        duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Get ready to begin...");
        Pause(3);
    }

    protected void ShowEndingMessage(string activityName)
    {
        Console.WriteLine("Great job! You have completed the " + activityName + ".");
        Console.WriteLine("Duration: " + duration + " seconds");
        Pause(3);
    }

    protected void Pause(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write("Pausing ");
            ShowSpinner();
            Console.WriteLine();
            Thread.Sleep(1000);
        }
    }

    protected void ShowSpinner()
    {
        string[] spinners = { "|", "/", "-", "\\" };
        int index = 0;
        for (int i = 0; i < 10; i++)
        {
            Console.Write(spinners[index % 4]);
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            index++;
            Thread.Sleep(100);
        }
    }
}