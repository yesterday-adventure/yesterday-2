using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public Slider introBGMSlider;
    public AudioSource introBGM;

    public Slider introButtonSoundSlider;
    public AudioSource introButtonSound;

    private void Start()
    {
        if (File.Exists(DataManager.instance.path + "NoSlot"))
        {
            DataManager.instance.NoSlotLoadData();
        }
        introBGMSlider.value = DataManager.instance.nowPlayer.introBGM;
        introBGM.volume = DataManager.instance.nowPlayer.introBGM;

        introButtonSoundSlider.value = DataManager.instance.nowPlayer.introButtonSound;
        introButtonSound.volume = DataManager.instance.nowPlayer.introButtonSound;
    }

    public void IntroBGMVolume(float volume)
    {
        introBGM.volume = volume;
        DataManager.instance.nowPlayer.introBGM = introBGM.volume;
        DataManager.instance.NoSlotSaveData();
    }

    public void IntroButtonSoundVolume(float volume)
    {
        introButtonSound.volume = volume;
        DataManager.instance.nowPlayer.introButtonSound = introButtonSound.volume;
        DataManager.instance.NoSlotSaveData();
    }

    public void ButtonClick()
    {
        introButtonSound.Play();
    }
}
