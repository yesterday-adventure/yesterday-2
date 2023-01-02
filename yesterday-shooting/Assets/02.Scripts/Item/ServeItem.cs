using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ServeItem : MonoBehaviour
{
    public List<int> serveItem = new List<int>(); //딕셔너리 안의 개수를 표시하기 위한 리스트

    public Dictionary<string, int> serveItemList = new Dictionary<string, int>(); //이름과 개수를 표시할 딕셔너리

    [SerializeField] private List<TextMeshProUGUI> txtList = new List<TextMeshProUGUI>(); //표시할 TMP

    private string currentItem; //현재 아이템 이름을 받아올 변수


    private void Awake() {
        serveItemList.Add("bomp", serveItem[0]);
        serveItemList.Add("coin", serveItem[1]);
        serveItemList.Add("key", serveItem[2]);
    }
    private void Update() {
        txtList[0].text = serveItem[0].ToString();
        txtList[1].text = serveItem[1].ToString();
        txtList[2].text = serveItem[2].ToString();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")){ //플레이어랑 닿았다면
            GetServeItem();
        }
    }

    private void GetServeItem() {
        currentItem = gameObject.name; //현재 아이템 이름 받아오기
        foreach (string str in serveItemList.Keys) { //아이템 딕셔너리 key를 반복
            if(currentItem == str) { //현재 아이템 이름과 key 값이 같다면
            serveItemList[str]++; //key 값의 value 값에 +1을 해준다
        }
    }
        Destroy(gameObject); //아이템은 삭제
    }
}
