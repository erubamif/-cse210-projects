// CREATIVE ADDITION: Leveling system based on total points earned
public class LevelingManager
{
    private int _totalPointsEarned;
    private int _currentLevel;
    
    private static readonly int[] _levelThresholds = {
        0,      // Level 0
        100,    // Level 1
        300,    // Level 2
        600,    // Level 3
        1000,   // Level 4
        1500,   // Level 5
        2100,   // Level 6
        2800,   // Level 7
        3600,   // Level 8
        4500,   // Level 9
        5500    // Level 10
    };
    
    private static readonly string[] _levelTitles = {
        "Seeker",
        "Disciple",
        "Acolyte",
        "Believer",
        "Servant",
        "Warrior",
        "Knight",
        "Champion",
        "Hero",
        "Legend",
        "Eternal"
    };

    public LevelingManager()
    {
        _totalPointsEarned = 0;
        _currentLevel = 0;
    }

    public LevelingManager(int totalPoints)
    {
        _totalPointsEarned = totalPoints;
        _currentLevel = CalculateLevel(totalPoints);
    }

    private int CalculateLevel(int points)
    {
        int level = 0;
        for (int i = _levelThresholds.Length - 1; i >= 0; i--)
        {
            if (points >= _levelThresholds[i])
            {
                level = i;
                break;
            }
        }
        return level;
    }

    public int AddPoints(int points)
    {
        _totalPointsEarned += points;
        int oldLevel = _currentLevel;
        _currentLevel = CalculateLevel(_totalPointsEarned);
        
        if (_currentLevel > oldLevel)
        {
            return _currentLevel; // Level up!
        }
        return -1; // No level up
    }

    public int GetCurrentLevel() => _currentLevel;
    public int GetTotalPoints() => _totalPointsEarned;
    public string GetLevelTitle() => _levelTitles[_currentLevel];
    
    public int GetPointsToNextLevel()
    {
        if (_currentLevel + 1 < _levelThresholds.Length)
        {
            return _levelThresholds[_currentLevel + 1] - _totalPointsEarned;
        }
        return 0; // Max level reached
    }

    public string GetLevelInfo()
    {
        if (GetPointsToNextLevel() > 0)
        {
            return $"Level {_currentLevel} {GetLevelTitle()} - {GetPointsToNextLevel()} pts to next level";
        }
        return $"Level {_currentLevel} {GetLevelTitle()} - MAX LEVEL!";
    }
}