using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionGloves : Interaction {
    public SingleVariable Gloves;

    public override void Handle()
    {
        base.Handle();
        Gloves.task = true; 
    }
}
