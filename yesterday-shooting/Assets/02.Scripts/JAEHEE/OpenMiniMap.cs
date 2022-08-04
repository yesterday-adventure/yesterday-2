using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMiniMap : MonoBehaviour
{
    [SerializeField] GameObject map;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (map.activeSelf == false)
                map.SetActive(true);
            else
                map.SetActive(false);
        }
    }
}
