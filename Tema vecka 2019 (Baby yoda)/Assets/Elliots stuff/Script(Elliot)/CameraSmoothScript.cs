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
    bool isYoda;
    bool swichstuff;

    public Vector3 offset;

    private void Start()
    {
        //   if(Player == null)
        //   {
        //     GameObject temp = GameObject.FindGameObjectsWithTag("Player");
        //   Player = temp.transform;
        //  }
        swichstuff = true;
        active = Player.position;
        isYoda = false;
    }
    // Update is called once per frame
    private void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.T) && swichstuff)
        {
            isYoda = !isYoda;
            swichstuff = !swichstuff;
        }

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

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);

        swichstuff = true;

    }
}
