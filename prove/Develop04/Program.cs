using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("=== Activities Menu ===");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    StartActivity(new BreathingActivity());
                    break;
                case "2":
                    StartActivity(new ReflectionActivity());
                    break;
                case "3":
                    StartActivity(new ListingActivity());
                    break;
                case "4":
                    Console.WriteLine("Exiting program...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

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
    
    static void StartActivity(Activity activity)
    {
        activity.Start();
        Console.WriteLine();
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
}