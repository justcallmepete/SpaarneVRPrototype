using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionGloveBoxPlacement : Interaction{
    public string size;
    public GloveBoxHolderStats gloveBoxHolderStats;

    public override void Start()
    {
        base.Start();
        InteractionTask = "Move to glovebox holder.";  
    }

    public override void Handle()
    {
        base.Handle();
        if(size == "S")
        {
            if (gloveBoxHolderStats.posS) {
                warningSystem.SetWarning("There is already a box of size S gloves in the holder.");
            } else{
                gloveBoxHolderStats.transform.GetChild(0).gameObject.SetActive(true);
                gloveBoxHolderStats.transform.GetChild(0).GetComponent<InteractionGloveBox>().UnlockedBox = false;
                gloveBoxHolderStats.transform.GetChild(0).GetComponent<InteractionGloveBox>().InteractionTask = "Open The Box";
                gloveBoxHolderStats.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                gloveBoxHolderStats.posS = true;
                this.gameObject.SetActive(false);
                 
            }
        }else if(size == "M")
        {
            if (gloveBoxHolderStats.posM)
            {
                warningSystem.SetWarning("There is already a box of size M gloves in the holder.");
            }
            else
            {
                gloveBoxHolderStats.transform.GetChild(1).gameObject.SetActive(true);
                gloveBoxHolderStats.transform.GetChild(1).GetComponent<InteractionGloveBox>().UnlockedBox = false;
                gloveBoxHolderStats.transform.GetChild(1).GetComponent<InteractionGloveBox>().InteractionTask = "Open The Box";
                gloveBoxHolderStats.transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(false);
                gloveBoxHolderStats.posM = true;
                this.gameObject.SetActive(false);

            }
        }
        else if(size == "L")
        {

        }
    }

}
