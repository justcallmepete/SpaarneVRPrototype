using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour {

    private Rigidbody rb;
    public bool hasLeftZone = false;

    private FixedJoint joint;

   private Oculus_Controller controller;

    private void Start()
    {
    }

    public void Select(Oculus_Controller contr)
    {
        // play animation?
        Debug.Log("selected");
        if (contr.selectedObj != this)
        {
            // on selection of obj do:
            contr.selectedObj = this;
            // outline on?
        }
    }

    public void Deselect()
    {
    // outline off?
    }


}
