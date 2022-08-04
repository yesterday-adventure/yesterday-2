using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerData
{
    // ���⿡ ������ ������ ��� ���
    public bool playing = false; // �÷����� ����� �ְ� ����Ǿ� �ִ��� �Ǵ�.
    public float introBGM = 0.5f;
    public float introButtonSound = 0.5f;
    public bool[] roomClear = new bool[14];
    public Vector3 playerPosition = new Vector3(0, 0, 0);
}

public class DataManager : MonoBehaviour
{
    //�̱���
    public static DataManager instance;

    public PlayerData nowPlayer = new PlayerData();

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

    public void NoSlotSaveData()
    {
        string data = JsonUtility.ToJson(nowPlayer);
        File.WriteAllText(path + "NoSlot", data);
    }

    public void LoadData()
    {
        string data = File.ReadAllText(path + nowSlot.ToString());
        nowPlayer = JsonUtility.FromJson<PlayerData>(data);
    }

    public void NoSlotLoadData()
    {
        string data = File.ReadAllText(path + "NoSlot");
        nowPlayer = JsonUtility.FromJson<PlayerData>(data);
    }

    public void DataClear()
    {
        nowSlot = -1;
        nowPlayer = new PlayerData();
    }
}
