using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    static public PlayerManager instance = null;

    private Rigidbody2D rb2D;

    public GameObject player;

    [SerializeField] GameObject stopPanel;
    [SerializeField] private float speed = 5f;

    private void Awake()
    {
        player = this.gameObject;
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(x, y, 0);
        rb2D.velocity = dir.normalized * speed;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            stopPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
