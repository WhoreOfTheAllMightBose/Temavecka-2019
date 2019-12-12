using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulletSpeed;
    public Rigidbody rb;
    public int Damage;

    void Start()
    {
        rb.velocity = transform.right * BulletSpeed;
    }

    private void OnTriggerEnter(Collider hitInfo)
    {
        TempEnemy enemy = hitInfo.GetComponent<TempEnemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(Damage, transform.position);
        }
        Destroy(gameObject);
    }
}
