using UnityEngine;

public class TeleportEffect : MonoBehaviour
{
    [SerializeField] float splashRange;
    [SerializeField] float splashDamage;

    Collider2D hole;
    private void Update()
    {
        hole = Physics2D.OverlapBox(transform.position, new Vector2(1.5f, 1.5f), 0, 1 << 9);
        if (Input.GetKeyDown(KeyCode.Space) && DataManager.instance.nowPlayer.playerHp > 0 && !hole)//
        {
            PlayerManager.instance.player.transform.position = transform.position;
            PoolManager.Instance.Push(gameObject);

            Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, splashRange, Define.monster);

            foreach (Collider2D item in hit)
            {
                item.gameObject.GetComponent<EnemyHp>().OnDamage(() => { }, splashDamage);
                Debug.Log("EMOTIONAL DAMAGE!@");
            }
        }
    }
}
