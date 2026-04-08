/*
 * ETERNAL QUEST PROGRAM
 * =====================
 * 
 * CREATIVE EXCEEDING REQUIREMENTS:
 * 
 * 1. NEGATIVE GOALS - Added a new goal type for tracking bad habits
 *    - Users lose points when recording negative goals
 *    - Helps break unwanted behaviors through point penalties
 *    - Shows [!] instead of checkbox in the list
 * 
 * 2. LEVELING SYSTEM - Complete gamification progression system
 *    - 11 levels with unique titles (Seeker → Eternal)
 *    - Points needed increase progressively
 *    - Visual level-up celebration when advancing
 *    - Shows progress to next level
 *    - Titles reflect spiritual progression theme
 * 
 * 3. ENHANCED UI - Better visual presentation
 *    - Box-drawing characters for menu borders
 *    - Emoji icons for different goal types and status
 *    - Colorful feedback messages
 *    - Clear visual separation between sections
 * 
 * 4. IMPROVED FEEDBACK
 *    - Level up celebrations with special messages
 *    - Different messages for positive vs negative goals
 *    - Completion confirmation for simple goals
 * 
 * Level Titles:
 * Level 0: Seeker      (0 pts)
 * Level 1: Disciple    (100 pts)
 * Level 2: Acolyte     (300 pts)
 * Level 3: Believer    (600 pts)
 * Level 4: Servant     (1000 pts)
 * Level 5: Warrior     (1500 pts)
 * Level 6: Knight      (2100 pts)
 * Level 7: Champion    (2800 pts)
 * Level 8: Hero        (3600 pts)
 * Level 9: Legend      (4500 pts)
 * Level 10: Eternal    (5500+ pts)
 */

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("╔══════════════════════════════════════════════════╗");
        Console.WriteLine("║            WELCOME TO ETERNAL QUEST              ║");
        Console.WriteLine("║     Track your goals and grow on your journey    ║");
        Console.WriteLine("╚══════════════════════════════════════════════════╝");
        
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}