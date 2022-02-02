using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    public float jumpForce;

    public bool isGrounded;
    public LayerMask whatIsGround;
    public float checkRadius;
    public Transform groundCheck;

    public float movement;

    void Start()
    {
        rb = rb.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        PlayerAnimation();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        movement = Input.GetAxisRaw("Horizontal");
        if (Mathf.Abs(movement) > 0)
        {
            rb.velocity = new Vector2(movement * moveSpeed * Time.deltaTime, rb.velocity.y); 
        }
    }

    void Jump()
    {
        if (isGrounded)
            {
                rb.velocity = Vector2.up * jumpForce;
            }
    }

    void PlayerAnimation()
    {
        Vector3 characterScale = transform.localScale;
        if (movement < 0)
        {
            characterScale.x = -1;
        }
        if (movement > 0)
        {
            characterScale.x = 1;
        }
        transform.localScale = characterScale;
    }
}
