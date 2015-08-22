using UnityEngine;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour
{

    public GameObject[] pooledObjects;
    public int totalSinglePlatforms;

    public List<GameObject> pool;

    // Use this for initialization
    void Start()
    {
        this.pool = new List<GameObject>();
        // create only the required number of platform objects[total]
        for (int i = 0; i < pooledObjects.Length; i++)
        {
            // create only the required number of each individual platform
            for (int j = 0; j < totalSinglePlatforms; j++)
            {
                GameObject go = (GameObject)Instantiate(pooledObjects[i]);
                go.SetActive(false);
                pool.Add(go);

            }
        }
    }
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                return pool[i];
            }
        }
        // make a random plat
        GameObject go = (GameObject)Instantiate(pooledObjects[Random.Range(0, pool.Count)]);
        go.SetActive(false);
        pool.Add(go);
        return go;
    }
}
