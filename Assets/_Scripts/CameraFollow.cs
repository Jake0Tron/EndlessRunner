using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    private Vector2 velocity;

    public float smoothTimeY;
    public float smoothTimeX;

    public PlayerController player;

    public bool cameraIsBound;

    public int offsetXdistance;

    public Vector3 minCamPos;
    public Vector3 maxCamPos;

    // Use this for initialization
    void Start()
    {
        this.player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

        transform.position = new Vector3(posX, posY, transform.position.z);

        if (cameraIsBound)
        {
            transform.position = new Vector3((this.player.rb.position.x + offsetXdistance),Mathf.Clamp(minCamPos.y,maxCamPos.y,transform.position.y),transform.position.z);
        }
    }
}
