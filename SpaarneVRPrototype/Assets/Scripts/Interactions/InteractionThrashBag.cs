using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionThrashBag : Interaction {
    public ThrashStatus thrash;
    public SingleVariable Gloves;
    public SingleVariable MouthMask;
    public SingleVariable Apron;
    public void Update()
    {
        if (Gloves.task)
        {
            InteractionTask = "Remove Gloves";
        }
        else if (Apron.task) {
            InteractionTask = "Remove Apron";
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
            }
            else if (InteractionTask == "Remove Mouth Mask")
            {
                MouthMask.task = false;
            }
            else if (InteractionTask == "Remove Apron")
            {
                Apron.task = false;
            }else
            {
                warningSystem.SetWarning("You have nothing to throw away.");
            } 
        }else
        {
            warningSystem.SetWarning("You cant throw stuff in a closed bin.");
        }
    }
}
