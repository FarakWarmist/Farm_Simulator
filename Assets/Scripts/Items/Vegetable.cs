public enum VegetableType
{
    Potato,
    Tomato,
    Salad,
    Carrot
}

public class Vegetable : IItem
{
    public VegetableType Type { get; protected set; }

    public Vegetable(VegetableType type)
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
            VegetableType.Potato => 5,
            VegetableType.Tomato => 8,
            VegetableType.Salad => 12,
            VegetableType.Carrot => 10,
            _ => 0,
        };
    }
}
