using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmoothScript : MonoBehaviour
{
    public Transform Player;
    public Transform Yoda;
    public float SmoothSpeed = 0.125f;

    Vector3 DesPos;
    Vector3 active;
    public static bool isYoda;

    public Vector3 offset;

    private void Start()
    {
        active = Player.position;
        isYoda = false;
    }
    // Update is called once per frame
    private void FixedUpdate()
    {


        transform.position = Vector3.Lerp(transform.position, swappos(isYoda), SmoothSpeed);
    }

    Vector3 swappos(bool isyoda)
    {
        if (isyoda)
            DesPos = Yoda.position + offset;
        else
            DesPos = Player.position + offset;
        return DesPos;
    }

}
