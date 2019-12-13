using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnöBollScript : MonoBehaviour
{

    float x, y;
    public float speed;
    Vector3 playerpos;
    Vector3 enemypos;

    private void Start()
    {
        x = 0;
        y = 0;
    }

    // Update is called once per frame
    void Update()
    {
        funktion();
        transform.position = new Vector3(transform.position.x + x, y, 0);
    }

    Vector3 Getdir()
    {
        Vector3 dir = playerpos- enemypos;

        dir.Normalize();


            return dir;
    }

    void funktion()
    {
        x += speed * Getdir().x * Time.deltaTime;
        //y = (-x * x) + ((enemypos.x * x) + (playerpos.x * x)) + (playerpos.x * enemypos.x);
        y = (-x + enemypos.x) * (x + playerpos.x);
    }
       

    public void PlayerPos(Vector3 posOfPlayer, Vector3 enemyPos)
    {
        playerpos = posOfPlayer;
        enemypos = enemyPos;
    }
}
