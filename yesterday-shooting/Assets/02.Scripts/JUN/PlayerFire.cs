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

    GameEffectSoundManager effectSound;

    private void Start()
    {
        effectSound = FindObjectOfType<GameEffectSoundManager>();
        StartCoroutine("Fire");
    }

    IEnumerator Fire()
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                effectSound.PlayerAtteck();
                _spriteRenderer.flipX = false;
                PoolManager.Instance.Pop(weapon, new Vector3(transform.position.x, transform.position.y -0.3f), Quaternion.identity);
                fireDir = FireDir.right;
                yield return new WaitForSeconds(delay);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                effectSound.PlayerAtteck();
                _spriteRenderer.flipX = true;
                PoolManager.Instance.Pop(weapon, new Vector3(transform.position.x, transform.position.y - 0.3f), Quaternion.identity);
                fireDir = FireDir.left;
                yield return new WaitForSeconds(delay);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                effectSound.PlayerAtteck();
                PoolManager.Instance.Pop(weapon, new Vector3(transform.position.x, transform.position.y - 0.3f), Quaternion.identity);
                fireDir = FireDir.up;
                yield return new WaitForSeconds(delay);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                effectSound.PlayerAtteck();
                PoolManager.Instance.Pop(weapon, new Vector3(transform.position.x, transform.position.y - 0.3f), Quaternion.identity);
                fireDir = FireDir.down;
                yield return new WaitForSeconds(delay);
            }
            yield return null;
        }
    }
}
