using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

    public BoxCollider2D box;
    public BoxCollider2D[] cols;
	// Use this for initialization
	void Start () {
         cols = gameObject.GetComponentsInChildren<BoxCollider2D>();

        // get collider for platform
        for (int i = 0; i < cols.Length; i++)
        {
            if (cols[i].CompareTag("Platform"))
            {
                this.box = cols[i];

            }
        }

	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
