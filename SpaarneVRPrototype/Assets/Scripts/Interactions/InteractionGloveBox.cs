using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionGloveBox : Interaction {
    public ThrashStatus thrash;
    public bool UnlockedBox;
    public string size;

    public override void Handle()
    {
        base.Handle();
        if (!UnlockedBox)
        {
            warningSystem.SetWarning("You havent opened the box yet and already want to dispose of it?");
        }else
        {
            if (thrash.LidOpen)
            {
                if (size == "S") { this.transform.parent.GetComponent<GloveBoxHolderStats>().posS = false; }
                if (size == "M") { this.transform.parent.GetComponent<GloveBoxHolderStats>().posM = false; }
                if (size == "L") { this.transform.parent.GetComponent<GloveBoxHolderStats>().posL = false; }
                this.gameObject.SetActive(false);
            }else
            {
                warningSystem.SetWarning("You cant throw this away if the garbage bin is closed.");
            }
        }
    }

    public override void Interact()
    {
        base.Interact();
        if (!UnlockedBox)
        {
            InteractionTaskA = "null";
            UnlockedBox = true;
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
