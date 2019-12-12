using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaleScript : EnemyBaseScript
{
    public float maxSpeed;
    bool a;
    public EnemyMaleScript()
    {
        a = false;
    }

    public override void Update()
    {
        if (a)
        {
            Speed += 1 * Time.deltaTime;
            if (Speed >= maxSpeed)
                a = false;
          //s  GetComponentInChildren<Animator>().SetBool("attack", false);
        }

        base.Update();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            // insert that player take dmg
            //   other.gameObject.GetComponent<PlayerHealth>().TakeDamage(3,transform.position);
          
            Speed = StartSpeed;
            a = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GetComponentInChildren<Animator>().SetBool("attack", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponentInChildren<Animator>().SetBool("attack", false);
        }
    }
}
