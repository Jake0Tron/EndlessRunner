using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EndlessGenerator : MonoBehaviour {

    /// <summary>
    /// Max number of platforms on screen at a time
    /// </summary>
    public GameObject[] platforms;

    public bool gameOver;
    public float waitTime;
    public float spawnTime = 0.0f;
    public Transform spawnLoc;

    //distance between the platforms vertically
    public Transform maxHeight;
    public Transform minHeight;
    
    // distance between the platforms horizontally
    public float xDiff;

    private GameMaster gm;

    ObjectPooler pooler;

	// Use this for initialization
	void Start () {
        this.pooler = GameObject.FindObjectOfType<ObjectPooler>();
        this.gm = GameObject.FindObjectOfType<GameMaster>();
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "SpawnTrigger"){
            this.xDiff = Random.Range(-0.75f, 0.75f);
            var plat = col.gameObject;
            Transform newPos = plat.transform.parent.Find("SpawnLocation");
            // random y between min and max
            newPos.position = new Vector3(newPos.position.x + xDiff, (Random.Range(this.minHeight.position.y, this.maxHeight.position.y)), newPos.position.z);

            // Object Pooling
            GameObject go = this.pooler.GetPooledObject();
            go.transform.position = newPos.position;
            go.transform.rotation = newPos.rotation;
            go.SetActive(true);

        }
        if (col.gameObject.name == "SpawnLocation")
        {
            this.gm.playerScore += 1;
            if (gm.playerScore % 5 == 0 && gm.playerScore != 0)
                this.gm.player.moveSpeed += 0.5f;
            // Object Pooling
            col.transform.parent.gameObject.SetActive(false);
            //Destroy(col.gameObject.transform.parent.gameObject);

        }
    }
}
