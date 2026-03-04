using System;

class Program
{
    static void Main()
    {
        Console.Write("What is your grade percentage? ");
        int grade = int.Parse(Console.ReadLine());

        string letter = "";
        string sign = "";

        // Determine letter grade
        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Determine + or -
        int lastDigit = grade % 10;

        if (lastDigit >= 7)
        {
            sign = "+";
        }
        else if (lastDigit < 3)
        {
            sign = "-";
        }
        else
        {
            sign = "";
        }

        // Handle special cases
        if (letter == "A" && sign == "+")
        {
            sign = "";  // No A+
        }

        if (letter == "F")
        {
            sign = "";  // No F+ or F-
        }

        Console.WriteLine($"Your grade is {letter}{sign}.");

        // Pass / Fail message
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Don't give up! You can do better next time.");
        }
    }
}