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
    public float FlotingHight;

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
            startLerping();
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
            Pulling();
          
        }
    }

    void Pulling()
    {
        transform.position = lerp(startPos, PointToMoveObjTo.transform.position, TimeStartedLerping, LerpTime);

        if (Vector3.Distance(transform.position, PointToMoveObjTo.transform.position) < 1f)
        {

            transform.position = PointToMoveObjTo.transform.position;

            Pull = false;
            startedLerp = false;
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
            startPos = transform.position;
            GetComponent<Rigidbody>().drag = 1000;
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
       
        if (!startSin)

            transform.position = lerp(startPos, new Vector3(startPos.x,startPos.y + FlotingHight, 0), TimeStartedLerping, LerpTime);
        else
        {
            x += speed * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, HightOfFlot * Mathf.Sin(x) + (startPos.y + FlotingHight));
        }


        if (Vector3.Distance(transform.position, new Vector3( startPos.x, startPos.y + FlotingHight,0)) < .2f)
        {
            startSin = true;
        }

    }

    #endregion

}
