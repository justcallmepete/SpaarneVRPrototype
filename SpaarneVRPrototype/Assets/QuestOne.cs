using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestOne : MonoBehaviour
{
    public WarningSystem warningSystem;
    public PersonPosition PersonP;
    public SingleVariable mouthMask;
    public SingleVariable WashedHands;
    public bool WashedHandsBeforeLeaving;
    public bool WashedHandsAfterRemovingMask;
    public bool PutOnMaskBeforeEntering;
    public bool RemovedMaskBeforeLeaving;
    // Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Arogene Isolatie
        if (!PutOnMaskBeforeEntering)
        {
            if (!PersonP.inTube && !PersonP.inRoom && mouthMask.task)
            { 
                //Put on a mask before entering the room. 
                PutOnMaskBeforeEntering = true;
            }
        }
        else
        {
            if (PersonP.inTube || PersonP.inRoom && !mouthMask.task)
            { 
                if (!RemovedMaskBeforeLeaving)
                {
                    RemovedMaskBeforeLeaving = true;
                    warningSystem.SetWarning("You removed your mask before leaving the room. High risk of being infected.");
                }
            }else if (!RemovedMaskBeforeLeaving)
            {
                //Before exiting the room Wash Hands
                if (!WashedHandsBeforeLeaving)
                {
                    if (PersonP.inRoom && WashedHands.task)
                    {
                        WashedHandsBeforeLeaving = true;
                        WashedHands.task = false;
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
                warningSystem.SetWarning("Congratulations you finished Arogene Islolation.");
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
