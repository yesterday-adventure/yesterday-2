using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroButtonManager : MonoBehaviour
{
    Animator anim;
    Select select;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        select = FindObjectOfType<Select>();
    }

    #region Exit
    public void Exit()
    {
        anim.SetBool("isExit", true);
    }

    public void ExitYes()
    {
        Application.Quit();
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

        Invoke("ColorBack", 0.3f);
    }

    public void ColorBack()
    {
        select.Back();
    }

    public void SaveBackk()
    {
        anim.SetLayerWeight(2, 0f);
    }
    #endregion
}
