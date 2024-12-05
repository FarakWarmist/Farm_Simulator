public enum WoodType
{
    Pin,
    Birch,
    Maple
}

public class Wood : IItem
{
    public WoodType Type { get; protected set; }

    public Wood(WoodType type)
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
            WoodType.Pin => 10,
            WoodType.Birch => 15,
            WoodType.Maple => 20,
            _ => 0,
        };
    }
}
