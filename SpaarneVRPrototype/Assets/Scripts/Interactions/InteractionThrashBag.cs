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
            InteractionTaskB = "Remove Gloves";
            if (MouthMask.task)
            {
                InteractionTaskA = "Remove Mouth Mask";
            }else
            {
                InteractionTaskA = "null";
            }
        }else if(MouthMask.task)
        {
            InteractionTaskB = "Remove Mouth Mask";
            InteractionTaskA = "null";
        }
        else
        {
            InteractionTaskB = "null";

        }

    }
    public override void Handle()
    {
        base.Handle();
        if (thrash.LidOpen)
        {
            if (InteractionTaskB == "Remove Mouth Mask")
            {
                MouthMask.task = false;
            }
            else if (InteractionTaskB == "Remove Gloves")
            {
                Gloves.task = false;
            }
        }else
        {
            warningSystem.SetWarning("You cant throw stuff in a closed bin.");
        }
    }

    public override void Interact()
    {
        base.Interact();
        if (thrash.LidOpen)
        {
            if (InteractionTaskA == "Remove Mouth Mask")
            {
                MouthMask.task = false;
            }
        }
        else
        {
            warningSystem.SetWarning("You cant throw stuff in a closed bin.");
        }
    }
}
