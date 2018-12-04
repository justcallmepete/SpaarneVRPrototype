using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionIdleDoor : Interaction
{
    public string TextForWarning;

    public override void Start()
    {
        base.Start();
        InteractionTask = "Open door";
    }

    public override void Handle()
    {
        base.Handle();
        warningSystem.SetWarning(TextForWarning);
    }
}
