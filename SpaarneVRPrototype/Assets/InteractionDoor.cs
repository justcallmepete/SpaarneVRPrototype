using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDoor : Interaction {
    public InteractionDoor otherDoor;
    public bool doorIsOpen = false;
    public override void Start()
    {
        base.Start();
        InteractionTaskB = "Open door";

    }

    public override void Handle()
    {
        base.Handle();
        if (!doorIsOpen)
        {
            if (otherDoor.doorIsOpen)
            {
                warningSystem.SetWarning("Close other door first. We dont want disease spread.");
            }else
            {
                InteractionTaskB = "Close door";
                doorIsOpen = true;
                transform.parent.parent.transform.Rotate(new Vector3(0, 1, 0), -90f);
            }
        }
        else
        {
            InteractionTaskB = "Open door";
            doorIsOpen = false;
            transform.parent.parent.transform.Rotate(new Vector3(0, 1, 0), 90f);

        }
              
    }
}
