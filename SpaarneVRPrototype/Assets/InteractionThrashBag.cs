using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionThrashBag : Interaction {
    public ThrashStatus thrash;

    private void Update()
    {
        if (thrash.LidOpen)
        {
            InteractionTaskB = "Close Lid";
        }
        else
        {
            InteractionTaskB = "Open Lid";
        }
    }

    public override void Handle()
    {
        base.Handle();
        if (thrash.LidOpen)
        {
            thrash.CloseLid();
            InteractionTaskB = "Open Lid";
        }
        else
        {
            thrash.OpenLid();
            InteractionTaskB = "Close Lid";
        }

    }
}
