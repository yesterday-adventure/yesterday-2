using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class Select : MonoBehaviour
{
    public static Select instance;

    public Button[] slotButton;
    public Button fileDelete, start;

    public Color playing, fileSelect;

    public bool[] savefile = new bool[3];

    public bool newStart = false;

    public GameObject gameLoad;
    //public Slider gameLoad;

    private void Awake()
    {
        newStart = false;
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
        }
    }

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
                savefile[i] = false;
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

        // ����� �����Ͱ� ���� ��
        if (savefile[number])
        {
            DataManager.instance.LoadData();
        }

        nowSelect(number);
        GoGame();
    }

    public void nowSelect(int number)
    {
        slotButton[number].image.color = fileSelect;

        for (int i = 0; i < slotButton.Length; i++)
        {
            if (slotButton[number] != slotButton[i])
            {
                if (slotButton[i].image.color == fileSelect)
                {
                    if (!savefile[i])
                    {
                        slotButton[i].image.color = Color.white;
                    }
                    else
                    {
                        slotButton[i].image.color = playing;
                    }
                }
            }
        }
    }

    public void GoGame()
    {
        // ����� �����Ͱ� ���� ��
        if (!savefile[DataManager.instance.nowSlot])    // 세이브 파일이 없을 때
        {
            fileDelete.interactable = false;
            DataManager.instance.nowPlayer.playing = true;
            newStart = true;
        }
        else
        {
            newStart = false;
            fileDelete.interactable = true;
        }
        start.interactable = true;
    }

    public void FileDelete()
    {
        for (int i = 0; i < slotButton.Length; i++)
        {
            if (slotButton[i].image.color == fileSelect)
            {
                System.IO.File.Delete(DataManager.instance.path + $"{i}");
                System.IO.File.Delete(DataManager.instance.path + $"TwoArr{i}");
                System.IO.File.Delete(DataManager.instance.path + $"TwoArrBool{i}");
                File.Delete(DataManager.instance.path + $"AfterData{i}");
                savefile[i] = false;
                slotButton[i].image.color = Color.white;
                fileDelete.interactable = false;
                start.interactable = false;
                DataManager.instance.DataClear();
            }
        }
    }

    public void GameStart()
    {
        DataManager.instance.SaveData();

        //StartCoroutine(GameStartRoutine());

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        SceneManager.LoadScene("Play");
    }

    IEnumerator GameStartRoutine()
    {
        gameLoad.SetActive(true);

        AsyncOperation operation = SceneManager.LoadSceneAsync("Play");

        while (!operation.isDone)
        {
            gameLoad.GetComponentInChildren<Slider>().value = operation.progress;
            yield return null;
        }

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Back()
    {
        fileDelete.interactable = false;
        start.interactable = false;

        for (int i = 0; i < slotButton.Length; i++)
        {
                if (slotButton[i].image.color == fileSelect)
                {
                    if (!savefile[i])
                    {
                        slotButton[i].image.color = Color.white;
                    }
                    else
                    {
                        slotButton[i].image.color = playing;
                    }
                }
            
        }
    }
}