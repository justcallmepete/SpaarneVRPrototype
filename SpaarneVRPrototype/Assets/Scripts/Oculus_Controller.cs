using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oculus_Controller : MonoBehaviour {
	
    public TeleportComponent teleportComponent;
	public ObjectInteractionComponent interactionComponent;
    public OVRInput.Controller OVRcontroller;

	public InteractableObject grabbedObject;
	private bool hasObject = false;

    [SerializeField]
    private GameObject controller;
    [SerializeField]   
    private OVRInput.Button teleportButton;
	[SerializeField]
	private OVRInput.Button selectButton;
    [SerializeField]
    private LineRenderer line;
	private Rigidbody rb;

    private RaycastHit hit;
    private Vector3 startPos;
    private Vector3 forwardPos;
    private GameObject hitObject;

    private void Start()
    {
        rb = controller.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        ControllerRaycast();
		teleportComponent.UpdateComponent(hitObject);
        UpdateLineRenderer();
        HandleInput();
    }

    public void HandleInput()
    {
		if (OVRInput.Get(teleportButton))
            teleportComponent.TeleportToPosition();
       
	   if (OVRInput.Get(selectButton))
		   interactionComponent.SelectItem(hitObject);
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
