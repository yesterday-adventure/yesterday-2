using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject weapon = null;

    [SerializeField] private GameObject[] weaponarr;
    Dictionary<string, GameObject> weapons = new Dictionary<string, GameObject>();

    public static PlayerFire instance = null;
    private float delay = 0f;
    private bool isChanging = false;


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
        if (instance == null)
        {
            instance = this;
        }
        for (int i = 0; i < weaponarr.Length; i++)
        {
            weapons.Add(weaponarr[i].name, weaponarr[i]);
        }

        delay = weapon.GetComponent<BulletInfo>().AttackDelay;
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
                PoolManager.Instance.Pop(weapon, new Vector3(transform.position.x, transform.position.y - 0.3f), Quaternion.identity);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WeaponItem") && !isChanging)
        {
            StartCoroutine(ChangeWeapon(collision));
        }
    }
    IEnumerator ChangeWeapon(Collider2D collision)
    {
        //아이템획득 애니매이션?
        isChanging = true;
        string temp = weapon.name;
        Debug.Log(collision);
        Debug.Log(collision.gameObject);
        Debug.Log(collision.gameObject.name);

        weapon = weapons[collision.gameObject.name];
        collision.gameObject.name = temp;
        yield return new WaitForSeconds(0.5f);
        delay = weapon.GetComponent<BulletInfo>().AttackDelay;
        yield return new WaitForSeconds(1f);
        isChanging = false;
    }
}
