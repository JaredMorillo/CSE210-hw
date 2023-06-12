public class ReflectionActivity : Activity
{
    private readonly Random random;
    private readonly List<string> prompts;
    private readonly List<string> questions;

    public ReflectionActivity()
    {
        random = new Random();
        prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }

    public override void Start()
    {
        ShowStartingMessage();
        ShowReflectionInstructions();
        PerformReflectionActivity();
        ShowEndingMessage();
    }

    private void ShowReflectionInstructions()
    {
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience.");
        Console.WriteLine("This will help you recognize the power you have and how you can use it in other aspects of your life.");
    }

    private void PerformReflectionActivity()
    {
        int questionCount = Math.Min(duration, questions.Count);

        for (int i = 0; i < questionCount; i++)
        {
            string prompt = GetRandomPrompt();
            string question = GetRandomQuestion();

            Console.WriteLine(prompt);
            Pause(2);
            Console.WriteLine("Reflect on the following question:");
            Console.WriteLine(question);
            ShowSpinner();
            Pause(5);
        }
    }

    private string GetRandomPrompt()
    {
        int index = random.Next(prompts.Count);
        return prompts[index];
    }

    private string GetRandomQuestion()
    {
        int index = random.Next(questions.Count);
        return questions[index];
    }

    private void ShowSpinner()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.Write("/");
            Pause(0.1);
            Console.Write("\b");
            Console.Write("-");
            Pause(0.1);
            Console.Write("\b");
            Console.Write("\\");
            Pause(0.1);
            Console.Write("\b");
            Console.Write("|");
            Pause(0.1);
            Console.Write("\b");
        }
        Console.WriteLine();
    }
}