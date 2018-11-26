using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionOpenPackage : Interaction {
    public AllThrashStatus thrash;

    public override void Start()
    {
        base.Start();
        InteractionTask = "Throw Away";
        thrash = GameObject.Find("AllThrash").GetComponent<AllThrashStatus>();
    }

    public override void Handle()
    {
        base.Handle();
        if (thrash.isThereACanOpen())
        {
            gameObject.SetActive(false);
        }else
        {
            warningSystem.SetWarning("You cant throw stuff in a closed bin.");
        }
    }
}
