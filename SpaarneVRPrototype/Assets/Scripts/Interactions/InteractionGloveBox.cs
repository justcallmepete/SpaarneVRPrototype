using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionGloveBox : Interaction {
    public AllThrashStatus thrash;
    public bool UnlockedBox;
    public string size;

    public override void Start()
    {
        base.Start();
        thrash = GameObject.Find("AllThrash").GetComponent<AllThrashStatus>();
    }
    public void Update()
    {
        if (!UnlockedBox)
        {
            InteractionTask = "OpenBox";
        }else
        {
            InteractionTask = "Throw Away";
        }
    }

    public override void Handle()
    {
        base.Handle();
       
        if (!UnlockedBox)
        {
            UnlockedBox = true;
            transform.GetChild(0).gameObject.SetActive(true);
            InteractionTask = "Throw Away";
        }
        else
        {
            if (thrash.isThereACanOpen())
            {
                if (size == "S") { this.transform.parent.GetComponent<GloveBoxHolderStats>().posS = false; }
                if (size == "M") { this.transform.parent.GetComponent<GloveBoxHolderStats>().posM = false; }
                if (size == "L") { this.transform.parent.GetComponent<GloveBoxHolderStats>().posL = false; }
                this.gameObject.SetActive(false);
            }
            else
            {
                warningSystem.SetWarning("You cant throw this away if the garbage bin is closed.");
            }
        }
    }
}
