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

    static void StartActivity(Activity activity)
    {
        activity.Start();
        Console.WriteLine();
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
}