using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class PlayButtonManager : MonoBehaviour
{
    [SerializeField] GameObject stopPanel;
    [SerializeField] GameObject player;
    [SerializeField] GameObject cameraP;

    private void Start()
    {
        cameraP.transform.position = DataManager.instance.nowPlayer.cameraPosition;

        switch (DataManager.instance.nowPlayer.playerRoom)
        {
            case 0:
                player.transform.position = new Vector3(90, 60, 0); // 위로 10 옆으로 18 그리고 스타트 배열은 (5, 6)
                PlayerLocation();
                break;
            case 1:
                if (GameObject.Find("Room1Parent") != null) //이거 복붙이나 메서드 만들거나 룰루랄라
                {
                    GameObject room1 = GameObject.Find("Room1Parent");
                    player.transform.position = room1.transform.position;
                    PlayerLocation();
                }
                //player.transform.position = new Vector3(-10, -10, 0);
                break;
            case 2:
                //player.transform.position = new Vector3(0, -6, 0);
                break;
            case 3:
                //player.transform.position = new Vector3(10, -10, 0);
                break;
            case 4:
                //player.transform.position = new Vector3(28, -10, 0);
                break;
            case 5:
                //player.transform.position = new Vector3(0, -16, 0);
                break;
            case 6:
                //player.transform.position = new Vector3(-28, -30, 0);
                break;
            case 7:
                //player.transform.position = new Vector3(-10, -30, 0);
                break;
                case 8:
                    //player.transform.position = new Vector3(0, -26, 0);
                break;
                case 9:
                    //player.transform.position = new Vector3(10,-30, 0);
                break;
                case 10:
                    //player.transform.position = new Vector3(28, -30, 0);
                break;
                case 11:
                    //player.transform.position = new Vector3(46, -30, 0);
                break;
                case 12:
                    //player.transform.position = new Vector3(18, -36, 0);
                break;
                case 13:
                //player.transform.position = new Vector3(54, -36, 0);
                break;
            case 14:
                //player.transform.position = new Vector3(54, -46, 0);
                break;

        }
    }

    private void PlayerLocation()
    {
        if (DataManager.instance.nowPlayer.playerDirection == 1)
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 3, 0);
        }
        if (DataManager.instance.nowPlayer.playerDirection == 2)
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 3, 0);
        }
        if (DataManager.instance.nowPlayer.playerDirection == 3)
        {
            player.transform.position = new Vector3(player.transform.position.x + 7, player.transform.position.y, 0);
        }
        if (DataManager.instance.nowPlayer.playerDirection == 4)
        {
            player.transform.position = new Vector3(player.transform.position.x - 7, player.transform.position.y, 0);
        }
        if (DataManager.instance.nowPlayer.playerDirection == 5)
        {
            player.transform.position = new Vector3(90, 60, 0);
        }
    }

    public void OnClickExit()
    {
        DataManager.instance.nowPlayer.cameraPosition = cameraP.transform.position;
        DataManager.instance.SaveData();
        //MapArrTwo mapArrTwo = new MapArrTwo(DataManager.instance.mapGrid);
        //DataManager.instance.TwoSave(mapArrTwo);
        SceneManager.LoadScene("Intro");
        Time.timeScale = 1;
    }

    public void OnClickReturnToGame()
    {
        stopPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
