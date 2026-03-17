// - Program randomly selects from multiple scriptures
// - This improves memorization practice variety

using System;

class Program
{
    static void Main(string[] args)
    {
        // EXCEEDING REQUIREMENTS:
        // Random scripture selection
        Random rand = new Random();

        Reference ref1 = new Reference("John", 3, 16);
        Reference ref2 = new Reference("Proverbs", 3, 5, 6);

        string text1 = "For God so loved the world that he gave his only begotten Son";
        string text2 = "Trust in the Lord with all thine heart and lean not unto thine own understanding";

        Scripture scripture;

        if (rand.Next(2) == 0)
        {
            scripture = new Scripture(ref1, text1);
        }
        else
        {
            scripture = new Scripture(ref2, text2);
        }

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            if (scripture.IsCompletelyHidden())
            {
                break;
            }

            Console.WriteLine("\nPress Enter to continue or type 'quit'");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }
    }
}