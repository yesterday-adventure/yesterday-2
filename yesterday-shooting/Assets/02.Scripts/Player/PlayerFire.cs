using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject weapon = null;

    [SerializeField] private GameObject[] weaponArr;
    Dictionary<string, GameObject> weapons = new Dictionary<string, GameObject>();

    public static PlayerFire instance = null;
    public float delay = 0f;

    private bool isChanging = false;

    private SpriteRenderer _spriteRenderer;

    PlayerManager playerManager;

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
        if (!Select.instance.newStart)
        {
            weapon = weapons[DataManager.instance.nowPlayer.weaponName];
        }

        _spriteRenderer = GetComponent<SpriteRenderer>();
        if (instance == null)
        {
            instance = this;
        }

        for (int i = 0; i < weaponArr.Length; i++)
        {
            weapons.Add(weaponArr[i].name, weaponArr[i]);
        }

        delay = weapon.GetComponent<BulletInfo>().AttackDelay;
    }

    GameEffectSoundManager effectSound;

    private void Start()
    {
        effectSound = FindObjectOfType<GameEffectSoundManager>();
        playerManager = GetComponent<PlayerManager>();
        StartCoroutine("Fire");
    }

    IEnumerator Fire()
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                playerManager.rightIsTrue = true;
                effectSound.PlayerAtteck();
                _spriteRenderer.flipX = false;
                PoolManager.Instance.Pop(weapon, new Vector3(transform.position.x, transform.position.y - 0.3f), Quaternion.identity);
                fireDir = FireDir.right;
                yield return new WaitForSeconds(delay);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                playerManager.rightIsTrue = false;
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
        if(collision.CompareTag("LockItem"))
        {
            ShopExchange shopExchange = collision.GetComponent<ShopExchange>();
            if(shopExchange.CanExchange())
            {
                Debug.Log("구매!");
                if(shopExchange.shopItem == ShopItem.weapon)
                    collision.tag = "WeaponItem";
                else if(shopExchange.shopItem == ShopItem.activeItem)
                    collision.tag = "ActiveItem";
                else if(shopExchange.shopItem == ShopItem.potion)
                    collision.tag = "Potion";

                if (collision.transform.parent.name == "Shop1")
                {
                    DataManager.instance.nowPlayer.shopItem1[collision.GetComponent<Item>().myNumber] = null;
                    DataManager.instance.nowPlayer.shopPlusPrice1[collision.GetComponent<Item>().myNumber] = 0;
                }
                else if (collision.transform.parent.name == "Shop2")
                {
                    DataManager.instance.nowPlayer.shopItem2[collision.GetComponent<Item>().myNumber] = null;
                    DataManager.instance.nowPlayer.shopPlusPrice2[collision.GetComponent<Item>().myNumber] = 0;
                }
            }
        }

        if (collision.CompareTag("WeaponItem") && !isChanging && ItemNameAnimation.Instance.IsChanging == false)
        {
            Debug.Log(collision);
            StartCoroutine(ChangeWeapon(collision));
        }
    }

    IEnumerator ChangeWeapon(Collider2D collision)
    {
        //아이템획득 애니매이션?
        isChanging = true;
        string temp = weapon.name;
        weapon = weapons[collision.gameObject.name];
        collision.gameObject.name = temp; 
        BulletInfo bulletInfo = weapon.GetComponent<BulletInfo>();
        ItemNameAnimation.Instance.InitText(bulletInfo.titleTxt,bulletInfo.captionTxt);
        yield return new WaitForSeconds(0.5f);
        delay = bulletInfo.AttackDelay;
        yield return new WaitForSeconds(1f);
        isChanging = false;

        DataManager.instance.nowPlayer.weaponName = weapon.name;
    }
}