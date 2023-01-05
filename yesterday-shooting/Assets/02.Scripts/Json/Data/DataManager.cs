using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    // ���⿡ ������ ������ ��� ���
    public bool playing = false; // �÷����� ����� �ְ� ����Ǿ� �ִ��� �Ǵ�.
    public bool[] roomClear = new bool[45] ;    // 전에 썼던 방 클리어 유뮤 판단하기

    public Vector3 playerPosition = new Vector3(90, 60, 0); //플레이어 포지션
    public float addDamage = 0;
    public int x = 5; // 플레이어가 마지막으로 있던 방의 방 숫자 배열 첫번째
    public int y = 6; // 플레이어가 마지막으로 있던 방의 방 숫자 배열 두번째

    //public int playerDirection = 0; // 플레이어가 마지막으로 있던 방의 위치 숫자로 위, 아래 오른쪽, 왼쪽, 센터
    public Vector3[] roomPos = new Vector3[12];    // 방의 위치 포지션 배열
    public int[] roomNumber = new int[12];  // 방의 방 넘버 배열

    public Vector3 cameraPosition = new Vector3(90, 60, -10);   //카메라 포지션
    
    public int playerHp = 5;
    public int[] mapGrid = new int[24]; //맵 그리드 인트로 들어가게 해서 맵 설정해줌
    //public int[] mapGrid = new int[28]; //맵 그리드 인트로 들어가게 해서 맵 설정해줌
    public int[] mapShopAndBoss = new int[6];   //맵 상점이랑 보스방 위치 저장.

    public string weaponName = null;    //무기 이름 저장 재희야 이거 활용해서 무기 저장해줘
    public string activeItem = null;      //아이템 이름 저장 설아야 이거 써서 엑티브 아이템 저장해줭
    public int activeItemCoolTime = 0;  //아이템 이름 저장 설아야 이거 써서 엑티브 아이템쿨타임 저장해줭.

    public string[] shopItem1 = new string[4];
    public int[] shopPlusPrice1 = new int[4];
    public string[] shopItem2 = new string[4];
    public int[] shopPlusPrice2 = new int[4];

    public int xIndex = 0;
    public int yIndex = 0;
}

public class GameOption
{
    public float BGM = 0.5f;
    public float ButtonClickSound = 0.5f;
}

public class PlayerAfterData
{
    public int goldenCoin = 3;   //이 세개는 돈, 폭탄, 열쇠임.
    public int bomb = 3;
    
    public List<Vector3> dropBomb = new List<Vector3>(); 
    public List<Vector3> dropCoin = new List<Vector3>();
}




#region 2차원 배열

[System.Serializable]
public class MapArr
{
    public Map[] mapArr;
    public MapArr(Map[] _mapArr)
    {
        //Debug.Log("클래스 mapArr");
        mapArr = _mapArr;
    }
}

public class MapArrTwo
{
    public List<MapArr> twoArrList;

    public MapArrTwo(List<MapArr> _twoArr)
    {
        //Debug.Log("클래스 MapArrTwo");
        twoArrList = _twoArr;
    }
}


[System.Serializable]
public class BoolArr
{
    public bool[] boolArr;
    public BoolArr(bool[] _boolArr)
    {
        //Debug.Log("클래스 BoolArr");
        boolArr = _boolArr;
    }
}

public class BoolArrTwo
{
    public BoolArr[] boolTwoArr;

    public BoolArrTwo(BoolArr[] _twoArr)
    {
        //Debug.Log("클래스 BoolArrTwo");
        boolTwoArr = _twoArr;
    }
}
#endregion





public class DataManager : MonoBehaviour
{
    //public MapArrTwo mapArrTw = new MapArrTwo(null);

    public List<MapArr> mapGrid = new List<MapArr>();

    public BoolArr[] twoBoolArr = new BoolArr[] { new BoolArr(new bool[10]), new BoolArr(new bool[11]) };

    public MapArrTwo mapArrTwo;/* = new MapArrTwo(instance.mapGrid);*/

    public BoolArrTwo boolArrTwo;

    public void TwoSave(MapArrTwo mapArrTwo/* = null*/, BoolArrTwo boolArrTwo = null)
    {
        //Debug.Log("데이터 배열 저장");
        mapArrTwo = new MapArrTwo(mapGrid);
        boolArrTwo = new BoolArrTwo(twoBoolArr);

        string data = /*mapArrTwo?.ToString() ?? */JsonUtility.ToJson(mapArrTwo) ?? null;
        //data = boolArrTwo?.ToString() ?? /*JsonUtility.ToJson(mapArrTwo) + */JsonUtility.ToJson(boolArrTwo);
        string dataBool = JsonUtility.ToJson(boolArrTwo) ?? null;

        if (data != null)
        {
            File.WriteAllText(path + "TwoArr" + nowSlot.ToString(), data);
        }
        if (dataBool != null)
        {
            File.WriteAllText(path + "TwoArrBool" + nowSlot.ToString(), dataBool);
        }
    }

    public void TwoLoad()
    {
        //Debug.Log("2차원 배열이 로드되었따!");
        
        string data = File.ReadAllText(path + "TwoArr" + nowSlot.ToString());
        string dataBool = File.ReadAllText(path + "TwoArrBool" + nowSlot.ToString());
        mapArrTwo = JsonUtility.FromJson<MapArrTwo>(data);
        boolArrTwo = JsonUtility.FromJson<BoolArrTwo>(dataBool);

        for (int i = 0; i < twoBoolArr[0].boolArr.Length; i++)
        {
            if (twoBoolArr[0].boolArr[i] == true)
            {
                mapGrid[0].mapArr[i] = FindObjectOfType<Map>();
                //Debug.Log("맵 스크립트를 넣어주는중!");
            }
        }

        for (int i = 0; i < twoBoolArr[1].boolArr.Length; i++)
        {
            if (twoBoolArr[1].boolArr[i] == true)
            {
                mapGrid[1].mapArr[i] = FindObjectOfType<Map>();
                //Debug.Log("맵 스크립트를 넣어주는중!");
            }
        }

        //Debug.Log(mapArrTwo.twoArrList[0].mapArr[5]);
    }




    //�̱���
    public static DataManager instance;

    public PlayerData nowPlayer = new PlayerData();
    public GameOption nowOption = new GameOption();
    public PlayerAfterData afterData = new PlayerAfterData();

    public string path;
    public int nowSlot;

    private void Awake()
    {
        #region �̱���
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        #endregion

        path = Application.persistentDataPath + "/save";


        //Debug.Log("데이터 배열 저장");
        mapGrid.Add(new MapArr(new Map[10]));
        mapGrid.Add(new MapArr(new Map[11]));

        //BoolArr[] twoBoolArr = new BoolArr[2] { new BoolArr(new bool[10]), new BoolArr(new bool[11]) };
        //BoolArrTwo = new BoolArrTwo(twoBoolArr);
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

    public void SaveAfterData()
    {
        string data = JsonUtility.ToJson(afterData);
        File.WriteAllText(path +"AfterData" + nowSlot.ToString(), data);
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

    public void LoadAfterData()
    {
        string data = File.ReadAllText(path + "AfterData" + nowSlot.ToString());
        afterData = JsonUtility.FromJson<PlayerAfterData>(data);
    }

    public void DataClear()
    {
        nowSlot = -1;
        nowPlayer = new PlayerData();
        afterData = new PlayerAfterData();
    }
}