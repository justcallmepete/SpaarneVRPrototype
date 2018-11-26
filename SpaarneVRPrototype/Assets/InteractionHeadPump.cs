using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class InteractionHeadPump : Interaction {
    public SingleVariable washHands;

    public override void Start()
    {
        base.Start();
        InteractionTask = "Wash hands";

    }

    public override void Handle()
    {
        base.Handle();
        if (washHands.task)
        {
            warningSystem.SetWarning("You just washed your hands.");

        }else
        {
            washHands.task = true;
        }
    }
}
