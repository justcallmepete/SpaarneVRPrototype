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

    private FixedTeleportSpot currentTeleportSpot;

    public InteractableObject grabbedObject;

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
            }
            else
            {
                if (currentTeleportSpot)
                {
                    currentTeleportSpot.Off();
                    currentTeleportSpot = null;
                }
            }
            if (hitObject.GetComponent<InteractableObject>())
            {
                if (OVRInput.Get(OVRInput.Button.Two))
                {
                    hitObject.GetComponent<InteractableObject>().OnPickUp(controller.GetComponent<Oculus_Controller>());
                }
                else
                {
                    if (grabbedObject)
                        grabbedObject.Drop();
                }
            }

            if (hitObject.GetComponent<FixedTeleportSpot>() && currentTeleportSpot)
            {
                if (OVRInput.Get(OVRInput.Button.Two))
                    teleportComponent.TeleportToPosition(currentTeleportSpot);
            }
        } else
        {
            if (currentTeleportSpot)
                currentTeleportSpot.Off();
        }
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
            forwardPos = hit.point;

        line.SetPosition(0, startPos);
        line.SetPosition(1, forwardPos);
    }
}
