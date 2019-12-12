using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempEnemy : MonoBehaviour
{
    //Made by Marvin
    public float Health;
    public float Speed;

    public Transform Currency;

    Rigidbody rb;
    
    public float thrust;


    public Transform attackPos;
    public LayerMask whatIsPlayer;
    public float attackRangeX;
    public float attackRangeY;
    public int damage;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        Collider[] playerToDamage = Physics.OverlapBox(attackPos.position, new Vector2(attackRangeX, attackRangeY), Quaternion.identity, whatIsPlayer);
        for (int i = 0; i < playerToDamage.Length; i++)
        {
            playerToDamage[i].GetComponent<PlayerHealth>().TakeDamage(damage, transform.position);
        }



        if (Health <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(int damage, Vector3 playerPos)
    {
        Health -= damage;

        Vector3 difference = transform.position - playerPos;
        difference = difference.normalized * thrust;
        rb.AddForce(difference + new Vector3(0, 2, 0) * thrust, ForceMode.Impulse);
    }

    public void Die()
    {
        Destroy(gameObject);
        Instantiate(Currency, transform.position, Quaternion.identity);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY, 1));
    }
}
