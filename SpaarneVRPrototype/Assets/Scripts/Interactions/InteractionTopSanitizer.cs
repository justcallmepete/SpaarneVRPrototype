using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTopSanitizer : Interaction
{
    public SingleVariable Gloves;
    public SingleVariable WashedHands;

    public override void Start()
    {
        base.Start();
        InteractionTask = "Wash hands";
    }

    public override void Handle()
    {
        base.Handle();
        if (Gloves.task)
        {
            warningSystem.SetWarning("You cant wash your hands with gloves on.");
        }else
        {
            if (WashedHands.task)
            {
                warningSystem.SetWarning("You just washed your hands...");
            }
            else
            {
                WashedHands.task = true;
            }
           
        }
    }
}
