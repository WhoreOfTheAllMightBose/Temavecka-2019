using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class valrossmovement : MonoBehaviour
{
    float x, y;
    public float speed;
    public float HightOfFlot;
    Vector3 startPos;
    public float fart;
    
    public float FlotingHight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x += speed * Time.deltaTime;
        
        transform.position = new Vector3(transform.position.x, HightOfFlot * Mathf.Sin(x) + (startPos.y + FlotingHight));
        transform.position += new Vector3(fart * Time.deltaTime, 0, 0);
    }
}

