using UnityEngine;

public class Stage1_1BossAttackRange : MonoBehaviour
{
    [SerializeField] GameObject rangeObj;
    SpriteRenderer rangeViewer;
    Collider2D rangeCollider;

    Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        rangeViewer = rangeObj.GetComponent<SpriteRenderer>();
        rangeViewer.enabled = false;
        rangeCollider = rangeObj.GetComponent<Collider2D>();
    }

    public void RangeOn()
    {
        rangeViewer.enabled = true;
    }
    public void RangeOff()
    {
        rangeViewer.enabled = false;
        rangeCollider.enabled = true;
    }
    public void EndOfAttack()
    {
        rangeCollider.enabled = false;
        _animator.SetBool("Attack", false);
    }

    public void Die()
    {
        Destroy(gameObject, 0.3f);
    }
}
