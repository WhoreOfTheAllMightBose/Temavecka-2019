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
        DistanceToFollow = 5;
    }

    public override void Update()
    {
        if (a)
        {
            Speed += 1 * Time.deltaTime;
            if (Speed >= maxSpeed)
                a = false;
        }

        base.Update();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            // insert that player take dmg
            print("moist");
         //   other.gameObject.GetComponent<PlayerHealth>().TakeDamage(3,transform.position);
            Speed = StartSpeed;
            a = true;
        }
    }
}
