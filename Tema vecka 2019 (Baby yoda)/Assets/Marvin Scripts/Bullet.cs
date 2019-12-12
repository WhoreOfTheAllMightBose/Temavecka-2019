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
        if (hitInfo != null && hitInfo.tag == "Enemy")
        {
            hitInfo.GetComponent<EnemyBaseScript>().TakeDamage(100,transform.position);
        }
        Destroy(gameObject);
    }
}
