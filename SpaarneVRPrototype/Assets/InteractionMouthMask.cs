using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionMouthMask : Interaction {
    public SingleVariable mouthMask;

    public override void Start()
    {
        base.Start();
        InteractionTask = "Put On Mouth Mask";
    }

    public override void Handle()
    {
        base.Handle();
        mouthMask.task = true;
        transform.parent.gameObject.SetActive(false);
    }
}
