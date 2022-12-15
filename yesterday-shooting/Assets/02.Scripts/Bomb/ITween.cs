using System.Collections;
using System.Collections.Generic;
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

    public GameObject bombBang;

    PlayerManager playerManager;

    public void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();

        parabolaDestination = new Vector3(gameObject.transform.position.x + playerManager.moveLocation, gameObject.transform.position.y - 0.5f, 0);

        // y 축 이동 (위 아래로 움직이기)
        iTween.MoveBy(child, iTween.Hash("y", parabolaHeight, "time", moveTime / 2, "easeType", iTween.EaseType.easeOutQuad));
        iTween.MoveBy(child, iTween.Hash("y", -parabolaHeight, "time", moveTime / 2, "delay", moveTime / 2, "easeType", iTween.EaseType.easeInCubic));

        // x 축 이동 (목적지로 이동하기)
        iTween.MoveTo(gameObject, iTween.Hash("position", parabolaDestination, "time", moveTime, "easeType", iTween.EaseType.linear, "oncomplete", "BombBang"));
    }

    // 원래 위치로 되돌린다.
    private void Comeback()
    {
        iTween.MoveTo(gameObject, Vector3.zero, 0);
    }

    void BombBang()
    {
        GameObject bang = Instantiate(bombBang);
        bang.transform.SetParent(this.transform);
        bang.transform.position = this.transform.position;

        Destroy(gameObject, 1f);
    }
}