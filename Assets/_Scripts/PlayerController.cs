using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;
    public Rigidbody2D rb;
    public bool isDead = false;
    public bool grounded;
    public LayerMask groundLayer;
    public Collider2D col;
    public bool canDblJump;

    private GameMaster gm;

    // Use this for initialization
    void Start()
    {
        this.gm = FindObjectOfType<GameMaster>();
        this.rb = GetComponent<Rigidbody2D>();
        this.col = GetComponent<Collider2D>();
        this.moveSpeed = 5;
    }

    void Jump()
    {
        if (grounded)
        {
            this.canDblJump = this.grounded;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        else if (!grounded && canDblJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce * 0.75f);
            this.canDblJump = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.IsTouchingLayers(col, groundLayer);

        if (!isDead)
        {
            // constantly run
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

            if (grounded)
            {
                this.canDblJump = this.grounded;
            }
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                Jump();
            }
        }
        else
        {
            this.rb.velocity = new Vector2(0f, 0f);
        }
        }
}
