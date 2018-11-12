using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestOne : MonoBehaviour
{
    public WarningSystem warningSystem;
    public PersonPosition PersonP;
    public SingleVariable mouthMask;
    public SingleVariable WashedHands;
    public bool WashedHandsBeforeLeaving = false;
    public bool WashedHandsAfterRemovingMask = false;
    public bool PutOnMaskBeforeEntering = false;
    public bool RemovedMaskBeforeLeaving = false;
    public bool WasinRoom = false;
    public bool warned = false;
    // Use this for initialization
	void Start ()
    {
        warningSystem = GameObject.Find("Manager").GetComponent<WarningSystem>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(!PersonP.inRoom && WasinRoom && !WashedHandsBeforeLeaving && !warned)
        {
            warningSystem.SetWarning("You left the room with out washing hands. High risk of being infected." , true);
            warned = true;
        }


        //Arogene Isolatie
        if (!PutOnMaskBeforeEntering)
        {
            if (!PersonP.inTube && !PersonP.inRoom && mouthMask.task)
            {
                //Put on a mask before entering the room. 
                PutOnMaskBeforeEntering = true;
            }
            else if (PersonP.inTube && !mouthMask.task || PersonP.inRoom && !mouthMask.task)
            {
                if (!RemovedMaskBeforeLeaving)
                {
                    RemovedMaskBeforeLeaving = true;
                    warningSystem.SetWarning("You removed or dindt have a mask in the room. High risk of being infected." , true);
                }
            }
        }
        else
        {
            if (PersonP.inTube && !mouthMask.task || PersonP.inRoom && !mouthMask.task)
            { 
                if (!RemovedMaskBeforeLeaving)
                {
                    RemovedMaskBeforeLeaving = true;
                    warningSystem.SetWarning("You removed or dindt have a mask in the room. High risk of being infected." , true);
                }
            }else if (!RemovedMaskBeforeLeaving)
            {
                //Before exiting the room Wash Hands
                if (!WashedHandsBeforeLeaving)
                {
                    if (PersonP.inRoom)
                    {
                            WasinRoom = true;
                        if (WashedHands.task)
                        {
                            WashedHandsBeforeLeaving = true;
                            WashedHands.task = false;
                        }
                    }
                }
                else if(!PersonP.inRoom && !PersonP.inTube && !mouthMask.task)
                {
                    
                    if (!WashedHandsAfterRemovingMask)
                    {
                        if (WashedHands.task)
                        {
                            WashedHandsAfterRemovingMask = true;
                            WashedHands.task = false;
                        }
                    }
                }
            }

            if (WashedHandsAfterRemovingMask)
            {
                warningSystem.SetWarning("Congratulations you finished Arogene Islolation." , true);
            }


        }
        
        if (!WashedHandsBeforeLeaving)
        {
            if (WashedHands.task)
            {
                WashedHandsBeforeLeaving = true;
            }
        }
        
    }
}
