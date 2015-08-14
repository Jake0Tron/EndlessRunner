using UnityEngine;
using System.Collections;

public class DeathBar : MonoBehaviour {

    public PlayerController player;

	// Use this for initialization
	void Start () {
        this.player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}

    void PlayerDead()
    {
        Destroy(this.player);
        Application.LoadLevel(Application.loadedLevel);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            this.player.isDead = true;
            Invoke("PlayerDead", 0.5f);
        }
    }


}
