using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Who are people you appreciate?",
        "What are your strengths?",
        "Who have you helped recently?"
    };

    private int _count;
    private Random _rand = new Random();

    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "List as many positive things as you can.";
    }

    public void Run()
    {
        DisplayStartingMessage();

        string prompt = _prompts[_rand.Next(_prompts.Count)];
        Console.WriteLine($"\n{prompt}");

        Console.Write("You may begin in: ");
        ShowCountDown(5);

        DateTime end = DateTime.Now.AddSeconds(_duration);
        _count = 0;

        while (DateTime.Now < end)
        {
            Console.Write("> ");
            Console.ReadLine();
            _count++;
        }

        Console.WriteLine($"\nYou listed {_count} items!");

        DisplayEndingMessage();
    }
}