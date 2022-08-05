using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerData
{
    // ���⿡ ������ ������ ��� ���
    public bool playing = false; // �÷����� ����� �ְ� ����Ǿ� �ִ��� �Ǵ�.
    public bool[] roomClear = new bool[14];
    public Vector3 playerPosition = new Vector3(0, 0, 0);
    public Vector3 cameraPosition = new Vector3(0, 0, -10);
}

public class GameOption
{
    public float BGM = 0.5f;
    public float ButtonClickSound = 0.5f;
}

public class DataManager : MonoBehaviour
{
    //�̱���
    public static DataManager instance;

    public PlayerData nowPlayer = new PlayerData();
    public GameOption nowOption = new GameOption();

    public string path;
    public int nowSlot;

    private void Awake()
    {
        #region �̱���
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        #endregion

        path = Application.persistentDataPath + "/save";
    }

    public void SaveData()
    {
        string data = JsonUtility.ToJson(nowPlayer);
        File.WriteAllText(path + nowSlot.ToString(), data);
    }

    public void OptionSaveData()
    {
        string data = JsonUtility.ToJson(nowOption);
        File.WriteAllText(path + "Option", data);
    }

    public void LoadData()
    {
        string data = File.ReadAllText(path + nowSlot.ToString());
        nowPlayer = JsonUtility.FromJson<PlayerData>(data);
    }

    public void OptionLoadData()
    {
        string data = File.ReadAllText(path + "Option");
        nowOption = JsonUtility.FromJson<GameOption>(data);
    }

    public void DataClear()
    {
        nowSlot = -1;
        nowPlayer = new PlayerData();
    }
}
