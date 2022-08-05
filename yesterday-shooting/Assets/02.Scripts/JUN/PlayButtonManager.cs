using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class PlayButtonManager : MonoBehaviour
{
    [SerializeField] GameObject stopPanel;
    [SerializeField] GameObject player;

    private void Start()
    {
        switch (DataManager.instance.nowPlayer.playerRoom)
        {
            case 0:
                player.transform.position = new Vector3(0, 0, 0);
                break;
            case 1:
                player.transform.position = new Vector3(-10, -10, 0);
                break;
            case 2:
                player.transform.position = new Vector3(0, -6, 0);
                break;
            case 3:
                player.transform.position = new Vector3(10, -10, 0);
                break;
            case 4:
                player.transform.position = new Vector3(28, -10, 0);
                break;
            case 5:
                player.transform.position = new Vector3(0, -16, 0);
                break;
            case 6:
                player.transform.position = new Vector3(-28, -30, 0);
                break;
            case 7:
                player.transform.position = new Vector3(-10, -30, 0);
                break;
                case 8:
                    player.transform.position = new Vector3(0, -26, 0);
                break;
                case 9:
                    player.transform.position = new Vector3(10,-30, 0);
                break;
                case 10:
                    player.transform.position = new Vector3(28, -30, 0);
                break;
                case 11:
                    player.transform.position = new Vector3(46, -30, 0);
                break;
                case 12:
                    player.transform.position = new Vector3(18, -36, 0);
                break;
                case 13:
                player.transform.position = new Vector3(54, -36, 0);
                break;
            case 14:
                player.transform.position = new Vector3(54, -46, 0);
                break;

        }
    }

    public void OnClickExit()
    {
        SceneManager.LoadScene("Intro");
        Time.timeScale = 1;
    }

    public void OnClickReturnToGame()
    {
        stopPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
