using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManagerPlayerData : MonoBehaviour, ISave
{
    public static GameManagerPlayerData Instance { get; private set; }
    [SerializeField] private int _gold;
    [SerializeField] private float _dette;
    [SerializeField] private Produit _produit;

    public int Gold
    {
        get { return _gold; }
        set { _gold = Mathf.Max(0, value); }
    }

    public float Dette
    {
        get { return _dette; }
        set { _dette = Mathf.Max(0, value); }
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SaveData()
    {
        string json = JsonUtility.ToJson(this, true);
        string file_pathPlayer = Path.Combine(Application.persistentDataPath, "Player.json");
        File.WriteAllText(file_pathPlayer, json);

        InventoryPlayerSave produitListSave = new InventoryPlayerSave(Produit.ProduitPlayer);
        string produitJson = JsonUtility.ToJson(produitListSave, true);
        string file_pathJson = Path.Combine(Application.persistentDataPath, "PlayerInventory.json");
        File.WriteAllText(file_pathJson, produitJson);
    }

    public void LoadData()
    {
        string file_path = Path.Combine(Application.persistentDataPath, "Player.json");

        if (File.Exists(file_path))
        {
            string json = File.ReadAllText(file_path);
            JsonUtility.FromJsonOverwrite(json, this);
        }

        string file_pathProduit = Path.Combine(Application.persistentDataPath, "PlayerInventory.json");
        if (File.Exists(file_pathProduit))
        {
            string produitJson = File.ReadAllText(file_pathProduit);
            InventoryPlayerSave produitListSave = JsonUtility.FromJson<InventoryPlayerSave>(produitJson);
            Produit.ProduitPlayer = produitListSave.ProduitList;
        }
    }

    public void DeleteData()
    {
        string file_pathPlayer = Path.Combine(Application.persistentDataPath, "Player.json");

        if (File.Exists(file_pathPlayer))
        {
            File.Delete(file_pathPlayer);
        }

        string file_pathInventory = Path.Combine(Application.persistentDataPath, "PlayerInventory");

        if (File.Exists(file_pathInventory))
        {
            File.Delete(file_pathInventory);
        }
    }
}
