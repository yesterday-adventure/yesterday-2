using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenMiniMap : MonoBehaviour
{
    List<int> minimap = new List<int>();
    [SerializeField] GameObject map;
    private bool checkMiniMap = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (!checkMiniMap)
            {
                map.SetActive(true);
                checkMiniMap = true;
            }
            else if (checkMiniMap)
            {
                map.SetActive(false);
                checkMiniMap = false;
            }
            else
                Debug.Log("Script error : OpenMiniMap");
        }
    }
}
