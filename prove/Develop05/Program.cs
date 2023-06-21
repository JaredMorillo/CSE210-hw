using System;
public class Program
{
    private static List<Goal> goals = new List<Goal>();

    public static void Main(string[] args)
    {
        LoadGoals();

        while (true)
        {
            Console.WriteLine("Eternal Quest Program");
            Console.WriteLine("---------------------");
            Console.WriteLine("1. Create a new goal");
            Console.WriteLine("2. Record an event");
            Console.WriteLine("3. Display goals");
            Console.WriteLine("4. Save goals");
            Console.WriteLine("5. Load goals");
            Console.WriteLine("6. Quit goal");
            Console.WriteLine("7. Exit");
            Console.WriteLine();

            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    CreateGoal();
                    break;
                case 2:
                    RecordEvent();
                    break;
                case 3:
                    DisplayGoals();
                    break;
                case 4:
                    SaveGoals();
                    break;
                case 5:
                    LoadGoals();
                    break;
                case 6:
                    QuitGoal();
                    break;
                case 7:
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    private static void CreateGoal()
    {
        Console.WriteLine("Create a new goal");
        Console.WriteLine("-----------------");

        Console.Write("Enter the goal name: ");
        string name = Console.ReadLine();

        Console.Write("Enter the goal description: ");
        string description = Console.ReadLine();

        Console.Write("Enter the points for the goal: ");
        int points = Convert.ToInt32(Console.ReadLine());

        Console.Write("Select the goal type (1. Simple, 2. Eternal, 3. Checklist): ");
        int type = Convert.ToInt32(Console.ReadLine());

        Goal goal;

        switch (type)
        {
            case 1:
                goal = new SimpleGoal();
                break;
            case 2:
                goal = new EternalGoal();
                break;
            case 3:
                goal = new ChecklistGoal();
                Console.Write("Enter the target count for the checklist goal: ");
                ((ChecklistGoal)goal).TargetCount = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the bonus points for the checklist goal: ");
                ((ChecklistGoal)goal).Bonus = Convert.ToInt32(Console.ReadLine());
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                return;
        }

        goal.Name = name;
        goal.Description = description;
        goal.Points = points;
        goals.Add(goal);

        Console.WriteLine("Goal created successfully!");
    }

    private static void RecordEvent()
    {
        Console.WriteLine("Record an event");
        Console.WriteLine("----------------");

        Console.WriteLine("Select a goal to record an event for:");
        DisplayGoals();

        Console.Write("Enter the goal index: ");
        int index = Convert.ToInt32(Console.ReadLine());

        if (index >= 0 && index < goals.Count)
        {
            Goal goal = goals[index];
            if (!goal.IsComplete())
            {
                goal.RecordEvents();
                Console.WriteLine("Event recorded successfully!");
            }
            else
            {
                Console.WriteLine("Goal is already complete.");
            }
        }
        else
        {
            Console.WriteLine("Invalid goal index.");
        }
    }

    private static void DisplayGoals()
    {
        Console.WriteLine("Goals");
        Console.WriteLine("-----");

        for (int i = 0; i < goals.Count; i++)
        {
            Goal goal = goals[i];
            Console.Write($"{i}. {goal.Name}");

            if (goal.IsComplete())
            {
                Console.Write(" [Completed]");
            }

            Console.WriteLine();
        }
    }

    private static void SaveGoals()
    {
        foreach (var goal in goals)
        {
            goal.SaveToFile();
        }

        Console.WriteLine("Goals saved successfully!");
    }

    private static void LoadGoals()
    {
        goals.Clear();

        // Load goals from storage
        // You can add your own logic here

        Console.WriteLine("Goals loaded successfully!");
    }

    private static void QuitGoal()
    {
        Console.WriteLine("Quit a goal");
        Console.WriteLine("------------");

        Console.WriteLine("Select a goal to quit:");
        DisplayGoals();

        Console.Write("Enter the goal index: ");
        int index = Convert.ToInt32(Console.ReadLine());

        if (index >= 0 && index < goals.Count)
        {
            Goal goal = goals[index];
            goal.Quit();
            goals.Remove(goal);

            Console.WriteLine("Goal quit successfully!");
        }
        else
        {
            Console.WriteLine("Invalid goal index.");
        }
    }
}

public abstract class Goal
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Points { get; set; }

    public abstract void DisplayGoal();
    public abstract bool IsComplete();

    public virtual void SaveToFile()
    {
        // Save goal to a file
        // You can add your own logic here
    }

    public virtual void LoadFromFile()
    {
        // Load goal from a file
        // You can add your own logic here
    }

    public virtual void RecordEvents()
    {
        // Record events for the goal
        // You can add your own logic here
    }

    public virtual void Quit()
    {
        // Quit the goal
        // You can add your own logic here
    }
}

// Simple goal that can be marked complete for points
public class SimpleGoal : Goal
{
    public override void DisplayGoal()
    {
        Console.WriteLine($"Simple Goal: {Name}");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine($"Points: {Points}");
    }

    public override bool IsComplete()
    {
        // Check if the simple goal is complete
        // You can add your own logic here
        return false;
    }
}

// Eternal goal that can be recorded for points
public class EternalGoal : Goal
{
    public override void DisplayGoal()
    {
        Console.WriteLine($"Eternal Goal: {Name}");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine($"Points: {Points}");
    }

    public override bool IsComplete()
    {
        // Eternal goal is never complete
        return false;
    }

    public override void RecordEvents()
    {
        // Record events for the eternal goal
        // You can add your own logic here
    }
}

// Checklist goal that requires a certain number of completions
public class ChecklistGoal : Goal
{
    public int CompletionCount { get; set; }
    public int Bonus { get; set; }
    public int TargetCount { get; set; }

    public override void DisplayGoal()
    {
        Console.WriteLine($"Checklist Goal: {Name}");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine($"Points: {Points}");
        Console.WriteLine($"Completion Count: {CompletionCount}/{TargetCount}");
    }

    public override bool IsComplete()
    {
        return CompletionCount >= TargetCount;
    }

    public override void RecordEvents()
    {
        CompletionCount++;
        // Record events for the checklist goal
        // You can add your own logic here

        if (IsComplete())
        {
            Points += Bonus;
        }
    }
}