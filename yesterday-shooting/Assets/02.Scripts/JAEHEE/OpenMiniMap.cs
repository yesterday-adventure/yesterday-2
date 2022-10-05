using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenMiniMap : MonoBehaviour
{
    List<int> minimap = new List<int>();
    [SerializeField] GameObject map;
    [SerializeField] RandomMapSpawn randomMapSpawn;
    private bool checkMiniMap = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (!checkMiniMap)
            {
                //foreach(GameObject map in randomMapSpawn.createMiniMapA)
                //{
                //    map.gameObject.s
                //}
            }
            else if(checkMiniMap)
            {
                map.SetActive(false);

            }
            else
                Debug.Log("Script error : OpenMiniMap");
        }
    }
}
