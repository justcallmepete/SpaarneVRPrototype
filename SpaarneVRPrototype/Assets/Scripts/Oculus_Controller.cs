using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oculus_Controller : MonoBehaviour {
	
    public TeleportComponent teleportComponent;
    public OVRInput.Controller OVRcontroller;

    [SerializeField]
    private GameObject controller;
    [SerializeField]   
    private OVRInput.Button teleportButton;
    [SerializeField]
    private OVRInput.Button selectButton;

    private RaycastHit hit;
    private Vector3 startPos;
    private Vector3 forwardPos;
    private GameObject hitObject;

    public GameObject LineTarget;
    public GameObject FollowLineTarget;
    public GameObject LineTargetFollowUp;
    public Material LineTargetM;
    public Material LineTargetFollowUpM;

    private void Update()
    {
        ControllerRaycast();
		teleportComponent.UpdateComponent(hitObject);
        HandleInput();
    }

    public void HandleInput()
    {
		if (OVRInput.Get(teleportButton))
            teleportComponent.TeleportToPosition();
    }

    private void ControllerRaycast()
    {
        Ray r = new Ray(controller.transform.position, controller.transform.forward);
        forwardPos = startPos + controller.transform.forward * 10;
        if (Physics.Raycast(r, out hit))
        {
            LineTarget.SetActive(true);
            LineTargetFollowUp.SetActive(true);
            FollowLineTarget.transform.position = new Vector3(hit.point.x, hit.point.y + 10, hit.point.z);
            if (hit.transform.tag == "Teleport")
            {
                LineTarget.transform.LookAt(FollowLineTarget.transform);
                LineTargetFollowUp.transform.localScale = new Vector3(LineTargetFollowUp.transform.localScale.x, 35f, LineTargetFollowUp.transform.localScale.z);
                LineTargetM.color = Color.green;
                LineTargetFollowUpM.color = Color.green;
            }
            else
            {
                LineTarget.transform.LookAt(controller.transform);
                LineTargetFollowUp.transform.localScale = new Vector3(LineTargetFollowUp.transform.localScale.x, 22f + ((Vector3.Magnitude(hit.point - controller.transform.position))* 3f ), LineTargetFollowUp.transform.localScale.z);
                LineTargetM.color = Color.white;
                LineTargetFollowUpM.color = Color.white;
            }
            hitObject = hit.transform.gameObject;
            LineTarget.transform.position = hit.point;
            float scale = 0.03f + (0.003f * Vector3.Magnitude(hit.point - controller.transform.position));
            LineTarget.transform.localScale = new Vector3(scale, scale, scale);
          //  LineTargetFollowUp.transform.position = new Vector3(0, 0, 2);
            } else
            {
            hitObject = null;
            LineTarget.SetActive(false);
            LineTargetFollowUp.SetActive(false);
            }
    }
}
