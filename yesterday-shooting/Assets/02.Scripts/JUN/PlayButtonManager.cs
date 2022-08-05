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
        player.transform.position = DataManager.instance.nowPlayer.playerPosition;
        cameraP.transform.position = DataManager.instance.nowPlayer.cameraPosition;
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
