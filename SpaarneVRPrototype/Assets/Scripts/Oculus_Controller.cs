using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Oculus_Controller : MonoBehaviour
{

    public OVRInput.Controller OVRcontroller;

    [SerializeField]
    private GameObject controller;
    [SerializeField]
    private OVRInput.Button teleportButton;
    [SerializeField]
    private OVRInput.Button selectButton;

    public AudioClip TeleportTargetSound;
    public AudioSource Sound;
    


    public InteractionManager interactionManager;

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
            interactionManager.TeleportToPosition(playerRig);
        }
    }

    private void ControllerRaycast()
    {
        RaycastHit hit;
        Ray r = new Ray(controller.transform.position, controller.transform.forward);
      
        if (Physics.Raycast(r, out hit))
        {

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
                    LineTargetM.color = Color.white;
                    LineTargetFollowUpM.color = Color.white;

                }
                else
                {
                    LineTarget.transform.LookAt(controller.transform);
                    LineTargetFollowUp.transform.localScale = new Vector3(LineTargetFollowUp.transform.localScale.x, 22f + ((Vector3.Magnitude(hit.point - controller.transform.position)) * 3f), LineTargetFollowUp.transform.localScale.z);
                    LineTargetM.color = Color.red;
                    LineTargetFollowUpM.color = Color.red;
                    interactionManager.GetInteractionScript(hit.transform.gameObject);
                }

            }
            else
            {
                interactionManager.LastHighlightedTeleporter = hit.transform.gameObject;
                LineTarget.transform.LookAt(FollowLineTarget.transform);
                LineTargetFollowUp.transform.localScale = new Vector3(LineTargetFollowUp.transform.localScale.x, 35f, LineTargetFollowUp.transform.localScale.z);
                LineTargetM.color = Color.green;
                LineTargetFollowUpM.color = Color.green;

                if (!Sound.isPlaying)
                {
                    Sound.clip = (TeleportTargetSound);
                    Sound.Play();
                }

                if (interactionManager.LastTeleportedToPoint != hit.transform.gameObject)
                {
                    interactionManager.LastHighlightedTeleporter = hit.transform.gameObject;
                    interactionManager.LastHighlightedTeleporter.GetComponent<FixedTeleportSpot>().OutlineOn();
                }


            }



            //positions and scales the targeting point and line. 
            
                LineTarget.transform.position += ((hit.point - LineTarget.transform.position) * 10f * Time.deltaTime);
          
            FollowLineTarget.transform.position = new Vector3(hit.point.x, hit.point.y + 10, hit.point.z);
            float scale = 0.03f + (0.003f * Vector3.Magnitude(hit.point - controller.transform.position));
            LineTarget.transform.localScale = new Vector3(scale, scale, scale);

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
            LineTarget.SetActive(false);
            LineTargetFollowUp.SetActive(false);
            LineTarget.transform.GetChild(0).gameObject.SetActive(false);

        }
    }



}