using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

// ���� ����� ����� ����� ���������� � javascript ��� ����������
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

    // ������� ������
    [DllImport("__Internal")] // DllImport - �� ���������� ��������� �� � �#, � � javascript � ��� ����� ��������� � ����� jssleep
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
