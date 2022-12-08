using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public Slider BGMSlider;
    public AudioSource BGM;

    public Slider ButtonClickSoundSlider;
    public AudioSource ButtonClickSound;

    private void Start()
    {
        if (File.Exists(DataManager.instance.path + "Option"))
        {
            DataManager.instance.OptionLoadData();
        }
        //BGMSlider.value = DataManager.instance.nowOption.BGM;
        BGM.volume = DataManager.instance.nowOption.BGM;

        //ButtonClickSoundSlider.value = DataManager.instance.nowOption.ButtonClickSound;
        ButtonClickSound.volume = DataManager.instance.nowOption.ButtonClickSound;
    }

    public void BGMVolume(float volume)
    {
        BGM.volume = volume;
        DataManager.instance.nowOption.BGM = BGM.volume;
        DataManager.instance.OptionSaveData();
    }

    public void ButtonClickSoundVolume(float volume)
    {
        ButtonClickSound.volume = volume;
        DataManager.instance.nowOption.ButtonClickSound = ButtonClickSound.volume;
        DataManager.instance.OptionSaveData();
    }

    public void ButtonClick()
    {
        ButtonClickSound.Play();
    }
}
