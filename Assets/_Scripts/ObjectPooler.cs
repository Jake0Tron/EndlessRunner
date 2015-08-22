using UnityEngine;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour {

    public GameObject pooledObject;
    public int amount;

    List<GameObject> pool;

	// Use this for initialization
	void Start () {
        this.pool = new List<GameObject>();
        // create only the required number of objects
        for (int i = 0; i < amount; i++)
        {
            GameObject go = (GameObject)Instantiate(pooledObject);
            go.SetActive(false);
            pool.Add(go);
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
        GameObject go = (GameObject)Instantiate(pooledObject);
        go.SetActive(false);
        pool.Add(go);
        return go;
    }
}
