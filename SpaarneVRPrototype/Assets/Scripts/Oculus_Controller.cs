using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oculus_Controller : MonoBehaviour {
    [SerializeField]
    private GameObject controller;
    [SerializeField]
    private OVRInput.Button Trigger;
    [SerializeField]
    public LineRenderer line;

    private RaycastHit hit;
    private Vector3 startPos;
    private Vector3 forwardPos;

    private GameObject hitObject;

    private FixedJoint controllerJoint;

    private bool objectGrabbed = false;
    private GameObject grabbedObject;

    private void Start()
    {
        controllerJoint = controller.GetComponent<FixedJoint>();
    }


    private void Update()
    {
        ControllerRaycast();
        UpdateLineRenderer();
        HandleInput();
    }

    public void HandleInput()
    {
        if (hitObject && hitObject.GetComponent<InteractableObject>()) {
                if (OVRInput.Get(OVRInput.Button.Two))
            {
                //  hitObject.transform.SetParent(controller.transform);
                if (!controllerJoint && !objectGrabbed)
                {
                    controllerJoint = controller.AddComponent<FixedJoint>();
                    controllerJoint.breakForce = 500;
                    objectGrabbed = true;
                    grabbedObject = hitObject;
                }

                if (controllerJoint)
                {
                    controllerJoint.connectedBody = hitObject.GetComponent<Rigidbody>();
                    hitObject.GetComponent<Rigidbody>().useGravity = false;
                }
            }
            else
            {
                if (controllerJoint)
                {
                    controllerJoint.connectedBody = null;
                    objectGrabbed = false;
                    hitObject.GetComponent<Rigidbody>().useGravity = true;
                }
                //  hitObject.GetComponent<Rigidbody>().isKinematic = false;
                //   hitObject.GetComponent<Rigidbody>().detectCollisions = false;
            }
        }
    }

    public void OnJointBreak(float breakForce)
    {
        Debug.Log("Broken Joint");
        if(grabbedObject)
        grabbedObject.GetComponent<Rigidbody>().useGravity = true;
        objectGrabbed = false;
    }

    private void ControllerRaycast()
    {
        Ray r = new Ray(controller.transform.position, controller.transform.forward);
        forwardPos = startPos + controller.transform.forward * 10;
        if (Physics.Raycast(r, out hit))
        {
            hitObject = hit.transform.gameObject;
        } else
        {
            hitObject = null;
        }
    }

    private void UpdateLineRenderer()
    {
        startPos = controller.transform.position;
        if (hitObject)
        {
            forwardPos = hit.point;
        }
        else
        {
            forwardPos = controller.transform.position + controller.transform.forward;
        }

        line.SetPosition(0, startPos);
        line.SetPosition(1, forwardPos);
    }
}
