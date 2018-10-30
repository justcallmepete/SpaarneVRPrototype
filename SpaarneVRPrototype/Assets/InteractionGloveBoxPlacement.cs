using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionGloveBoxPlacement : Interaction{
    public string size;
    public GloveBoxHolderStats gloveBoxHolderStats;

    public override void Interact()
    {
        base.Interact();
        if(size == "S")
        {
            if (gloveBoxHolderStats.posS) {
                warningSystem.SetWarning("There is already a box of size S gloves in the holder.");
            } else{
                gloveBoxHolderStats.transform.GetChild(0).gameObject.SetActive(true);
                gloveBoxHolderStats.transform.GetChild(0).GetComponent<InteractionGloveBox>().UnlockedBox = false;
                gloveBoxHolderStats.transform.GetChild(0).GetComponent<InteractionGloveBox>().InteractionTaskA = "Open The Box";
                gloveBoxHolderStats.posS = true;
                this.gameObject.SetActive(false); 
            }
        }else if(size == "M")
        {

        }else if(size == "L")
        {

        }
    }

    public override void Handle()
    {
        base.Handle();
        warningSystem.SetWarning("Why would you throw away a unused box of gloves?");
    }

}
