using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Dir
{
    up,
    down,
    left,
    right
}
public class DoorOnOff : MonoBehaviour
{

    [SerializeField] GameObject upD;
    [SerializeField] GameObject downD;
    [SerializeField] GameObject leftD;
    [SerializeField] GameObject rightD;

    public Dir dir = Dir.up;

    int x = 5;
    int y = 6;
    [SerializeField] RandomMapSpawn _RMS;

    private void Awake()
    {
        //_RMS = GameObject.Find("SpawnMap/RandomMapSpawn").GetComponent<RandomMapSpawn>();
        //Debug.Log(_RMS);
    }

    private void Start()
    {
        x = 5;
        y = 6;
    }

    private void Update()
    {
        Collider2D hit = Physics2D.OverlapBox(transform.position, new Vector2(17.7f, 9.3f), 0, 1 << 10);
        if (hit == null)
        {
            if (DataManager.instance.nowPlayer.mapGrid[x + 1, y] == null)
            {
                rightD.SetActive(true);
            }
            else
            {
                rightD.SetActive(false);
            }

            if (DataManager.instance.nowPlayer.mapGrid[x - 1, y] == null)
            {
                leftD.SetActive(true);
            }
            else
            {
                leftD.SetActive(false);
            }
            if (DataManager.instance.nowPlayer.mapGrid[x, y + 1] == null)
            {
                upD.SetActive(true);
            }
            else
            {
                upD.SetActive(false);
            }
            if (DataManager.instance.nowPlayer.mapGrid[x, y - 1] == null)
            {
                downD.SetActive(true);
            }
            else
            {
                downD.SetActive(false);
            }
        }
        else
        {
            upD.SetActive(true);
            downD.SetActive(true);
            leftD.SetActive(true);
            rightD.SetActive(true);
        }
    }

    public void changePos()
    {
        if (dir == Dir.up)
            y++;
        else if (dir == Dir.down)
            y--;
        else if (dir == Dir.left)
            x--;
        else if (dir == Dir.right)
            x++;
    }

}
