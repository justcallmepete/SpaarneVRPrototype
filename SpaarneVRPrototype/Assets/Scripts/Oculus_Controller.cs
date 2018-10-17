using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oculus_Controller : MonoBehaviour
{

    public OVRInput.Controller OVRcontroller;

    [SerializeField]
    private GameObject controller;
    [SerializeField]
    private OVRInput.Button teleportButton;
    [SerializeField]
    private OVRInput.Button selectButton;

    private RaycastHit hit;
    private GameObject hitObject;
    public AudioClip TeleportTargetSound;
    public AudioSource Sound;
    

    public  GameObject lastTeleportObject;
    private GameObject lastSelectedTeleport;

    public GameObject playerRig;

    public GameObject LineTarget;
    public GameObject FollowLineTarget;
    public GameObject LineTargetFollowUp;
    public Material LineTargetM;
    public Material LineTargetFollowUpM;

    private void Update()
    {
        ControllerRaycast();
        HandleInput();
    }

    public void HandleInput()
    {
        if (OVRInput.Get(teleportButton))
        {
            TeleportToPosition();
        }
    }

    private void ControllerRaycast()
    {
        Ray r = new Ray(controller.transform.position, controller.transform.forward);
        if (Physics.Raycast(r, out hit))
        {
            LineTarget.SetActive(true);
            LineTargetFollowUp.SetActive(true);
            FollowLineTarget.transform.position = new Vector3(hit.point.x, hit.point.y + 10, hit.point.z);
            if (hit.transform.tag != "Teleport" || hit.transform.gameObject == lastTeleportObject)
            {
                LineTarget.transform.LookAt(controller.transform);
                LineTargetFollowUp.transform.localScale = new Vector3(LineTargetFollowUp.transform.localScale.x, 22f + ((Vector3.Magnitude(hit.point - controller.transform.position)) * 3f), LineTargetFollowUp.transform.localScale.z);
                LineTargetM.color = Color.white;
                LineTargetFollowUpM.color = Color.white;
            }
            else
            {
                    LineTarget.transform.LookAt(FollowLineTarget.transform);
                    LineTargetFollowUp.transform.localScale = new Vector3(LineTargetFollowUp.transform.localScale.x, 35f, LineTargetFollowUp.transform.localScale.z);
                    LineTargetM.color = Color.green;
                    LineTargetFollowUpM.color = Color.green;
                if (!Sound.isPlaying)
                {
                    Sound.PlayOneShot(TeleportTargetSound);
                }

            }
   
            hitObject = hit.transform.gameObject;
            LineTarget.transform.position = hit.point;
            float scale = 0.03f + (0.003f * Vector3.Magnitude(hit.point - controller.transform.position));
            LineTarget.transform.localScale = new Vector3(scale, scale, scale);

        } 
            else
            {
                hitObject = null;
                LineTarget.SetActive(false);
                LineTargetFollowUp.SetActive(false);
            }
        if (lastSelectedTeleport)
        {
            lastSelectedTeleport.GetComponent<FixedTeleportSpot>().Off();
            lastSelectedTeleport = null;
        }

        if (hitObject && hitObject.transform.tag == "Teleport")
        {
            lastSelectedTeleport = hitObject;
            if (hitObject.GetComponent<FixedTeleportSpot>() && hitObject != lastTeleportObject)
            {
                hitObject.GetComponent<FixedTeleportSpot>().On();
            }
        }
    }

    public void TeleportToPosition()
    {
        if (hitObject != lastTeleportObject && hitObject.GetComponent<FixedTeleportSpot>())
        {
            playerRig.transform.position = hitObject.GetComponent<FixedTeleportSpot>().TeleportTransform;
            lastTeleportObject = hitObject;
            hitObject.GetComponent<FixedTeleportSpot>().Off();
        }
    }

}