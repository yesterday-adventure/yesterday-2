using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class ServeItem : MonoBehaviour //폭탄이랑 코인에만 들어갈 스크립트, 닿으면 획득하는 거
{
    //새로 짠 코드 안 굴러갈까봐 존나 이상하지만 전에 짜둔 코드 안 지우고 주석해둠,,

    // public List<int> serveItem = new List<int>(); //딕셔너리 안의 개수를 표시하기 위한 리스트
    // public Dictionary<string, int> serveItemList = new Dictionary<string, int>(); //이름과 개수를 표시할 딕셔너리
    // [SerializeField] private List<TextMeshProUGUI> txtList = new List<TextMeshProUGUI>(); //표시할 TMP
    // private string currentItem; //현재 아이템 이름을 받아올 변수



    private void OnEnable()
    {
        // serveItemList.Add("bomp", serveItem[0]);
        // serveItemList.Add("coin", serveItem[1]);
    }
    private void Update()
    {
        // txtList[0].text = serveItem[0].ToString();
        // txtList[1].text = serveItem[1].ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        { //플레이어랑 닿았다면
            GetServeItem();
        }
    }

    private void GetServeItem()
    {
        // currentItem = gameObject.name; //현재 아이템 이름 받아오기
        // foreach (string str in serveItemList.Keys) { //아이템 딕셔너리 key를 반복
        //     if(currentItem == str) { //현재 아이템
        //     이름과 key 값이 같다면
        //         serveItemList[str]++; //key 값의 value 값에 +1을 해준다
        //     }
        // }
        if (gameObject.tag == "Bomb")
        {
            ServeItemManager.Instance.Bomb++;
            DataManager.instance.afterData.bomb++;
            FindObjectOfType<PlayerManager>().nowBombCount++;

            foreach (Vector3 item in DataManager.instance.afterData.dropBomb)
            {
                //Debug.Log(2);
                if (item == transform.position)
                {
                    //Debug.Log(1);
                    DataManager.instance.afterData.dropBomb.RemoveAt(DataManager.instance.afterData.dropBomb.FindIndex(a => a == item));
                    break;
                }
            }
            //Debug.Log(FindObjectOfType<PlayerManager>().nowBombCount);
        } //이름이 폭탄이면 폭탄++
        else
        {
            ServeItemManager.Instance.Gold++;
            DataManager.instance.afterData.goldenCoin++;
            foreach (Vector3 item in DataManager.instance.afterData.dropCoin)
            {
                //Debug.Log(2);
                if (item == transform.position)
                {
                    //Debug.Log(1);
                    //DataManager.instance.afterData.dropCoin.Remove(item);
                    DataManager.instance.afterData.dropCoin.RemoveAt(DataManager.instance.afterData.dropCoin.FindIndex(a => a == item));
                    break;
                }
            }
        } //아니면 코인밖에 없으니까 코인++ ㅎㅎ,,


        Destroy(gameObject); //아이템은 삭제    
    }
}
