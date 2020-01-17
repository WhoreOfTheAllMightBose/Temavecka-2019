using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BB8AttackScript : MonoBehaviour
{
    GameObject Player;
    public int damage;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player"); // så fienden kommer åt objekt från spelaren
    }

    public void attackClosePlayer()
    {

        float dis = Vector3.Distance(transform.position, Player.transform.position);

        if (dis < 5f)
        {
            Player.GetComponent<PlayerHealth>().TakeDamage(damage, transform.position);
        }

    }

}
