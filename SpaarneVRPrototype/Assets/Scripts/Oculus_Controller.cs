using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oculus_Controller : MonoBehaviour {

    public TeleportComponent teleportComponent;

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
    private bool test = false;
    private GameObject grabbedObject;
    private FixedTeleportSpot currentTeleportSpot;

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
        if (hitObject)
        {
            if (hitObject.GetComponent<FixedTeleportSpot>() && teleportComponent.OnHover(hitObject))
            {
                currentTeleportSpot = hitObject.GetComponent<FixedTeleportSpot>();
                currentTeleportSpot.On();
            } else
            {
                if (currentTeleportSpot) {
                    currentTeleportSpot.Off();
                    currentTeleportSpot = null;
            }
            }
            if (hitObject.GetComponent<InteractableObject>())
            {
                if (OVRInput.Get(OVRInput.Button.Two))
                {
                    //  hitObject.transform.SetParent(controller.transform);
                    if (!controllerJoint && !objectGrabbed)
                    {
                        controllerJoint = controller.AddComponent<FixedJoint>();
                        controllerJoint.breakForce = 1000;
                        objectGrabbed = true;
                        grabbedObject = hitObject;
                    }

                    if (controllerJoint && !test)
                    {
                        controllerJoint.connectedBody = hitObject.GetComponent<Rigidbody>();
                        if (grabbedObject)
                            grabbedObject.GetComponent<Rigidbody>().useGravity = false;
                        test = true;
                    }
                }
                else
                {
                    if (controllerJoint)
                    {
                        controllerJoint.connectedBody = null;
                        objectGrabbed = false;
                        if (grabbedObject)
                            grabbedObject.GetComponent<Rigidbody>().useGravity = true;
                        test = false;
                    }
                    //  hitObject.GetComponent<Rigidbody>().isKinematic = false;
                    //   hitObject.GetComponent<Rigidbody>().detectCollisions = false;
                    objectGrabbed = false;
                    if (grabbedObject)
                        grabbedObject.GetComponent<Rigidbody>().useGravity = true;
                    // grabbedObject = null;
                }
            }

            if (hitObject.GetComponent<FixedTeleportSpot>())
            {
                currentTeleportSpot = hitObject.GetComponent<FixedTeleportSpot>();
                if (OVRInput.GetDown(OVRInput.Button.Two))
                    teleportComponent.TeleportToPosition(currentTeleportSpot);
            }
        }
        //else
        //{
        //    if (currentTeleportSpot)
        //    {
        //        currentTeleportSpot.Off();
        //        currentTeleportSpot = null;
        //    }
        //}
    }

    public void OnJointBreak(float breakForce)
    {
        Debug.Log("Broken Joint");
        if(grabbedObject)
        grabbedObject.GetComponent<Rigidbody>().useGravity = true;
       // objectGrabbed = false;
        grabbedObject = null;
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
            line.enabled = true;
            forwardPos = hit.point;
        }
        else
        {
            //forwardPos = controller.transform.position + controller.transform.forward * 5;
            line.enabled = false;
        }

        line.SetPosition(0, startPos);
        line.SetPosition(1, forwardPos);
    }
}
