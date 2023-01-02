using System.Collections;
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

    //public GameObject bombBang;

    public GameObject bombRangePrefab;

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

    float time = 0;

    private void Update()
    {

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x > 1f || pos.x < 0f)
        {
            //iTween.MoveTo(gameObject, iTween.Hash("position", -parabolaDestination, "time", time, "easeType", iTween.EaseType.linear, "oncomplete", "BombBang"));
        }
        else
        {
            time = moveTime - (time += Time.deltaTime);
        }
    }

    void BombBang()
    {
        StartCoroutine(Bomb());
    }

    float flashing = 0.5f;
    public Material whiteFlashMat;

    IEnumerator Bomb()
    {
        Material defaultMat = GetComponentInChildren<SpriteRenderer>().material;
        //= gameObject.GetComponent<SpriteRenderer>().material;

        for (int i = 0; i < 5; i++)
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