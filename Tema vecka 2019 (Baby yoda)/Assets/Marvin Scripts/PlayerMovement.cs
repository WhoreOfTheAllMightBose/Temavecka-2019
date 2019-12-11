using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Boring Variables
    private float moveInput;
    public float Speed;
    public float JumpForce;
    private int doubleJump = 2;

    private Rigidbody rb;

    private bool facingRight = false;
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
        //tar objectets rigidbody
        rb = GetComponent<Rigidbody>();
    }
    //en fixed update för vanliga update uppdaterat för oregelbundet.
    void FixedUpdate()
    {

        if (Physics.CheckSphere(groundCheck.position, checkRadius, whatIsGround))
        {
            isGrounded = true;
            doubleJump = 2;
        }
        else
        {
            isGrounded = false;
        }
            


        //Variabler som tar din input på skrivbordet och gör om det så spelaren rör på sig.
        moveInput = Input.GetAxis("Horizontal") * Speed;
        moveInput *= Time.fixedDeltaTime;
        transform.Translate(moveInput, 0, 0);
        //om spelar inte kollar höger när du rör dig höger kalla på flip functionen. och tvärtom
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }
    // en vanlig update som kollar om s knappen är nere
    private void Update()
    {
        GetComponentInChildren<Animator>().SetFloat("movement", Mathf.Abs(moveInput));
        
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            sDown = true;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            sDown = false;
        }
        // om s inte är nere...
        if (!sDown)
        {// om is grounded är true så hoppar den lite o sånt
            if (doubleJump > 0 && Input.GetKeyDown(KeyCode.Space))
            {
                isJumping = true;
                jumpTimeCounter = JumpTime;
                rb.velocity = Vector2.up * JumpForce;
                doubleJump =- 1;
            }
            // mer gräjer om att den hoppar
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
            // när du hoppat så blir det false så du inte kan hoppa igen
            if (Input.GetKeyUp(KeyCode.Space))
            {
                isJumping = false;
            }
        }
    }
    // en funktion som vänder din spelare.
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}