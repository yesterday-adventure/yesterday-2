using System.Collections;
using UnityEngine;

public class ITween : MonoBehaviour
{
    // y 축 이동을 담당하는 오브젝트
    public GameObject child;

    // 올라갈 높이
    public float parabolaHeight;

    // 최종 목적지
    public Vector3 parabolaDestination;

    // 이동까지 걸리는 시간
    public float moveTime;

    //public GameObject bombBang;

    public GameObject bombRangePrefab;

    PlayerManager playerManager;

    Vector3 basicPos;
    Vector3 nowPos;

    public void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();

        wallTouch = true;

        parabolaDestination = new Vector3(gameObject.transform.position.x + playerManager.moveLocation, gameObject.transform.position.y - 0.5f, 0);
        basicPos.x = gameObject.transform.position.x;

        // y 축 이동 (위 아래로 움직이기)
        iTween.MoveBy(child, iTween.Hash("y", parabolaHeight, "time", moveTime / 2, "easeType", iTween.EaseType.easeOutQuad));
        iTween.MoveBy(child, iTween.Hash("y", -parabolaHeight, "time", moveTime / 2, "delay", moveTime / 2, "easeType", iTween.EaseType.easeInCubic));

        // x 축 이동 (목적지로 이동하기)
        iTween.MoveTo(gameObject, iTween.Hash("position", parabolaDestination, "time", moveTime, "easeType", iTween.EaseType.linear, "oncomplete", "BombBang"));
    }

    float time = 0;
    public Vector3 moved;
    bool wallTouch = false;

    private void Update()
    {

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if ((pos.x > 1f || pos.x < 0f) && wallTouch)
        {
            iTween.Stop(gameObject);

            moveTime -= time;
            moved = new Vector3(gameObject.transform.position.x - (playerManager.moveLocation - (nowPos.x - basicPos.x)), parabolaDestination.y, 0);

            iTween.MoveTo(gameObject, iTween.Hash("position", moved, "time", moveTime, "easeType", iTween.EaseType.linear, "oncomplete", "BombBang"));

            wallTouch = false;
        }
        else
        {
            if (wallTouch)
            {
                time += Time.deltaTime;
                nowPos.x = gameObject.transform.position.x;
            }
        }
    }

    void BombBang()
    {
        StartCoroutine(Bomb());
    }

    float flashing = 0.3f;
    public Material whiteFlashMat;

    IEnumerator Bomb()
    {
        Material defaultMat = GetComponentInChildren<SpriteRenderer>().material;
        //= gameObject.GetComponent<SpriteRenderer>().material;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                yield return new WaitForSeconds(flashing);
                gameObject.GetComponentInChildren<SpriteRenderer>().material = whiteFlashMat;
                yield return new WaitForSeconds(0.1f);
                gameObject.GetComponentInChildren<SpriteRenderer>().material = defaultMat;
            }
            flashing -= 0.1f;
        }


        /*GameObject bang = Instantiate(bombBang);
        bang.transform.SetParent(this.transform);
        bang.transform.position = this.transform.position;*/

        GameObject bombRange = Instantiate(bombRangePrefab, gameObject.transform.position, Quaternion.identity);
        bombRange.GetComponent<Animator>().SetBool("IsBomb", true);

        Destroy(gameObject);

        yield return null;
    }
}