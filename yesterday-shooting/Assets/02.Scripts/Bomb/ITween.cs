using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class ITween : MonoBehaviour
{
    // y �� �̵��� ����ϴ� ������Ʈ
    public GameObject child;

    // �ö� ����
    public float parabolaHeight;

    // ���� ������
    public Vector3 parabolaDestination;

    // �̵����� �ɸ��� �ð�
    public float moveTime;

    public GameObject bombBang;

    PlayerManager playerManager;

    public void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();

        parabolaDestination = new Vector3(gameObject.transform.position.x + playerManager.moveLocation, gameObject.transform.position.y - 0.5f, 0);

        // y �� �̵� (�� �Ʒ��� �����̱�)
        iTween.MoveBy(child, iTween.Hash("y", parabolaHeight, "time", moveTime / 2, "easeType", iTween.EaseType.easeOutQuad));
        iTween.MoveBy(child, iTween.Hash("y", -parabolaHeight, "time", moveTime / 2, "delay", moveTime / 2, "easeType", iTween.EaseType.easeInCubic));

        // x �� �̵� (�������� �̵��ϱ�)
        iTween.MoveTo(gameObject, iTween.Hash("position", parabolaDestination, "time", moveTime, "easeType", iTween.EaseType.linear, "oncomplete", "BombBang"));
    }

    // ���� ��ġ�� �ǵ�����.
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