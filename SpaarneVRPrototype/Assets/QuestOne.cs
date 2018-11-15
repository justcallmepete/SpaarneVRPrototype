using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestOne : MonoBehaviour
{
    public string LastActivity;
    public InteractionManager interactionManager;
    public WarningSystem warningSystem;
    public PersonPosition PersonP;
    public SingleVariable mouthMask;
    public SingleVariable WashedHands;
    public bool PutOnMaskBeforeEntering = false;
    public bool WasinRoom = false;
    public bool WashedHandsBeforeLeaving = false;
    public bool LeftAfterWashingHands = false;
    public bool RemovedMaskAfterLeaving = false;
    public bool WashedHandsAfterRemovingMask = false;


    public bool warned = false;

    // Use this for initialization
	void Start ()
    {
        warningSystem = GameObject.Find("Manager").GetComponent<WarningSystem>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        LastActivity = interactionManager.LastActivity;
        
        //Check if the person left the room with out washing hands. 
        if(!PersonP.inRoom && WasinRoom && !WashedHandsBeforeLeaving && !warned)
        {
            warningSystem.SetWarning("You left the room with out washing hands. High risk of being infected." , true);
            warned = true;
        }

        if(PersonP.inRoom && !warned)
        {
            WasinRoom = true;
        }

        //Arogene Isolatie
        if (!PutOnMaskBeforeEntering)
        {
            //Check if person is not in the room or tube and puts on mouthmask.
            if (!PersonP.inTube && !PersonP.inRoom && mouthMask.task)
            { 
                PutOnMaskBeforeEntering = true;
            }
            //if the person doesnt have a mask but still enters the room he fails.
            else if (PersonP.inTube && !mouthMask.task || PersonP.inRoom && !mouthMask.task)
            {
                if (!warned)
                {
                    warned = true;
                    warningSystem.SetWarning("You removed or dindt have a mask in the room. High risk of being infected." , true);
                }
            }
        }else if (PutOnMaskBeforeEntering && !PersonP.inRoom && !PersonP.inTube && !WasinRoom)
        {
            if(!mouthMask.task)
            {
                PutOnMaskBeforeEntering = false;
            }
        }
        //if the person removes or doesnt have a mask in the tube or room he fails.
        else if(PersonP.inTube && !mouthMask.task || PersonP.inRoom && !mouthMask.task)
        { 
            if (!warned)
            {
            warned = true;
            warningSystem.SetWarning("You removed or dindt have a mask in the room. High risk of being infected." , true);
            }
        }
        //if at this point the person hasnt failed he should be in the room. 
        else if (!warned && WasinRoom)
        {
            //Before exiting the room Wash Hands
            if (!WashedHandsBeforeLeaving && PersonP.inRoom)
            {
                if (WashedHands.task)
                {
                    WashedHandsBeforeLeaving = true;
                    WashedHands.task = false;
                }
            }
            //if the person does anything else in the room the washed hands status drops.
            else if (LastActivity != "Wash hands" && LastActivity != "Open door" &&  LastActivity != "Close door" && PersonP.inRoom)
            {
                WashedHandsBeforeLeaving = false;
            }else if(WashedHandsBeforeLeaving && !LeftAfterWashingHands)
            {
                if(!PersonP.inRoom && !PersonP.inTube)
                {
                    LeftAfterWashingHands = true; 
                }
            }
            else if (!PersonP.inRoom && !PersonP.inTube && !mouthMask.task && !RemovedMaskAfterLeaving)
            {
                RemovedMaskAfterLeaving = true;
            }else if (!WashedHandsAfterRemovingMask && RemovedMaskAfterLeaving)
            {
                if (WashedHands.task && LastActivity == "Wash hands")
                {
                    WashedHandsAfterRemovingMask = true;
                    WashedHands.task = false;
                }
            }
        }

        //Last step after removing the mask is to wash hands.
        if (WashedHandsAfterRemovingMask)
        {
            warningSystem.SetWarning("Congratulations you finished Arogene Islolation." , true);
        }        
    }
}
