using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpjutDoDamageScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            print("moist");
        }
    }
}
