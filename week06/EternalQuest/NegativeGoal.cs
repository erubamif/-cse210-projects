// CREATIVE ADDITION: Negative goals that LOSE points when recorded
// Helps track bad habits you want to break
public class NegativeGoal : Goal
{
    private int _penalty;

    public NegativeGoal(string name, string description, int penalty) 
        : base(name, description, 0)  // No points awarded
    {
        _penalty = penalty;
    }

    public override int RecordEvent()
    {
        // Losing points for bad habits
        return -_penalty;
    }

    public override bool IsComplete() => false; // Never complete

    public override string GetDetailsString()
    {
        return $"[!] {_shortName} ({_description}) -- Penalty: -{_penalty} points";
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal:{_shortName},{_description},{_penalty}";
    }
}