using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    private Animator anim;
    private float axisX = 0f;
    private float moveSpeed = 7f;
    private float jumpForce = 10f;

    [SerializeField] private LayerMask jumpableGround;
    private enum MovementState { idle, running}
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        axisX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(axisX * moveSpeed, rb.velocity.y);
        

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x,jumpForce);
            
        }

        UpdateAnimationUpdate();
    }
    private void UpdateAnimationUpdate()
    {
        MovementState state;
        if (axisX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (axisX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }
        anim.SetInteger("state", (int)state);
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    public bool canAttack()
    {
        return axisX == 0 && IsGrounded();
    }
}
