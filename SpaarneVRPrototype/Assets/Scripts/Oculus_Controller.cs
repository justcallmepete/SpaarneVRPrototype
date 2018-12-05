using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class Oculus_Controller : MonoBehaviour
{

    public OVRInput.Controller OVRcontroller;

    [SerializeField]
    private GameObject controller;
    [SerializeField]
    private OVRInput.Button teleportButton;
    private KeyCode teleportButtonKey = KeyCode.Mouse0;

    public AudioClip TeleportTargetSound;
    public AudioSource Sound;
    


    public InteractionManager interactionManager;

    public GameObject playerRig;
    public GameObject MouseRig;

    public GameObject LineTarget;
    public GameObject FollowLineTarget;
    public GameObject LineTargetFollowUp;
    public Material LineTargetM;
    public Material LineTargetFollowUpM;

    public CursorLockMode wantedMode;

    public float range;

    private void Start()
    {
        if (!XRSettings.enabled)
        {
            Debug.Log("No vr");
            playerRig.SetActive(false);
            controller = MouseRig.transform.GetChild(0).gameObject;
            playerRig = MouseRig;
            playerRig.SetActive(true);
            Cursor.lockState = wantedMode;
            Cursor.visible = (CursorLockMode.Locked != wantedMode);
        }
        else
        {
            playerRig.SetActive(true);
            MouseRig.SetActive(false);
        }
    }

    private void Update()
    {
        ControllerRaycast();
        HandleInput();
    }

    public void HandleInput()
    {
        if (OVRInput.GetDown(teleportButton) || Input.GetKeyDown(teleportButtonKey))
        {
            interactionManager.TeleportToPosition(playerRig);
        }
    }

    private void ControllerRaycast()
    {
        RaycastHit hit;
        Ray r = new Ray(controller.transform.position, controller.transform.forward);
      
        if (Physics.Raycast(r, out hit, range))
        {
            //positions and scales the targeting point and line. 

            LineTarget.transform.position += ((hit.point - LineTarget.transform.position) * 10f * Time.deltaTime);
            FollowLineTarget.transform.position = new Vector3(hit.point.x, hit.point.y + 10, hit.point.z);
            float scale = 0.03f + (0.003f * Vector3.Magnitude(hit.point - controller.transform.position));
            LineTarget.transform.localScale = new Vector3(scale, scale, scale);

            LineTarget.SetActive(true);
            LineTargetFollowUp.SetActive(true);
            if(hit.transform.gameObject != interactionManager.LastHighlightedInteraction)
            {
                interactionManager.DisableInteractionCanvas();
            } 
            if (hit.transform.tag != "Teleport" || hit.transform.gameObject == interactionManager.LastTeleportedToPoint)
            {
                if (hit.transform.tag != "Interaction")
                {
                    LineTarget.transform.LookAt(controller.transform);
                    LineTargetFollowUp.transform.localScale = new Vector3(LineTargetFollowUp.transform.localScale.x, 22f + ((Vector3.Magnitude(hit.point - controller.transform.position)) * 3f), LineTargetFollowUp.transform.localScale.z);
                    LineTargetM.color = new Color(Color.black.r, Color.black.g, Color.black.b,0.6f);
                    LineTargetFollowUpM.color = new Color(Color.black.r, Color.black.g, Color.black.b, 0.6f);
                    interactionManager.GetInteractionScript(null);

                }
                else
                {
                    LineTarget.transform.LookAt(controller.transform);
                    LineTargetFollowUp.transform.localScale = new Vector3(LineTargetFollowUp.transform.localScale.x, 22f + ((Vector3.Magnitude(hit.point - controller.transform.position)) * 3f), LineTargetFollowUp.transform.localScale.z);
                    LineTargetM.color = Color.green;
                    LineTargetFollowUpM.color = Color.green;
                    interactionManager.GetInteractionScript(hit.transform.gameObject);
                    LineTarget.transform.localScale = new Vector3(LineTarget.transform.localScale.x + 0.01f, LineTarget.transform.localScale.y + 0.01f, LineTarget.transform.localScale.z + 0.01f);
                }

            }
            else
            {
                interactionManager.LastHighlightedTeleporter = hit.transform.gameObject;
                LineTarget.transform.LookAt(FollowLineTarget.transform);
                LineTargetFollowUp.transform.localScale = new Vector3(LineTargetFollowUp.transform.localScale.x, 35f, LineTargetFollowUp.transform.localScale.z);
                LineTargetM.color = Color.white;
                LineTargetFollowUpM.color = Color.white;
                LineTarget.transform.localScale = new Vector3(LineTarget.transform.localScale.x + 0.01f, LineTarget.transform.localScale.y + 0.01f, LineTarget.transform.localScale.z + 0.01f);

                if (!Sound.isPlaying)
                {
                    Sound.clip = (TeleportTargetSound);
                    //Sound.Play();
                }

                if (interactionManager.LastTeleportedToPoint != hit.transform.gameObject)
                {
                    interactionManager.LastHighlightedTeleporter = hit.transform.gameObject;
                    interactionManager.LastHighlightedTeleporter.GetComponent<FixedTeleportSpot>().OutlineOn();
                }
            }





            //Disabled the highlight of the last highlighted teleporter. 
            if (interactionManager.LastHighlightedTeleporter)
            {
                if (hit.transform.gameObject != interactionManager.LastHighlightedTeleporter)
                {
                    interactionManager.LastHighlightedTeleporter.GetComponent<FixedTeleportSpot>().OutlineOff();
                    interactionManager.LastHighlightedTeleporter = null;
                }
            }
            
        }
        else
        {
            if(interactionManager.LastHighlightedTeleporter)
            {
                interactionManager.LastHighlightedTeleporter.GetComponent<FixedTeleportSpot>().OutlineOff();
            }
            LineTarget.SetActive(false);
            LineTargetFollowUp.SetActive(false);
            LineTarget.transform.GetChild(0).gameObject.SetActive(false);
            
        }
    }



}