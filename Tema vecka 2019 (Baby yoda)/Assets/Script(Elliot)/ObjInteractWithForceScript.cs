using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjInteractWithForceScript : MonoBehaviour
{

    public bool floating;
    float x;
    public float speed;

    private void Start()
    {
        floating = false;
    }

    private void Update()
    {
        if(floating)
        {
            ObjFloating();
        }

    }

    void ObjFloating()
    {
        x += speed * Time.deltaTime;

        if (x != 0)
            transform.position = new Vector3(transform.position.x, Mathf.Sqrt(Mathf.Sqrt(x)));
        else
            x += 1;

        if (transform.position.y >= 1.7f)
            speed *= -1;
        if (transform.position.y <= 1)
            speed *= -1;
    }
     
    public void CanFloat()
    {
        if (this.tag == "Floating");
        floating = true;
    }
}
