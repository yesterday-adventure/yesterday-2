using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class PlayerData
{
    // ���⿡ ������ ������ ��� ���
    public bool playing = false; // �÷����� ����� �ְ� ����Ǿ� �ִ��� �Ǵ�.
    public bool[] roomClear = new bool[14] ;    // 전에 썼던 방 클리어 유뮤 판단하기
    public Vector3 playerPosition = new Vector3(90, 60, 0);
    public int playerRoom = 0;  // 플레이어가 마지막으로 있던 방의 방 숫자
    public int playerDirection = 0; // 플레이어가 마지막으로 있던 방의 위치 숫자로 위, 아래 오른쪽, 왼쪽, 센터
    public Vector3[] roomPos = new Vector3[12];    // 방의 위치 포지션 배열
    public int[] roomNumber = new int[12];  // 방의 방 넘버 배열
    public Map[,] mapGrid = null;   // 2차원배열은 저장이 안돼용!
    public Vector3 cameraPosition = new Vector3(90, 60, -10);   //카메라 포지션
    public int playerHp = 5;
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
