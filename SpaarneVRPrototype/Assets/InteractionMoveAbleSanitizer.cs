using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionMoveAbleSanitizer : Interaction {
    public HandSanitizerStatus handSanStat;

    public override void Interact()
    {
        base.Interact();
        if (handSanStat.InPosition)
        {
            warningSystem.SetWarning("You cant move this while there is already one in use.");
        }else
        {
            handSanStat.gameObject.SetActive(true);
            handSanStat.transform.GetChild(1).gameObject.SetActive(true);
            handSanStat.transform.GetChild(2).gameObject.SetActive(false);
            this.transform.parent.gameObject.SetActive(false);
        }
    }

    public override void Handle()
    {
        base.Handle();

        warningSystem.SetWarning("Why would you throw away with out opening it first?");
    }
}
