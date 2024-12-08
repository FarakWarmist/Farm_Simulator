using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManagerPlayerData : MonoBehaviour, ISave
{
    public static GameManagerPlayerData Instance { get; private set; }
    public PlayerData PlayerData { get; private set; }
    public InventoryPlayerSave PlayerInventory { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
    }

    public void SaveData()
    {
        //Pour save le player (Gold et Dette)
        string json = JsonUtility.ToJson(PlayerData, true);
        string file_pathPlayer = Path.Combine(Application.persistentDataPath, "Player.json");
        File.WriteAllText(file_pathPlayer, json);
        Debug.Log($"{PlayerData.Gold}, {PlayerData.Dette}");

        //Pour save l'Inventaire
        PlayerInventory = new InventoryPlayerSave(ProduitManager.ProduitsPlayer);
        string produitJson = JsonUtility.ToJson(PlayerInventory, true);
        string file_pathJson = Path.Combine(Application.persistentDataPath, "PlayerInventory.json");
        File.WriteAllText(file_pathJson, produitJson);
    }

    public void LoadData()
    {
        string file_path = Path.Combine(Application.persistentDataPath, "Player.json");

        if (File.Exists(file_path))
        {
            string json = File.ReadAllText(file_path);
            PlayerData = JsonUtility.FromJson<PlayerData>(json);
            Debug.Log($"{PlayerData.Gold}, {PlayerData.Dette}");
        }
        else
        {
            PlayerData = new PlayerData();
            Debug.Log($"{PlayerData.Gold}, {PlayerData.Dette}");
        }

        string file_pathProduit = Path.Combine(Application.persistentDataPath, "PlayerInventory.json");
        if (File.Exists(file_pathProduit))
        {
            string produitJson = File.ReadAllText(file_pathProduit);
            PlayerInventory = JsonUtility.FromJson<InventoryPlayerSave>(produitJson);

            ProduitManager.ProduitsPlayer.Clear();
            ProduitManager.ProduitsPlayer.AddRange(PlayerInventory.ProduitList);
        }
        else
        {
            PlayerInventory = new InventoryPlayerSave(ProduitManager.ProduitsPlayer);
        }
    }

    public void DeleteData()
    {
        string file_pathPlayer = Path.Combine(Application.persistentDataPath, "Player.json");

        if (File.Exists(file_pathPlayer))
        {
            File.Delete(file_pathPlayer);
            PlayerData = new PlayerData();
        }

        string file_pathInventory = Path.Combine(Application.persistentDataPath, "PlayerInventory.json");

        if (File.Exists(file_pathInventory))
        {
            File.Delete(file_pathInventory);
            PlayerInventory = new InventoryPlayerSave(ProduitManager.ProduitsPlayer);
        }
    }
}