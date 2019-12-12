using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnöBollScript : MonoBehaviour
{

    float x, y;
    public float speed;
    float playerposx;

    private void Start()
    {
        x = 0;
        y = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(x, y, 0);
    }

    void funktion()
    {
        x += speed * Time.deltaTime;

        y = (x * x) + (x * playerposx);
    }

    public void PlayerPos(float posOfPlayerX)
    {
        playerposx = posOfPlayerX;
    }
}
