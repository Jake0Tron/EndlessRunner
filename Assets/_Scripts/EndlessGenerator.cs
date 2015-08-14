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
    public Transform maxHeight;
    public Transform minHeight;

    private GameMaster gm;

	// Use this for initialization
	void Start () {
        this.gm = GameObject.FindObjectOfType<GameMaster>();
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "SpawnTrigger"){
            var plat = col.gameObject;
            Transform newPos = plat.transform.parent.Find("SpawnLocation");
            // random y between min and max
            newPos.position = new Vector3(newPos.position.x, (Random.Range(this.minHeight.position.y, this.maxHeight.position.y)), newPos.position.z);

            // spawn platform
            GameObject go = Instantiate(platforms[Random.Range(0,platforms.Length)], newPos.position, Quaternion.identity) as GameObject;
            go.name = "RandPlat";
        }
        if (col.gameObject.name == "SpawnLocation")
        {
            this.gm.playerScore += 1;
            if (gm.playerScore % 5 == 0 && gm.playerScore != 0)
                this.gm.player.moveSpeed += 0.5f;
            Destroy(col.gameObject.transform.parent.gameObject);
        }
    }
}
