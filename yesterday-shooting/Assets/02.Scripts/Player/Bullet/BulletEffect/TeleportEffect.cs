using UnityEngine;

public class TeleportEffect : MonoBehaviour
{
    [SerializeField] float splashRange;
    [SerializeField] float splashDamage;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && DataManager.instance.nowPlayer.playerHp > 0)
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
