using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeScript : EnemyBaseScript
{
    public float maxSpeed;
    bool a;
    bool playerclose;

    public EnemyRangeScript()
    {
        a = false;
        playerclose = false;
        DistanceToFollow = 5;
    }

    public override void Update()
    {
        if(ToClose())
        {
            reversflip();
            transform.position += GetDir() * -Speed * Time.deltaTime;
        }
        else
        {
            reversflip();
        }
    }

    void reversflip()
    {   
        if(!ToClose() && !playerclose)
        {
            Flip();
            playerclose = true;
        }
        else if(ToClose() && playerclose)
        {
            Flip();
            playerclose = false;
            transform.position += new Vector3(-1.4f, 0, 0);
        }
    }


}
