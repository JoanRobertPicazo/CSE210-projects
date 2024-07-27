public class ChecklistGoal : Goal
{
    public int RequiredCompletions { get; set; } // required completions
    public int CurrentCompletions { get; set; } // current completions
    public int BonusPoints { get; set; } // bonus points

    public ChecklistGoal() { } // default constructor

    public ChecklistGoal(string name, string description, int points, int requiredCompletions, int bonusPoints)
        : base(name, description, points)
    {
        RequiredCompletions = requiredCompletions; // initialize requiredCompletions
        BonusPoints = bonusPoints; // initialize bonusPoints
        CurrentCompletions = 0; // initialize currentCompletions
    }

    public override void RecordEvent()
    {
        CurrentCompletions++; // increment completions
        if (CurrentCompletions >= RequiredCompletions)
        {
            Points += BonusPoints; // add bonus points
            IsComplete = true; // mark complete
        }
    }

    public override string SaveGoal()
    {
        return $"ChecklistGoal:{Name},{Description},{Points},{RequiredCompletions},{CurrentCompletions},{BonusPoints}"; // return save format
    }

    public override void LoadGoal(string[] parts)
    {
        if (parts.Length < 6) // check length
            throw new FormatException("Invalid data format for ChecklistGoal.");

        Name = parts[1]; // set name
        Description = parts[2]; // set description
        Points = int.Parse(parts[3]); // set points
        RequiredCompletions = int.Parse(parts[4]); // set required completions
        CurrentCompletions = int.Parse(parts[5]); // set current completions
        BonusPoints = int.Parse(parts[6]); // set bonus points
    }
}
