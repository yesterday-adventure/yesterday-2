using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonManager : MonoBehaviour
{
    [SerializeField] GameObject stopPanel;
    public void OnClickExit()
    {
        SceneManager.LoadScene("Intro");
        Time.timeScale = 1;
        //여기다가 데이터 저장
    }
    public void OnClickReturnToGame()
    {
        stopPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
