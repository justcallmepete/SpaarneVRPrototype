using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionThrashLid : Interaction {
    public ThrashStatus thrash;

        private void Update()
    {
        if (thrash.LidOpen)
        {
            InteractionTask = "Close Lid";
        }
        else
        {
            InteractionTask = "Open Lid";
        }
    }

    public override void Handle()
    {
        base.Handle();
        if(thrash.LidOpen)
        {
            thrash.CloseLid();
            InteractionTask = "Open Lid";
        }
        else
        {
            thrash.OpenLid();
            InteractionTask = "Close Lid";
        }
       
    }
}
