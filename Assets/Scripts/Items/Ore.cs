public enum OreType
{
    Coal,
    Copper,
    Iron,
    Gold
}

public class Ore : IItem
{
    public OreType Type { get; private set; }

    public Ore(OreType type)
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
            OreType.Coal => 5,
            OreType.Copper => 10,
            OreType.Iron => 25,
            OreType.Gold => 50,
            _ => 0,
        } ;
    }
}
