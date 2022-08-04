using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject weapon = null;
    private float delay = 0f;

    private SpriteRenderer _spriteRenderer;

    public enum FireDir : short
    {
        right = 0,
        left = 1,
        down = 2,
        up = 3,
    }
    public FireDir fireDir = FireDir.right;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        delay = 0.7f;
        //weapon = null; // 시작 무기
    }

    private void Start()
    {
        StartCoroutine("Fire");
    }

    IEnumerator Fire()
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                _spriteRenderer.flipX = false;
                PoolManager.Instance.Pop(weapon, transform.position, Quaternion.identity);
                fireDir = FireDir.right;
                yield return new WaitForSeconds(delay);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                _spriteRenderer.flipX = true;
                PoolManager.Instance.Pop(weapon, transform.position, Quaternion.identity);
                fireDir = FireDir.left;
                yield return new WaitForSeconds(delay);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                PoolManager.Instance.Pop(weapon, transform.position, Quaternion.identity);
                fireDir = FireDir.up;
                yield return new WaitForSeconds(delay);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                PoolManager.Instance.Pop(weapon, transform.position, Quaternion.identity);
                fireDir = FireDir.down;
                yield return new WaitForSeconds(delay);
            }
            yield return null;
        }
    }
}
