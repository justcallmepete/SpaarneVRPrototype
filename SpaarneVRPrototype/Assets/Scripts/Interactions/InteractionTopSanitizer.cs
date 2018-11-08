using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTopSanitizer : Interaction {
    public SingleVariable Gloves;
    public SingleVariable WashedHands;

    public override void Handle()
    {
        base.Handle();
        if (Gloves.task)
        {
            warningSystem.SetWarning("You cant wash your hands with gloves on.");
        }else
        {
            WashedHands.task = true;
        }
    }
}
