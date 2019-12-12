using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeScript : EnemyBaseScript
{
    public float maxSpeed;
    public GameObject SnöBoll;
    bool playerclose;
    public float timer;
    float timeLeft;

    private void Start()
    {
        base.Start();
        if (timer == null)
            timer = 2;

       
        timeLeft = timer;
    }

    public EnemyRangeScript()
    {
        playerclose = false;
        DistanceToFollow = 5;
    }

    public override void Update()
    {


        if(ToClose()&& Timer())
        {
            attack();
        }

        base.Update();
    }

    bool Timer()
    {
        if((timeLeft -= Time.deltaTime )<= 0)
        {
            timeLeft = timer;
            return true;
        }

        return false;
    }

    void attack()
    {

        Vector3 hitPoint = Player.transform.position;

        GameObject g = Instantiate(SnöBoll, transform.position, Quaternion.identity);
        g.GetComponent<SnöBollScript>().PlayerPos(Player.transform.position.x);

    }

    /*
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
    */

}
