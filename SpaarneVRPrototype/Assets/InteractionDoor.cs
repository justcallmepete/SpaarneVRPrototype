using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDoor : Interaction {
    public InteractionDoor otherDoor;
    public AudioClip openDoorSound;
    public AudioClip closeDoorSound;
    public AudioSource hingesSound;
    public bool doorIsOpen = false;
    public override void Start()
    {
        base.Start();
        InteractionTask = "Open de Deur";

    }

    public override void Handle()
    {
        base.Handle();
        if (!doorIsOpen)
        {
            if (otherDoor.doorIsOpen)
            {
                warningSystem.SetWarning("Sluit andere deur eerst. We willen geen ziekte verspreiding.");
            }else
            {
                InteractionTask = "Sluit de Deur";
                doorIsOpen = true;
                transform.parent.parent.transform.Rotate(new Vector3(0, 1, 0), -90f);
                hingesSound.PlayOneShot(openDoorSound);
            }
        }
        else
        {
            InteractionTask = "Open de Deur";
            doorIsOpen = false;
            transform.parent.parent.transform.Rotate(new Vector3(0, 1, 0), 90f);
            hingesSound.PlayOneShot(closeDoorSound);

        }
              
    }
}
