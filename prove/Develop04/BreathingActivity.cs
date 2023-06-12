public class BreathingActivity : Activity
{
    public override void Start()
    {
        ShowStartingMessage();
        ShowBreathingInstructions();
        PerformBreathingActivity();
        ShowEndingMessage();
    }

    private void ShowBreathingInstructions()
    {
        Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly.");
        Console.WriteLine("Clear your mind and focus on your breathing.");
    }

    private void PerformBreathingActivity()
    {
        int breathDuration = duration / 2; // Divide duration equally between inhaling and exhaling

        for (int i = 0; i < breathDuration; i++)
        {
            Console.WriteLine("Breathe in...");
            Pause(1);
            ShowCountdown(breathDuration - i);
            Console.WriteLine("Breathe out...");
            Pause(1);
            ShowCountdown(breathDuration - i - 1);
        }
    }

    private void ShowCountdown(int seconds)
    {
        Console.Write("Countdown: ");
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i + " ");
            Pause(1);
        }
        Console.WriteLine();
    }
}