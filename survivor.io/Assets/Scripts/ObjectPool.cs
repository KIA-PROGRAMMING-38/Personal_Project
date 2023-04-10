using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject[] prefabs;
    private List<GameObject>[] pools;

    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for (int i = 0; i < pools.Length; i++) 
        {
            pools[i] = new List<GameObject>();
        }
    }

    public GameObject Get(int index, Transform trnasform)
    {
        GameObject select = null;

        foreach (GameObject item in pools[index]) 
        {
            if (!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            }

        }
            if (select == null)
            {
                select = Instantiate(prefabs[index], transform);
                pools[index].Add(select);
            }

        return select;
    }

}
