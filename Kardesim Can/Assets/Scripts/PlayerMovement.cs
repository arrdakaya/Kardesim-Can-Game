using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    private Animator anim;
    private float axisX = 0f;
    private float moveSpeed = 7f;
    private float jumpForce = 10f;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        axisX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(axisX * moveSpeed, rb.velocity.y);
        

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x,jumpForce);
        }

        UpdateAnimationUpdate();
    }
    private void UpdateAnimationUpdate()
    {
        if (axisX > 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = false;
        }
        else if (axisX < 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("running", false);
        }
    }
}
