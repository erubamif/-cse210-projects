using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private LevelingManager _levelManager;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _levelManager = new LevelingManager();
    }

    public void Start()
    {
        int choice = 0;
        while (choice != 7)
        {
            DisplayPlayerInfo();
            Console.WriteLine("\n╔══════════════════════════════════════╗");
            Console.WriteLine("║         ETERNAL QUEST MENU           ║");
            Console.WriteLine("╠══════════════════════════════════════╣");
            Console.WriteLine("║  1. Create New Goal                  ║");
            Console.WriteLine("║  2. List Goals                       ║");
            Console.WriteLine("║  3. Save Goals                       ║");
            Console.WriteLine("║  4. Load Goals                       ║");
            Console.WriteLine("║  5. Record Event                     ║");
            Console.WriteLine("║  6. Show Level Info                  ║");
            Console.WriteLine("║  7. Quit                             ║");
            Console.WriteLine("╚══════════════════════════════════════╝");
            Console.Write("Select a choice: ");
            
            choice = int.Parse(Console.ReadLine() ?? "0");

            switch (choice)
            {
                case 1: CreateGoal(); break;
                case 2: ListGoalDetails(); break;
                case 3: SaveGoals(); break;
                case 4: LoadGoals(); break;
                case 5: RecordEvent(); break;
                case 6: ShowLevelInfo(); break;
                case 7: 
                    Console.WriteLine("\n✨ May your Eternal Quest continue! ✨"); 
                    break;
                default: 
                    Console.WriteLine("Invalid choice. Please try again."); 
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\n🏆 CURRENT SCORE: {_score} points");
        Console.WriteLine($"📊 {_levelManager.GetLevelInfo()}");
    }

    public void ShowLevelInfo()
    {
        Console.WriteLine("\n╔══════════════════════════════════════╗");
        Console.WriteLine("║         LEVELING SYSTEM INFO         ║");
        Console.WriteLine("╚══════════════════════════════════════╝");
        Console.WriteLine($"Level: {_levelManager.GetCurrentLevel()}");
        Console.WriteLine($"Title: {_levelManager.GetLevelTitle()}");
        Console.WriteLine($"Total Points Earned: {_levelManager.GetTotalPoints()}");
        if (_levelManager.GetPointsToNextLevel() > 0)
        {
            Console.WriteLine($"Points needed for next level: {_levelManager.GetPointsToNextLevel()}");
        }
        else
        {
            Console.WriteLine("🏆 You have reached the MAXIMUM level! 🏆");
        }
    }

    public void ListGoalNames()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals created yet.");
            return;
        }
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\n📋 No goals created yet. Create some goals first!");
            return;
        }
        
        Console.WriteLine("\n╔══════════════════════════════════════╗");
        Console.WriteLine("║              YOUR GOALS              ║");
        Console.WriteLine("╚══════════════════════════════════════╝");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\n📌 The types of goals are:");
        Console.WriteLine("  1. Simple Goal (Complete once)");
        Console.WriteLine("  2. Eternal Goal (Repeatable forever)");
        Console.WriteLine("  3. Checklist Goal (Complete multiple times)");
        Console.WriteLine("  4. Negative Goal (Track bad habits - LOSES points) ✨NEW✨");
        Console.Write("Which type of goal would you like to create? ");
        
        int type = int.Parse(Console.ReadLine() ?? "0");
        
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine() ?? "";
        
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine() ?? "";

        switch (type)
        {
            case 1:
                Console.Write("What is the amount of points associated with this goal? ");
                int points = int.Parse(Console.ReadLine() ?? "0");
                _goals.Add(new SimpleGoal(name, description, points));
                Console.WriteLine($"✅ Simple goal '{name}' created!");
                break;
                
            case 2:
                Console.Write("What is the amount of points associated with this goal? ");
                int eternalPoints = int.Parse(Console.ReadLine() ?? "0");
                _goals.Add(new EternalGoal(name, description, eternalPoints));
                Console.WriteLine($"♾️ Eternal goal '{name}' created!");
                break;
                
            case 3:
                Console.Write("What is the amount of points associated with this goal? ");
                int checkPoints = int.Parse(Console.ReadLine() ?? "0");
                Console.Write("How many times does this goal need to be accomplished? ");
                int target = int.Parse(Console.ReadLine() ?? "0");
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine() ?? "0");
                _goals.Add(new ChecklistGoal(name, description, checkPoints, target, bonus));
                Console.WriteLine($"📋 Checklist goal '{name}' created! (0/{target})");
                break;
                
            case 4:  // CREATIVE ADDITION: Negative goals
                Console.Write("What is the PENALTY (points to lose) for this bad habit? ");
                int penalty = int.Parse(Console.ReadLine() ?? "0");
                _goals.Add(new NegativeGoal(name, description, penalty));
                Console.WriteLine($"⚠️ Negative goal '{name}' created! You'll lose {penalty} points each time.");
                break;
                
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\n📋 No goals created yet. Create some goals first!");
            return;
        }
        
        Console.WriteLine("\n📋 The goals are:");
        ListGoalNames();
        Console.Write("Which goal did you accomplish? (Enter number): ");
        
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= _goals.Count)
        {
            Goal selectedGoal = _goals[index - 1];
            int pointsEarned = selectedGoal.RecordEvent();
            
            if (pointsEarned > 0)
            {
                _score += pointsEarned;
                int levelUp = _levelManager.AddPoints(pointsEarned);
                
                Console.WriteLine($"\n🎉 Congratulations! You earned {pointsEarned} points!");
                
                if (levelUp > 0)
                {
                    Console.WriteLine($"🌟 LEVEL UP! You are now Level {levelUp} {_levelManager.GetLevelTitle()}! 🌟");
                }
                
                Console.WriteLine($"💰 You now have {_score} total points.");
                
                if (selectedGoal.IsComplete() && selectedGoal is SimpleGoal)
                {
                    Console.WriteLine($"✅ Goal '{selectedGoal.GetShortName()}' is now COMPLETE!");
                }
            }
            else if (pointsEarned < 0)
            {
                // Negative goal case
                _score += pointsEarned; // pointsEarned is negative
                _levelManager.AddPoints(pointsEarned);
                Console.WriteLine($"\n⚠️ Oops! You recorded a bad habit. You LOST {Math.Abs(pointsEarned)} points!");
                Console.WriteLine($"💰 You now have {_score} total points.");
            }
            else
            {
                Console.WriteLine($"\nℹ️ Goal '{selectedGoal.GetShortName()}' has already been completed!");
            }
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("\n💾 What is the filename to save to? (e.g., goals.txt): ");
        string filename = Console.ReadLine() ?? "goals.txt";
        
        using (StreamWriter writer = new StreamWriter(filename))
        {
            // Save score and total points earned for leveling
            writer.WriteLine($"{_score}|{_levelManager.GetTotalPoints()}");
            
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine($"✅ Goals saved successfully to {filename}");
    }

    public void LoadGoals()
    {
        Console.Write("\n📂 What is the filename to load from? (e.g., goals.txt): ");
        string filename = Console.ReadLine() ?? "goals.txt";
        
        if (!File.Exists(filename))
        {
            Console.WriteLine($"❌ File '{filename}' not found.");
            return;
        }

        _goals.Clear();
        string[] lines = File.ReadAllLines(filename);
        
        // Load score and level data
        string[] scoreParts = lines[0].Split('|');
        _score = int.Parse(scoreParts[0]);
        int totalPoints = scoreParts.Length > 1 ? int.Parse(scoreParts[1]) : _score;
        _levelManager = new LevelingManager(totalPoints);
        
        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(':');
            string type = parts[0];
            string[] data = parts[1].Split(',');
            
            switch (type)
            {
                case "SimpleGoal":
                    _goals.Add(new SimpleGoal(data[0], data[1], int.Parse(data[2]), bool.Parse(data[3])));
                    break;
                case "EternalGoal":
                    _goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2])));
                    break;
                case "ChecklistGoal":
                    _goals.Add(new ChecklistGoal(data[0], data[1], int.Parse(data[2]), 
                                                   int.Parse(data[4]), int.Parse(data[3]), int.Parse(data[5])));
                    break;
                case "NegativeGoal":
                    _goals.Add(new NegativeGoal(data[0], data[1], int.Parse(data[2])));
                    break;
            }
        }
        Console.WriteLine($"✅ Goals loaded successfully from {filename}");
        Console.WriteLine($"📊 Current Level: {_levelManager.GetLevelTitle()} (Level {_levelManager.GetCurrentLevel()})");
    }
}