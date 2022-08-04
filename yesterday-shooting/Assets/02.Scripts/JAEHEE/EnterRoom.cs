using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterRoom : MonoBehaviour
{

    private void Update()
    {
        Collider2D hit = Physics2D.OverlapBox(transform.position, new Vector2(17.55f, 9.25f), 0, 1 << 11);
    }


}
