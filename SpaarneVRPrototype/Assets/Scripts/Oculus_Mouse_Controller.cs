using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Oculus_Mouse_Controller : MonoBehaviour
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

    public GameObject LineTarget;
    public GameObject FollowLineTarget;
    public GameObject LineTargetFollowUp;
    public Material LineTargetM;
    public Material LineTargetFollowUpM;

    private void Update()
    {
        MouseRaycast();
        HandleInput();
    }

    public void HandleInput()
    {
        if (OVRInput.Get(teleportButton) || Input.GetKeyDown(teleportButtonKey))
        {
            interactionManager.TeleportToPosition(playerRig);
        }
    }

    private void MouseRaycast()
    {
        RaycastHit hit;
        Ray r = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f,0));

        if (Physics.Raycast(r, out hit))
        {

            LineTarget.SetActive(true);
            LineTargetFollowUp.SetActive(true);
            if (hit.transform.gameObject != interactionManager.LastHighlightedInteraction)
            {
                interactionManager.DisableInteractionCanvas();
            }
            if (hit.transform.tag != "Teleport" || hit.transform.gameObject == interactionManager.LastTeleportedToPoint)
            {
                if (hit.transform.tag != "Interaction")
                {
                    LineTarget.transform.LookAt(playerRig.transform);
                    LineTargetFollowUp.transform.localScale = new Vector3(LineTargetFollowUp.transform.localScale.x, 22f + ((Vector3.Magnitude(hit.point - playerRig.transform.position)) * 3f), LineTargetFollowUp.transform.localScale.z);
                    LineTargetM.color = Color.white;
                    LineTargetFollowUpM.color = Color.white;

                }
                else
                {
                    LineTarget.transform.LookAt(playerRig.transform);
                    LineTargetFollowUp.transform.localScale = new Vector3(LineTargetFollowUp.transform.localScale.x, 22f + ((Vector3.Magnitude(hit.point - playerRig.transform.position)) * 3f), LineTargetFollowUp.transform.localScale.z);
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
            LineTarget.transform.position = hit.point;
            FollowLineTarget.transform.position = new Vector3(hit.point.x, hit.point.y + 10, hit.point.z);
            float scale = 0.03f + (0.003f * Vector3.Magnitude(hit.point - playerRig.transform.position));
            LineTarget.transform.localScale = new Vector3(scale, scale, scale);

            //Disabled the highlight of the last highlighted teleporter. 
            if (hit.transform.gameObject != interactionManager.LastHighlightedTeleporter)
            {
                if (interactionManager.LastHighlightedTeleporter)
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