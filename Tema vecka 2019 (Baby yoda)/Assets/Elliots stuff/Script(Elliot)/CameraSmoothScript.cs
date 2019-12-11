using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmoothScript : MonoBehaviour
{
    public Transform  Player;
    public float SmoothSpeed = 0.125f;

    public Vector3 offset;

    private void Start()
    {
         //   if(Player == null)
     //   {
       //     GameObject temp = GameObject.FindGameObjectsWithTag("Player");
         //   Player = temp.transform;
      //  }
    }
    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 DesPos = Player.position + offset;
        transform.position = Vector3.Lerp(transform.position, DesPos, SmoothSpeed);
    } 
}
