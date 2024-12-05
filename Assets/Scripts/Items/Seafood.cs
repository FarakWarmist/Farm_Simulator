public enum FishType
{
    Fish,
    Crab,
    Shrimp,
    Oyster,
    Trash
}

public class Seafood : IItem
{
    public FishType Type { get; private set; }

    public Seafood(FishType type)
    {
        Type = type;
    }

    public string GetName()
    {
        return Type.ToString();
    }

    public int GetValue()
    {
        return Type switch
        {
            FishType.Fish => 5,
            FishType.Crab => 8,
            FishType.Shrimp => 10,
            FishType.Oyster => 15,
            FishType.Trash => 0,
            _ => 0,
        };
    }
}
