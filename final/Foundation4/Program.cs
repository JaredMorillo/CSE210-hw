using System;

class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>();

        Running runningActivity = new Running
        {
            Date = new DateTime(2022, 11, 3),
            LengthInMinutes = 30,
            Distance = 3.0
        };
        activities.Add(runningActivity);

        Cycling cyclingActivity = new Cycling
        {
            Date = new DateTime(2022, 11, 3),
            LengthInMinutes = 30,
            Speed = 6.0
        };
        activities.Add(cyclingActivity);

        Swimming swimmingActivity = new Swimming
        {
            Date = new DateTime(2022, 11, 3),
            LengthInMinutes = 30,
            Laps = 80
        };
        activities.Add(swimmingActivity);

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}