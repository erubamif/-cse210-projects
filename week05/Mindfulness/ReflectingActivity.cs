using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Think of a time you helped someone.",
        "Think of a time you overcame a challenge.",
        "Think of a time you showed courage."
    };

    private List<string> _questions = new List<string>()
    {
        "Why was this meaningful?",
        "What did you learn?",
        "How did you feel?",
        "What made it successful?"
    };

    private Random _rand = new Random();

    public ReflectingActivity()
    {
        _name = "Reflecting Activity";
        _description = "This helps you reflect on meaningful experiences.";
    }

    public void Run()
    {
        DisplayStartingMessage();

        string prompt = _prompts[_rand.Next(_prompts.Count)];
        Console.WriteLine($"\n{prompt}");
        ShowSpinner(3);

        DateTime end = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < end)
        {
            string question = _questions[_rand.Next(_questions.Count)];
            Console.WriteLine($"\n{question}");
            ShowSpinner(4);
        }

        DisplayEndingMessage();
    }
}