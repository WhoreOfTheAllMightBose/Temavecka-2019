using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjInteractWithForceScript : MonoBehaviour
{

    public bool floating;
    bool startSin;
    float x;
    float y;
    public float speed;
    Vector3 startPos;

    private void Start()
    {
        floating = false;
        startPos = transform.position;
    }

    private void Update()
    {
        if(floating)
        {
            ObjFloating();
        }
        else
        {
            startSin = false;
            x = 0;
            y = 0;
        }

    }

    void ObjFloating()
    {
        x += speed * Time.deltaTime;

        if (!startSin)

          y =  Vector3.Lerp(transform.position, new Vector3(transform.position.x , startPos.y + speed, 0), x).y;

        if (x > startPos.y + 3)
        {
            startSin = true;
            y = Mathf.Cos(x);
        }

            transform.position = new Vector3(transform.position.x, y);
        
    }
     
    public void CanFloat()
    {
        if (this.tag == "Floating");
        floating = true;
    }
}
