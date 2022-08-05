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
        //player.transform.position = DataManager.instance.nowPlayer.playerPosition;
        cameraP.transform.position = DataManager.instance.nowPlayer.cameraPosition;
        switch (DataManager.instance.nowPlayer.playerRoom)
        {
            case 0:
                player.transform.position = new Vector3(0, 0, 0);
                break;
            case 1:
                player.transform.position = new Vector3(-10, -9, 0);
                break;
            case 2:
                player.transform.position = new Vector3(0, -6, 0);
                break;
            case 3:
                player.transform.position = new Vector3(10, -10, 0);
                break;
            case 4:
                player.transform.position = new Vector3(-28, -10, 0);
                break;
            case 5:
                player.transform.position = new Vector3(0, -16, 0);
                break;
            case 6:
                player.transform.position = new Vector3(-28, -30, 0);
                break;

        }
    }

    public void OnClickExit()
    {
        DataManager.instance.nowPlayer.playerPosition = player.transform.position;
        DataManager.instance.nowPlayer.cameraPosition = cameraP.transform.position;
        DataManager.instance.SaveData();
        SceneManager.LoadScene("Intro");
        Time.timeScale = 1;
    }

    public void OnClickReturnToGame()
    {
        stopPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
