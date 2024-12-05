public enum FarmProductType
{
    Wheat,
    Milk,
    Eggs
}

public class FarmProduct : IItem
{
    public FarmProductType Type { get; protected set; }

    public FarmProduct(FarmProductType type)
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
            FarmProductType.Wheat => 10,
            FarmProductType.Milk => 15,
            FarmProductType.Eggs => 12,
            _ => 0,
        };
    }
}
