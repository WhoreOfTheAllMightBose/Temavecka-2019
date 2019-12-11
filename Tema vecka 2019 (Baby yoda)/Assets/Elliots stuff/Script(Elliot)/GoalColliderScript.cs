using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalColliderScript : MonoBehaviour
{
    public ParticleSystem ParticalsystemOfTree;
    public TextMesh  TextMesh;
    bool inGoal;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ParticalsystemOfTree.Play();
            TextMesh.text = "Press E";
            inGoal = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ParticalsystemOfTree.Stop();
        TextMesh.text = "Frick you";
        inGoal = false;
    }

    private void Update()
    {
        if(inGoal)
        {
            if (Input.GetKeyDown(KeyCode.E))
                LevelControllerScript.instance.YouWin();
        }
    }
}
