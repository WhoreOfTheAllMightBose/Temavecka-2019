using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitching : MonoBehaviour
{
    public GameObject YodaBaby;
    public GameObject MandoMan;
    public GameObject YodaCribPoint;
    public GameObject MandoCribPoint;

    private Vector2 velocity;

    public float SmoothTimeY;
    public float SmoothTimeX;

    bool yodaInCrib = true;


    void Start()
    {
        YodaBaby.GetComponentInChildren<PlayerMovement>().enabled = false;
        

        MandoMan.GetComponentInChildren<PlayerMovement>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && MandoMan.GetComponentInChildren<PlayerMovement>().enabled)
        {
            YodaBaby.GetComponentInChildren<PlayerMovement>().enabled = true;
            YodaBaby.GetComponentInChildren<CustomGravity>().enabled = true;

            MandoMan.GetComponentInChildren<PlayerMovement>().enabled = false;
            MandoMan.GetComponentInChildren<CustomGravity>().enabled = false;

            yodaInCrib = false;

        }
        else if (Input.GetKeyDown(KeyCode.T) && YodaBaby.GetComponentInChildren<PlayerMovement>().enabled)
        {
            MandoMan.GetComponentInChildren<PlayerMovement>().enabled = true;
            MandoMan.GetComponentInChildren<CustomGravity>().enabled = true;

            YodaBaby.GetComponentInChildren<PlayerMovement>().enabled = false;
            

            yodaInCrib = true;
            
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

            YodaBaby.transform.position = new Vector3(posX, posY, YodaBaby.transform.position.z);
        }
    }
}
