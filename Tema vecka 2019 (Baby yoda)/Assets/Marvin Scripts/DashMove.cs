using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMove : MonoBehaviour
{
    public Rigidbody rb;
    public float DashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;

    public float StartDashTimer;
    private float DashTimer;



    void Start()
    {
        dashTime = startDashTime;
    }

    void Update()
    {
        if (direction == 0)
        {
            if (DashTimer <= 0)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey(KeyCode.A))
                {
                    direction = 1;
                    DashTimer = StartDashTimer;
                }
                else if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey(KeyCode.D))
                {
                    direction = 2;
                    DashTimer = StartDashTimer;
                }
            }

        }
        else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
                gameObject.layer = 10;
            }
            else
            {
                dashTime -= Time.deltaTime;
                gameObject.layer = 12;

                if (direction == 1)
                {
                    rb.velocity = Vector2.left * DashSpeed;
                }
                else if (direction == 2)
                {
                    rb.velocity = Vector2.right * DashSpeed;
                }
            }
        }

        DashTimer -= Time.deltaTime;
    }

}