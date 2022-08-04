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
        player.transform.position = DataManager.instance.nowPlayer.playerPosition;
    }

    public void OnClickExit()
    {
        DataManager.instance.nowPlayer.playerPosition = transform.position;
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
