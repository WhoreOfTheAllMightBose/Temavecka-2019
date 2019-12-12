using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseScript : MonoBehaviour
{

    public GameObject[] PrefabDrops; // så man kan öka antalet olika drops

    public GameObject Exclamation; // prefab för utroppstäcken
    public float thrust;
    protected GameObject Player; // komma åt spelarens objekt
    GameObject g = null; // ett gameobjekt som kommer raderas rättså snabbt

    bool facingRight;

    protected bool onTheHunt = false; // ifall finden börjat jaga dig

    protected float dropChance = 0; // chansen att något droppas
    Rigidbody rb; // att fienden ska få en riged body
    public float health; // liv på finden 
    protected Vector3 direction; // directionen
    public int DistanceToFollow; // avstånden innan finden ser dig
    public float StartSpeed; // hastighet
    protected float Speed;

    public virtual void Start()
    {
        Speed = StartSpeed;
        Player = GameObject.FindGameObjectWithTag("Player"); // så fienden kommer åt objekt från spelaren
        rb = gameObject.AddComponent<Rigidbody>(); // för att det skulle se snyggare ut i prefaben

        rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
    }


    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0f)
        {
          //  WhatDrop(); // så att fienden droppar något vid sin död

            Die();
        }
    }

    public void TakeDamage(int damage, Vector3 Playerpos)
    {
            health -= damage;
            Vector3 difference = transform.position - Playerpos;
        if(thrust != null)
            difference = difference.normalized * thrust;

            rb.AddForce(difference + new Vector3(0, 8, 0), ForceMode.Impulse);

        if (health <= 0f)
        {
          //  WhatDrop(); // så att fienden droppar något vid sin död

            Die();
        }

    }



    void Die()
    {
        Destroy(gameObject);
    }

    public virtual void Update()
    {

        hunt(); // all bas funktion för en finde
    }

    #region enemy behov
    /// <summary>
    /// Ifall spelaren är för nära
    /// </summary>
    /// <returns>Ifall spelaren är för nära eller inte</returns>
    public virtual bool ToClose()
    {
        if (GetLeanght() < DistanceToFollow)
        {
            Notise();

            return true;
        }
        else
            return false;

    }

    /// <summary>
    /// Ifall fienden ser spelaren så kommer det upp ett utroppstäcken
    /// </summary>
    void Notise()
    {
        if (onTheHunt) // så att den inte gör ett till utroppstäcken
            return;

        else
        {
            Vector3 temp = GetComponentInParent<Transform>().position;
            g = Instantiate(Exclamation, new Vector3(temp.x - .5f ,temp.y , 0) ,Quaternion.identity);
            Destroy(g, .8f); // så att utroppstäcknet försvinner efter 0.25 sec
        }
    }

    /// <summary>
    /// Jaga spelaren
    /// </summary>
    protected void hunt()
    {
        direction = Vector3.zero; // så att directionen resettas

        if (onTheHunt || ToClose()) // sålänge finden är "on the hunt" så kommer fienden forsätta jaga dig
        {
            if (onTheHunt != true) // så att den inte sätter "onthehunt" till true varje gång den går igenom scriptet
            {
                onTheHunt = true;
                Flip();
                GetComponentInChildren<Animator>().SetFloat("walk", Speed);
            }
               

            direction = GetDir(); // uppdaterar fiendens direktion

            lookat(); // så att fienden kollar på dig

        }

        direction.Normalize();

        transform.position += direction * Speed * Time.deltaTime;
    }
    #endregion

    #region Core
    /// <summary>
    /// Så att fienden kollar på dig
    /// </summary>
    protected void lookat()
    {

        if (GetDir().x <= -1)
        {
            Flip();
        }
    }

    protected void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
    /// <summary>
    /// får fram en direktion för finden om den ska gå till spelaren
    /// </summary>
    /// <returns>en vector3 (directionen)</returns>
    protected Vector3 GetDir()
    {
        Vector3 dir = Player.transform.position - transform.position;
        dir.Normalize();

        return dir;
    }
    /// <summary>
    /// avståndet mellan fienden och spelaren
    /// </summary>
    /// <returns>avståndet mellan spelare och finder</returns>
    float GetLeanght()
    {
        if (Player == null) // ifall jag glömt eller av liknande orsakt skickas inte spelare med så kommer det inte bli error utan jag skickar med ett för stort värde
        {
            print("no player");

            return 100;
        }


        float leanght = Vector3.Distance(Player.transform.position, transform.position);

        return leanght;
    }
    #endregion

    #region Drops
    /// <summary>
    /// om den ska droppa och ifall den ska droppa
    /// </summary>
    void WhatDrop()
    {
        int droprate = Random.Range(0, PrefabDrops.Length);

        if (Droprate() && PrefabDrops.Length > -1)
        {
            Instantiate(PrefabDrops[droprate], transform.position, Quaternion.identity); // skapar en av de x antal random prefabs

            if (dropChance < 80) // så att dropChance inte blir högre än 100 som är maximala droprate
                dropChance++;
        }
    }

    /// <summary>
    /// Kollar ifall fieden ska droppa något vid sin död
    /// </summary>
    /// <returns>Om fienden skulle droppa något</returns>
    bool Droprate()
    {
        int droprate = Random.Range(15, 100);

        if (dropChance < droprate) // om chansen att något ska droppa är lägre än ett random nummer mellan 15 och 100;
        {
            return true;
        }

        return false; // ifall dropchans var större än droprate sp ska det inte skapa dett object
    }
    #endregion
}


