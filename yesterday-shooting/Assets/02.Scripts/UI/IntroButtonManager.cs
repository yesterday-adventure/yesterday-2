using System.Runtime.Versioning;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class IntroButtonManager : MonoBehaviour
{
    Animator anim;
    Select select;
 
    [SerializeField] private RectTransform ExitPanle;
    [SerializeField] private GameObject targetObj;
    [SerializeField] private GameObject targetObj1;


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

    public void ExitT() {
        ExitPanle.transform.DOMove(targetObj.transform.position, 0.5f);
    }

    public void ExitYes()
    {
        Application.Quit();
    }

    public void ExitNo()
    {
        anim.SetBool("isExit", false);
    }

    public void ExitNoT() {
        ExitPanle.transform.DOMove(targetObj1.transform.position, 0.5f);
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

    #region Over
    public void Menu() {
        SceneManager.LoadScene("Intro");
    }

    public void GameT() {
        SceneManager.LoadScene("Play");
    }
    #endregion
}
