using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionOpenPackage : Interaction {
    public ThrashStatus thrash;

    public override void Start()
    {
        base.Start();
        InteractionTaskB = "Throw Away";
    }

    public override void Handle()
    {
        base.Handle();
        if (thrash.LidOpen)
        {
            gameObject.SetActive(false);
        }else
        {
            warningSystem.SetWarning("You cant throw stuff in a closed bin.");
        }
    }
}
