using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionThrashLid : Interaction {
    public ThrashStatus thrash;

        private void Update()
    {
        if (thrash.LidOpen)
        {
            InteractionTask = "Sluit Prullenbak";
        }
        else
        {
            InteractionTask = "Open Prullenbak";
        }
    }

    public override void Handle()
    {
        base.Handle();
        if(thrash.LidOpen)
        {
            thrash.CloseLid();
            InteractionTask = "Open Prullenbak";
        }
        else
        {
            thrash.OpenLid();
            InteractionTask = "Sluit Prullenbak";
        }
       
    }
}
