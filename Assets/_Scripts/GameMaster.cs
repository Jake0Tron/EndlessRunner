using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameMaster : MonoBehaviour {

    public Text scoreText, speedText;
    public int playerScore;
    public PlayerController player;
    public bool isPaused;

	// Use this for initialization
	void Start () {
        this.player = GameObject.FindObjectOfType<PlayerController>();
        this.playerScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
        this.scoreText.text = "Score: " + this.playerScore;
        this.speedText.text = "Speed : " + this.player.moveSpeed;
	}
}
