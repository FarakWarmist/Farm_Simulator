public enum PlantType
{
    Flower,
    AloeVera,
    Sap,
    Seed,
    Tea,
    Mind,
    Berry
}

public class Plant : IItem
{
    public PlantType Type { get; set; }

    public Plant(PlantType type)
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
            PlantType.Flower => 5,
            PlantType.AloeVera => 10,
            PlantType.Sap => 12,
            PlantType.Seed => 5,
            PlantType.Tea => 18,
            PlantType.Mind => 15,
            PlantType.Berry => 15,
            _ => 0,
        };
    }
}
