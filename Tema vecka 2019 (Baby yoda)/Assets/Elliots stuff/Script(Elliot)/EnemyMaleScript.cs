using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaleScript : EnemyBaseScript
{
    public float maxSpeed;
    public int damage;
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

    public void attackClosePlayer()
    {

        float dis = Vector3.Distance(transform.position, Player.transform.position);

        if(dis < 2f)
        {
            Player.GetComponent<PlayerHealth>().TakeDamage(damage, transform.position);
        }

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
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
