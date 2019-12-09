using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveInput;
    public float Speed;
    public float JumpForce;

    private Rigidbody rb;

    private bool facingRight = true;
    private bool sDown = false;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float JumpTime;

    public bool isJumping;

    private void Start()
    {

        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        isGrounded = true;

        moveInput = Input.GetAxis("Horizontal") * Speed;
        moveInput *= Time.fixedDeltaTime;
        transform.Translate(moveInput, 0, 0);

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            sDown = true;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            sDown = false;
        }

        if (!sDown)
        {
            if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
            {
                isJumping = true;
                jumpTimeCounter = JumpTime;
                rb.velocity = Vector2.up * JumpForce;
            }

            if (Input.GetKey(KeyCode.Space) && isJumping == true)
            {
                if (jumpTimeCounter > 0)
                {
                    rb.velocity = Vector2.up * JumpForce;
                    jumpTimeCounter -= Time.deltaTime;
                }
                else
                {
                    isJumping = false;
                }

            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                isJumping = false;
            }
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}