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
        rb = gameObject.GetComponent<Rigidbody>();
        rb.useGravity = true;
    }

    public void OnPickUp(Oculus_Controller contr)
    {
        if (contr.grabbedObject) return;

        if(!controller)
        controller = contr;

        if (controller.grabbedObject != gameObject)
            controller.grabbedObject = this;        

        if (!joint)
            joint = gameObject.AddComponent<FixedJoint>();

        if (joint)
        {
            joint.breakForce = 500;
            joint.connectedBody = controller.gameObject.GetComponent<Rigidbody>();
            rb.useGravity = false;
        }
    }

    public void Drop()
    {
        if(joint)
        Destroy(joint);

        controller.grabbedObject = null;
        rb.useGravity = true;

    }

    private void OnJointBreak(float breakForce)
    {
        rb.useGravity = true;
        controller.grabbedObject = null;
    }
}
