﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitching : MonoBehaviour
{
    public GameObject YodaBaby;
    public GameObject MandoMan;
    public GameObject YodaCribPoint;
    public GameObject MandoCribPoint;

    public GameObject ForceSkit;

    private Vector2 velocity;

    public float SmoothTimeY;
    public float SmoothTimeX;
    bool yodaInCrib = true;
    bool Switchable = true;


    void Start()
    {
        YodaBaby.GetComponentInChildren<PlayerMovement>().enabled = false;
        ForceSkit.SetActive(false);


        MandoMan.GetComponentInChildren<PlayerMovement>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && MandoMan.GetComponentInChildren<PlayerMovement>().enabled && Switchable)
        {
            Switchable = false;
            YodaBaby.GetComponentInChildren<PlayerMovement>().enabled = true;
            YodaBaby.GetComponentInChildren<CustomGravity>().enabled = true;

            MandoMan.GetComponentInChildren<PlayerMovement>().enabled = false;
            MandoMan.GetComponentInChildren<CustomGravity>().enabled = false;
            MandoMan.GetComponentInChildren<DashMove>().enabled = false;
            ForceSkit.SetActive(true);
            CameraSmoothScript.isYoda = true;
            yodaInCrib = false;
            StartCoroutine(Timer());

        }
        else if (Input.GetKeyDown(KeyCode.T) && YodaBaby.GetComponentInChildren<PlayerMovement>().enabled && Switchable)
        {
            Switchable = false;
            MandoMan.GetComponentInChildren<PlayerMovement>().enabled = true;
            MandoMan.GetComponentInChildren<CustomGravity>().enabled = true;

            YodaBaby.GetComponentInChildren<PlayerMovement>().enabled = false;
            ForceSkit.SetActive(false);
            CameraSmoothScript.isYoda = false;
            yodaInCrib = true;
            StartCoroutine(Timer());

        }
        
    }


    private void FixedUpdate()
    {
        if (yodaInCrib)
        {
            YodaBaby.GetComponentInChildren<Animator>().SetBool("Crib",true);
            YodaBaby.GetComponentInChildren<CustomGravity>().enabled = false;
            float posX = Mathf.SmoothDamp(YodaBaby.transform.position.x, YodaCribPoint.transform.position.x, ref velocity.x, SmoothTimeX);
            float posY = Mathf.SmoothDamp(YodaBaby.transform.position.y, YodaCribPoint.transform.position.y, ref velocity.y, SmoothTimeY);
            MandoMan.GetComponentInChildren<Animator>().SetBool("Crib", false);
            MandoMan.GetComponentInChildren<Shooting>().enabled = true;
            YodaBaby.transform.position = new Vector3(posX, posY, YodaBaby.transform.position.z);
        }
        else if (!yodaInCrib)
        {
            MandoMan.GetComponentInChildren<Animator>().SetBool("Crib", true);
            MandoMan.GetComponentInChildren<CustomGravity>().enabled = false;
            float posX = Mathf.SmoothDamp(MandoMan.transform.position.x, MandoCribPoint.transform.position.x, ref velocity.x, SmoothTimeX);
            float posY = Mathf.SmoothDamp(MandoMan.transform.position.y, MandoCribPoint.transform.position.y, ref velocity.y, SmoothTimeY);
            MandoMan.GetComponentInChildren<Shooting>().enabled = false;
            YodaBaby.GetComponentInChildren<Animator>().SetBool("Crib", false);

            MandoMan.transform.position = new Vector3(posX, posY, MandoMan.transform.position.z);
        }
    }


    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);

        Switchable = true;
        
    }
}
