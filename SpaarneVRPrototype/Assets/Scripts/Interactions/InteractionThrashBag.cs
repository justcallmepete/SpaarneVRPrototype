using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionThrashBag : Interaction {
    public ThrashStatus thrash;
    public SingleVariable Gloves;
    public SingleVariable MouthMask;
    public void Update()
    {
        if (Gloves.task)
        {
            InteractionTask = "Remove Gloves";
        }
        else if (MouthMask.task)
        {
            InteractionTask = "Remove Mouth Mask";
        }
        else
        {
            InteractionTask = "null";

        }

    }
    public override void Handle()
    {
        base.Handle();
        if (thrash.LidOpen)
        {
            if (InteractionTask == "Remove Gloves")
            {
               Gloves.task = false;
                if (MouthMask.task)
                {
                    InteractionTask = "Remove Mouth Mask";
                }
            }
            else if (InteractionTask == "Remove Mouth Mask")
                {
                    MouthMask.task = false;
                } 
        }else
        {
            warningSystem.SetWarning("You cant throw stuff in a closed bin.");
        }
    }
}
