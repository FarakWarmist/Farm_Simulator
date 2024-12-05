using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerGame : MonoBehaviour
{
    private static GameManagerGame Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

       LoadGameSave();
    }

    private void LoadGameSave() // Charger la sauvegarde des fichers
    {
        //if (GameManagerPlayerData.Instance != null)
        //{
        //    GameManagerPlayerData.Instance.DeleteData();
        //}

        if (GameManagerTime.Instance != null)
        {
           GameManagerTime.Instance.DeleteData();
        }
    }
}
