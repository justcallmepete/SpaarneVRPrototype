using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionBottleHandSanitizer : Interaction {
   public AllThrashStatus thrash;


    public override void Start()
    {
        base.Start();
        thrash = GameObject.Find("AllThrash").GetComponent<AllThrashStatus>();
    }

    public override void Handle()
    {

        base.Handle();
        if (this.transform.parent.transform.GetChild(1).gameObject.activeInHierarchy)
        {
            warningSystem.SetWarning("You really want to throw away a fresh and unopend bottle?");
        }else if (thrash.isThereACanOpen())
        {
            this.transform.parent.GetComponent<HandSanitizerStatus>().InPosition = false;
            this.transform.parent.transform.gameObject.SetActive(false);
        } else
        {
            warningSystem.SetWarning("You cant throw this away if the garbage bin is closed.");
        }
    }

}
