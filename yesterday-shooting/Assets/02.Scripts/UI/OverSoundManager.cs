using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverSoundManager : MonoBehaviour
{
    public AudioSource GameOverBGM;
    public AudioSource ButtonClickSound;

    public void OverBGM(){
        GameOverBGM.volume = DataManager.instance.nowOption.BGM;
        GameOverBGM.Play();
    }
    public void ButtonClick()
    {
        ButtonClickSound.Play();
    }
}
