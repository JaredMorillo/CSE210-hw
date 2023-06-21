using System;

// Base class for activities
abstract class Activity
{
    public string Name { get; set; }
    public int Value { get; set; }

    public Activity(string name, int value)
    {
        Name = name;
        Value = value;
    }

    public abstract void MarkComplete(User user);
}

// Simple goal activity
class SimpleGoal : Activity
{
    public SimpleGoal(string name, int value) : base(name, value)
    {
    }

    public override void MarkComplete(User user)
    {
        user.AddPoints(Value);
    }
}

// Eternal goal activity
class EternalGoal : Activity
{
    public EternalGoal(string name, int value) : base(name, value)
    {
    }

    public override void MarkComplete(User user)
    {
        user.AddPoints(Value);
    }
}

// Checklist goal activity
class ChecklistGoal : Activity
{
    public int TargetCount { get; set; }
    public int BonusValue { get; set; }
    private int completionCount;

    public ChecklistGoal(string name, int value, int targetCount, int bonusValue) : base(name, value)
    {
        TargetCount = targetCount;
        BonusValue = bonusValue;
        completionCount = 0;
    }

    public override void MarkComplete(User user)
    {
        user.AddPoints(Value);
        completionCount++;

        if (completionCount == TargetCount)
        {
            user.AddPoints(BonusValue);
        }
    }

    public string GetCompletionStatus()
    {
        return $"Completed {completionCount}/{TargetCount} times";
    }
}

// User class
class User
{
    public string Name { get; set; }
    public int Score { get; private set; }
    private List<Activity> goals;

    public User(string name)
    {
        Name = name;
        Score = 0;
        goals = new List<Activity>();
    }

    public void AddPoints(int points)
    {
        Score += points;
    }

    public void AddGoal(Activity goal)
    {
        goals.Add(goal);
    }

    public void MarkGoalComplete(int index)
    {
        if (index >= 0 && index < goals.Count)
        {
            Activity goal = goals[index];
            goal.MarkComplete(this);
        }
    }

    public void DisplayGoals()
    {
        Console.WriteLine($"Goals for {Name}:");
        for (int i = 0; i < goals.Count; i++)
        {
            Activity goal = goals[i];
            string completionStatus = "";
            if (goal is ChecklistGoal checklistGoal)
            {
                completionStatus = checklistGoal.GetCompletionStatus();
            }
            string completedIndicator = goal is SimpleGoal || goal is ChecklistGoal ? "[ ]" : "[X]";
            Console.WriteLine($"{completedIndicator} {goal.Name} ({completionStatus})");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        User user = new User("John");

        // Create goals
        Activity goal1 = new SimpleGoal("Run a marathon", 1000);
        Activity goal2 = new EternalGoal("Read scriptures", 100);
        Activity goal3 = new ChecklistGoal("Attend the temple", 50, 10, 500);

        // Add goals to user
        user.AddGoal(goal1);
        user.AddGoal(goal2);
        user.AddGoal(goal3);

        // Display goals and initial score
        user.DisplayGoals();
        Console.WriteLine($"Score: {user.Score}");

        // Mark goals as complete and display updated score
        user.MarkGoalComplete(0); // Run a marathon
        user.MarkGoalComplete(1); // Read scriptures
        user.MarkGoalComplete(2); // Attend the temple (1st time)
        user.MarkGoalComplete(2); // Attend the temple (2nd time)
        user.DisplayGoals();
        Console.WriteLine($"Updated Score: {user.Score}");
    }
}