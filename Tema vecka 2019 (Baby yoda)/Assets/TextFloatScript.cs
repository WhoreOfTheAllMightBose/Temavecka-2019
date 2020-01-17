using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFloatScript : MonoBehaviour
{
    float x, y;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        x += speed * Time.deltaTime;

        transform.position = new Vector3(transform.position.x,  Mathf.Sin(x) + 3);
    }
}
