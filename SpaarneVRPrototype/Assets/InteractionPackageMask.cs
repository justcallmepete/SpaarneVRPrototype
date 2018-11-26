using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPackageMask : Interaction {
    public override void Start()
    {
        base.Start();
        InteractionTask = "Open package";
    }

    public override void Handle()
    {
        base.Handle();
        transform.parent.transform.GetChild(0).gameObject.SetActive(true);
        transform.parent.transform.GetChild(1).gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
