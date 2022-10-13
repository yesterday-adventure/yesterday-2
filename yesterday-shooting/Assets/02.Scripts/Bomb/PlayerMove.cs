using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float bombDelay;
    [SerializeField] GameObject bomb, bombBang;
    public int now_bomb;

    ITween itween;

    public float moveLocation;
    public float upDownMoveLocation;
    public float upDownMoveTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Bomb");
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        transform.position += (new Vector3(x, y, 0)) * speed * Time.deltaTime;
    }

    IEnumerator Bomb()
    {
        while (true)
        {
            if (now_bomb > 0)
            {
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    now_bomb--;
                    GameObject go = Instantiate(bomb);
                    go.transform.position = this.transform.position;
                    moveLocation = Mathf.Abs(moveLocation);

                    yield return new WaitForSeconds(bombDelay);
                }

                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    now_bomb--;
                    GameObject go = Instantiate(bomb);
                    go.transform.position = this.transform.position;
                    if (moveLocation > 0)
                    {
                        moveLocation = -moveLocation;
                    }

                    yield return new WaitForSeconds(bombDelay);
                }

                /*if (Input.GetKey(KeyCode.UpArrow))
                {
                    GameObject go = Instantiate(bomb);
                    go.transform.position = this.transform.position;
                    go.GetComponent<ITween>().enabled = false;
                    iTween.MoveBy(go, iTween.Hash("y", upDownMoveLocation, "time", upDownMoveTime, "easeType", iTween.EaseType.easeInCubic, "oncomplete", "tlqkf"));
                    tlqkf();

                    yield return new WaitForSeconds(bombDelay);
                }*/
                // 위 아래 만들기...?
            }
            yield return null;
        }
    }

    /*void BombBang(GameObject gogo)
    {
        Debug.Log("tlqkfdk");

        GameObject bang = Instantiate(bombBang);
        bang.transform.SetParent(gogo.transform);
        bang.transform.position = gogo.transform.position;

        Destroy(gogo, 1f);
    }

    void tlqkf()
    {
        Debug.Log("tqfdafsfdsfasge");
    }*/
    // 진짜 짜증난다.
}
