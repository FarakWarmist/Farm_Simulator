using UnityEngine;

[System.Serializable]
public class PlayerData
{
    [SerializeField] private int _gold;
    [SerializeField] private int _dette;

    public int Gold
    {
        get => _gold;
        set => _gold = Mathf.Max(0, value);
    }

    public int Dette
    {
        get => _dette;
        set => _dette = Mathf.Max(0, value);
    }

    public PlayerData()
    {
        Gold = 200;
        Dette = 500;
    }
}
