using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjInteractWithForceScript : MonoBehaviour
{

    public bool Floating;
    public float speed;
    public bool Pull;
    public GameObject PointToMoveObjTo;
    public float HightOfFlot;

    public float TimeStartedLerping;
    public float LerpTime;
    bool startedLerp;

    bool startSin;
    float x, y;
    Vector3 startPos;

    private void Start()
    {
        startedLerp = false;
        Floating = false;
        startPos = transform.position;
    }

    private void Update()
    {
        if(Floating)
        {
            objFloating();
        }
        else
        {
            startSin = false;
            x = 0;
            y = 0;
        }

        if(Pull)
        {
            
            startLerping();

            transform.position = lerp(startPos, PointToMoveObjTo.transform.position, TimeStartedLerping, LerpTime);

            if (Vector3.Distance(transform.position, PointToMoveObjTo.transform.position) < 1f)
            {
               
                transform.position = PointToMoveObjTo.transform.position;

                Pull = false;
                startedLerp = false;
            }
        }
    }

    public void TriggerObj()
    {
        if(this.tag == "Pull")
        {
            Pull = true;
        }
        else if (this.tag == "Floating")
        {
            Floating = true;
        }
        else if (this.tag == "Knock back")
        {

        }
    }

    #region pull
    void startLerping()
    {
        if (!startedLerp)
        {
            GetComponent<Rigidbody>().useGravity = false;
            TimeStartedLerping = Time.time;
        }
       

        startedLerp = true;
    }


    Vector3 lerp(Vector3 start, Vector3 end, float TimeStartedLerping, float LerpTime = 1)
   {
        float timeSinceStarted = Time.time - TimeStartedLerping;

        float procentageComplete = timeSinceStarted / LerpTime;

        return Vector3.Lerp(start, end, procentageComplete);
   }

    #endregion
    #region floating obj

    void objFloating()
    {
        x += (speed/2) * Time.deltaTime;

        if (!startSin)

          y =  Vector3.Lerp(transform.position, new Vector3(transform.position.x , startPos.y + speed, 0), x).y;

        if (x > startPos.y + 3)
        {
            startSin = true;
            y = HightOfFlot * Mathf.Cos(x);
        }

            transform.position = new Vector3(transform.position.x, y);
        
    }
     
    #endregion
}
