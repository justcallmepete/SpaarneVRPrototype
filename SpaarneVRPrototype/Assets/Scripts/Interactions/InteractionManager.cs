using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionManager : MonoBehaviour {
    public GameObject LastHighlightedInteraction;
    public GameObject LastTeleportedToPoint;
    public GameObject LastHighlightedTeleporter;
    public Interaction SelectedInteraction;
    public string LastActivity;

    [SerializeField]
    private OVRInput.Button teleportButton;
    private KeyCode teleportButtonKey = KeyCode.Mouse0;


    public GameObject InteractionCanvas;
    public void Start()
    {
        InteractionCanvas = GameObject.Find("InteractionCanvas");
        InteractionCanvas.SetActive(false);
    }

    public void Update()
    {
        if(SelectedInteraction != null)
        {
            if (SelectedInteraction.InteractionTask == "null")
            {
                InteractionCanvas.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        if (InteractionCanvas.activeInHierarchy == true)
        {
            if (OVRInput.GetDown(teleportButton) && SelectedInteraction.InteractionTask != "null" || Input.GetKeyDown(teleportButtonKey) && SelectedInteraction.InteractionTask != "null")
            {
                LastActivity = SelectedInteraction.InteractionTask;
                SelectedInteraction.Handle();
                InteractionCanvas.transform.GetChild(1).transform.GetComponent<Text>().text = SelectedInteraction.InteractionTask;
                if ( SelectedInteraction.InteractionTask == "null")
                {
                    InteractionCanvas.transform.GetChild(1).gameObject.SetActive(false);
                }
                InteractionCanvas.SetActive(false);
            }

        }
        else
        {
            if (OVRInput.GetDown(teleportButton) && SelectedInteraction != null || Input.GetKeyDown(teleportButtonKey) && SelectedInteraction != null)
            {
                LastHighlightedInteraction = SelectedInteraction.gameObject; 
                
                if (SelectedInteraction.InteractionTask != "null")
                {
                    InteractionCanvas.SetActive(true);
                    InteractionCanvas.transform.GetChild(0).gameObject.SetActive(true);
                    InteractionCanvas.transform.GetChild(1).transform.GetComponent<Text>().text = SelectedInteraction.InteractionTask;

                }
            }
        }
    }

    public void TeleportToPosition(GameObject playerRig)
    {
        if (LastHighlightedTeleporter != LastTeleportedToPoint && LastHighlightedTeleporter != null)
        {
            playerRig.transform.position = new Vector3(LastHighlightedTeleporter.GetComponent<FixedTeleportSpot>().TeleportTransform.x, playerRig.transform.position.y, LastHighlightedTeleporter.GetComponent<FixedTeleportSpot>().TeleportTransform.z);
            LastTeleportedToPoint = LastHighlightedTeleporter;
            LastTeleportedToPoint.GetComponent<FixedTeleportSpot>().OutlineOff();
        }
    }

    public void GetInteractionScript(GameObject interactionHit)
    {
        if (interactionHit != null)
        {
            string interactionScript = "Interaction" + interactionHit.name;
            SelectedInteraction = interactionHit.GetComponent(interactionScript) as Interaction;
        }else
        {
            SelectedInteraction = null;
        }
    }

    public void DisableInteractionCanvas ()
    {
        InteractionCanvas.SetActive(false);
    }
}
