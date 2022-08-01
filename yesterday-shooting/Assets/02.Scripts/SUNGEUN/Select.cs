using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class Select : MonoBehaviour
{
    public Button[] slotButton;
    public Button fileDelete, start;

    public Color playing;

    bool[] savefile = new bool[3];

    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            if (File.Exists(DataManager.instance.path + $"{i}"))
            {
                savefile[i] = true;
                DataManager.instance.nowSlot = i;
                DataManager.instance.LoadData();
                slotButton[i].image.color = playing;
            }
            else
            {
                slotButton[i].image.color = Color.white;
            }
        }
        DataManager.instance.DataClear();

        fileDelete.interactable = false;
        start.interactable = false;
    }

    public void slot(int number)
    {
        DataManager.instance.nowSlot = number;

        if (savefile[number])
        {
            DataManager.instance.LoadData();
        }
        else
        {
            slotButton[number].image.color = playing;
        }

        nowSelect(number);
        GoGame();
    }

    public void nowSelect(int number)
    {
        slotButton[number].image.color = Color.blue;

        for (int i = 0; i < slotButton.Length; i++)
        {
            if (slotButton[number] != slotButton[i])
            {
                if (slotButton[i].image.color == Color.blue)
                {
                    slotButton[i].image.color = playing;
                }
            }
        }
    }

    public void GoGame()
    {
        if (!savefile[DataManager.instance.nowSlot])
        {
            DataManager.instance.nowPlayer.playing = true;
            DataManager.instance.SaveData();
        }
        fileDelete.interactable = true;
        start.interactable = true;
    }

    public void FileDelete()
    {
        for (int i = 0; i < slotButton.Length; i++)
        {
            if (slotButton[i].image.color == Color.blue)
            {
                System.IO.File.Delete(DataManager.instance.path + $"{i}");
                slotButton[i].image.color = Color.white;
                fileDelete.interactable = false;
                start.interactable = false;
            }
        }
    }

    public void GameStart()
    {
        SceneManager.LoadScene("Play");
    }
}