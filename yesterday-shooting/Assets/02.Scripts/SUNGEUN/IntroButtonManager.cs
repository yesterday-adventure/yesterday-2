using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroButtonManager : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    #region Exit
    public void Exit()
    {
        anim.SetBool("isExit", true);
    }

    public void ExitYes()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void ExitNo()
    {
        anim.SetBool("isExit", false);
    }
    #endregion

    #region Setting
    public void Setting()
    {
        anim.SetLayerWeight(1, 1f);
        anim.SetBool("isSetting", true);
    }

    public void SettingBack()
    {
        anim.SetBool("isSetting", false);
        Invoke("SettingBackk", 0.5f);
    }

    private void SettingBackk()
    {
        anim.SetLayerWeight(1, 0f);
    }
    #endregion

    #region Save
    public void Save()
    {
        anim.SetLayerWeight(2, 1f);
        anim.SetBool("isSave", true);
    }

    public void SaveBack()
    {
        anim.SetBool("isSave", false);
        Invoke("SaveBackk", 0.5f);
    }

    public void SaveBackk()
    {
        anim.SetLayerWeight(1, 0f);
    }
    #endregion

    public void GameStart()
    {
        SceneManager.LoadScene("Play");
    }
}
