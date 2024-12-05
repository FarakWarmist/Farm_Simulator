public enum MeatType
{
    Deer,
    Boar
}

public class Meat : IItem
{
    public MeatType Type { get; private set; }

    public Meat(MeatType type)
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
            MeatType.Deer => 15,
            MeatType.Boar => 20,
            _ => 0,
        };
    }
}
