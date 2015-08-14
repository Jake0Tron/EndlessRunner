using UnityEngine;
using System.Collections;

public class EscapeHandler : MonoBehaviour {

    public GameObject pausePanel;
    public bool isPaused;

	// Use this for initialization
	void Start () {
        this.pausePanel.SetActive(false);
	}

    public void Pause()
    {
        // stop motion
        Time.timeScale = 0.0f;
        this.pausePanel.gameObject.SetActive(true);
    }

    public void Unpause()
    {
        Time.timeScale = 1.0f;
        this.pausePanel.gameObject.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused){
                Pause();
            }
            else
            {
                Unpause();
            }
        }
	}
}
