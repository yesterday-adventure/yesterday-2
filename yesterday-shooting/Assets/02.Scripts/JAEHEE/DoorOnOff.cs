using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DoorOnOff : MonoBehaviour
{
    [SerializeField] GameObject door;

    private void Update()
    {
        Collider2D hit = Physics2D.OverlapBox(transform.position, new Vector2(17.7f, 9.3f), 0, 1 << 10);
        if (hit != null)
        {
            door.SetActive(true);
        }
        else
        {
            door.SetActive(false);
        }
    }

}
