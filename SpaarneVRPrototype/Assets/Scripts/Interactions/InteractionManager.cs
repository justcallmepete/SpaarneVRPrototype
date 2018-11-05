using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionManager : MonoBehaviour {
    public GameObject LastHighlightedInteraction;
    public GameObject LastTeleportedToPoint;
    public GameObject LastHighlightedTeleporter;
    public Interaction SelectedInteraction;

    [SerializeField]
    private OVRInput.Button teleportButton;
    [SerializeField]
    private OVRInput.Button selectButton;

    private KeyCode teleportButtonKey = KeyCode.Mouse0;
    private KeyCode selectButtonKey = KeyCode.Mouse1;


    public GameObject InteractionCanvas;
    public void Start()
    {
        InteractionCanvas = GameObject.Find("InteractionCanvas");
        InteractionCanvas.SetActive(false);
    }

    public void Update()
    {
        if (InteractionCanvas.activeInHierarchy == true)
        {
            if (OVRInput.GetDown(selectButton) || Input.GetKeyDown(selectButtonKey) && SelectedInteraction.InteractionTaskA != "null")
            {
                SelectedInteraction.Interact();
                InteractionCanvas.transform.GetChild(0).transform.GetChild(0).transform.GetComponent<Text>().text = SelectedInteraction.InteractionTaskA;
                InteractionCanvas.transform.GetChild(1).transform.GetChild(0).transform.GetComponent<Text>().text = SelectedInteraction.InteractionTaskB;
                if (SelectedInteraction.InteractionTaskA == "null")
                {
                    InteractionCanvas.transform.GetChild(0).gameObject.SetActive(false);
                }
            }
            else if (OVRInput.GetDown(teleportButton) || Input.GetKeyDown(teleportButtonKey) && SelectedInteraction.InteractionTaskB != "null")
            {
                SelectedInteraction.Handle();
                InteractionCanvas.transform.GetChild(0).transform.GetChild(0).transform.GetComponent<Text>().text = SelectedInteraction.InteractionTaskA;
                InteractionCanvas.transform.GetChild(1).transform.GetChild(0).transform.GetComponent<Text>().text = SelectedInteraction.InteractionTaskB;
                if ( SelectedInteraction.InteractionTaskB == "null")
                {
                    InteractionCanvas.transform.GetChild(1).gameObject.SetActive(false);
                }
            }

        }
        else
        {
            if (OVRInput.GetDown(teleportButton) || Input.GetKeyDown(teleportButtonKey) && SelectedInteraction != null)
            {
                LastHighlightedInteraction = SelectedInteraction.gameObject; 
                InteractionCanvas.SetActive(true);
                if (SelectedInteraction.InteractionTaskA != "null")
                {
                    InteractionCanvas.transform.GetChild(0).gameObject.SetActive(true);
                    InteractionCanvas.transform.GetChild(0).transform.GetChild(0).transform.GetComponent<Text>().text = SelectedInteraction.InteractionTaskA;
                }else
                {
                    InteractionCanvas.transform.GetChild(0).gameObject.SetActive(false);
                }
                if (SelectedInteraction.InteractionTaskB != "null")
                {
                    InteractionCanvas.transform.GetChild(1).gameObject.SetActive(true);
                    InteractionCanvas.transform.GetChild(1).transform.GetChild(0).transform.GetComponent<Text>().text = SelectedInteraction.InteractionTaskB;

                } else
                {
                    InteractionCanvas.transform.GetChild(1).gameObject.SetActive(false);
                }
            }
        }
    }

    public void TeleportToPosition(GameObject playerRig)
    {
        if (LastHighlightedTeleporter != LastTeleportedToPoint && LastHighlightedTeleporter != null)
        {
            playerRig.transform.position = LastHighlightedTeleporter.GetComponent<FixedTeleportSpot>().TeleportTransform;
            LastTeleportedToPoint = LastHighlightedTeleporter;
            LastTeleportedToPoint.GetComponent<FixedTeleportSpot>().OutlineOff();
        }
    }

    public void GetInteractionScript(GameObject interactionHit)
    {
        string interactionScript = "Interaction" + interactionHit.name;
        SelectedInteraction = interactionHit.GetComponent(interactionScript) as Interaction;
    }

    public void DisableInteractionCanvas ()
    {
        InteractionCanvas.SetActive(false);
    }
}
