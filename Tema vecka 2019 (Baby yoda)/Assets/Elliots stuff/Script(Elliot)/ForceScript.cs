using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceScript : MonoBehaviour
{
    public bool force;
    GameObject objtriggerd;

    private void Start()
    {
        force = false;
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {

        if (other.name == "Obj")
        {
            objtriggerd = other.gameObject;
            force = true;

            objtriggerd.gameObject.GetComponentInChildren<ParticleSystem>().Play();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Obj")
        {
            objtriggerd.gameObject.GetComponentInChildren<ParticleSystem>().Stop();
            objtriggerd = null;
            force = false;


        }
    }

    private void Update()
    {
        if (force && objtriggerd != null && Input.GetKeyDown(KeyCode.E))
        {
            objtriggerd.GetComponent<ObjInteractWithForceScript>().TriggerObj();
        }
    }
}
