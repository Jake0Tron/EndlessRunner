using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

    public BoxCollider2D box;
	// Use this for initialization
	void Start () {
        this.box = gameObject.GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
