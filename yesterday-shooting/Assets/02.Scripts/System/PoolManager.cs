using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance = null;
    [SerializeField] List<GameObject> prefabs;
    Dictionary<string, Stack<GameObject>>pools = new Dictionary<string, Stack<GameObject>>();
    
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        foreach(GameObject temp in prefabs)
        {
            Stack<GameObject> pool = new Stack<GameObject>();
            pools.Add(temp.name, pool);
        }
    }

    public GameObject Pop(GameObject prefab, Vector2 position, Quaternion rotation)
    {
        GameObject temp = null;

        if(pools[prefab.name].Count > 0)
        {
            temp = pools[prefab.name].Pop();
        }
        else
        {
            temp = Instantiate(prefab);
            temp.name = temp.name.Replace("(Clone)","");
        }

        temp.transform.position = position;
        temp.transform.rotation = rotation;
        temp.SetActive(true);
        return temp;
    }

    public void Push(GameObject prefab)
    {
        prefab.SetActive(false);
        pools[prefab.name].Push(prefab);
    }
}
