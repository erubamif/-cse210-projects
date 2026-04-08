using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to hold activities (Polymorphism!)
        List<Activity> activities = new List<Activity>();

        // Add at least one activity of each type
        activities.Add(new Running(new DateTime(2022, 11, 3), 30, 3.0));
        activities.Add(new StationaryBicycles(new DateTime(2022, 11, 4), 45, 12.0));
        activities.Add(new Swimming(new DateTime(2022, 11, 5), 40, 30));

        // Also add a few more for variety
        activities.Add(new Running(new DateTime(2022, 11, 6), 25, 2.5));
        activities.Add(new StationaryBicycles(new DateTime(2022, 11, 7), 60, 15.0));
        activities.Add(new Swimming(new DateTime(2022, 11, 8), 30, 20));

        // Display summary for each activity
        Console.WriteLine("╔══════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                    EXERCISE TRACKING SUMMARY                    ║");
        Console.WriteLine("╚══════════════════════════════════════════════════════════════════╝");
        Console.WriteLine();

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}