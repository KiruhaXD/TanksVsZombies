using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

// этот класс можно легко передавать в javascript для сохранений
[System.Serializable]
public class PlayerInfo 
{
    public int crystals;
    public int level;
}

public class Progress : MonoBehaviour
{
    public PlayerInfo playerInfo;
    public static Progress Instance;

    [SerializeField] TMP_Text playerInfoText;

    // Внешние методы
    [DllImport("__Internal")] // DllImport - их реализация прописана не в с#, а в javascript и оно будет храниться в файле jssleep
    private static extern void SaveExtern(string date);

    [DllImport("__Internal")]
    private static extern void LoadExtern();

    private void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
            LoadExtern();
        }

        else 
        {
            Destroy(gameObject);
        }
    }

    public void Save() 
    {
        string jsonString = JsonUtility.ToJson(playerInfo);

        SaveExtern(jsonString);
    }

    public void SetPlayerInfo(string value) 
    {
        playerInfo = JsonUtility.FromJson<PlayerInfo>(value);
        playerInfoText.text = playerInfo.crystals + "\n" + playerInfo.level;
    }
}
