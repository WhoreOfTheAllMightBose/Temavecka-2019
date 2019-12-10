using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float MaxHealth = 100;
    public float Health;

    public float thrust;

    public Slider slider;

    public float imuneTime;
    public float startImuneTime;
    private bool imune = false;
    public float RespawnTime;
    private Vector3 spawnPos;

    public Rigidbody2D rb;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    bool Dead = false;

    void Start()
    {
        Health = MaxHealth;
        slider.value = CalculateHealth();
    }

    public void TakeDamage(float amount)
    {
        Health -= amount;


    }

    void Update()
    {
        slider.value = CalculateHealth();



        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }

        if (imune == true && !Dead)
        {
            imuneTime -= Time.deltaTime; ;
            if (imuneTime <= 0)
            {
                imune = false;
            }
        }

        if (Health <= 0 && !Dead)
        {
            Die();
        }

    }

    public void TakeDamage(int damage, Vector3 EnemyPos)
    {
        if (imune == false)
        {
            Health -= damage;

            Vector3 difference = transform.position - EnemyPos;
            difference = difference.normalized * thrust;
            rb.AddForce(difference + new Vector3(0, 8, 0), ForceMode2D.Impulse);

            imuneTime = startImuneTime;
            imune = true;
        }
    }

    public void Die()
    {

        GetComponent<PlayerMovement>().enabled = false;
        //GetComponent<PlayerAttack>().enabled = false;
        GetComponent<DashMove>().enabled = false;

        Dead = true;
        //StartCoroutine(Revive());
    }

    //private IEnumerator Revive()
    //{
    //    yield return new WaitForSeconds(RespawnTime);

    //    spawnPos = GetComponent<RespawnScript>().SpawnPointPos;
    //    transform.position = spawnPos;
    //    GetComponent<PlayerMovement>().enabled = true;
    //    GetComponent<PlayerAttack>().enabled = true;
    //    GetComponent<DashMove>().enabled = true;
    //    health = numOfHearts;
    //    Dead = false;
    //}

    float CalculateHealth()
    {
        return Health / MaxHealth;
    }
}
