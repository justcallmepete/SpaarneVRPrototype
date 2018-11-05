using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionClosedHandSanTop : Interaction {

    public override void Handle()
    {
        base.Handle();
        if (this.transform.parent.name == "HandSanitizerFull")
        {
            this.gameObject.SetActive(false);
            this.transform.parent.transform.GetChild(2).gameObject.SetActive(true);
        }else if(this.transform.parent.name == "HandSanitizerFullStorage")
        {
            warningSystem.SetWarning("It would be a mess if your replace the top while its standing here.");
        }
    }
}
