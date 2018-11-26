using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionMoveAbleSanitizer : Interaction {
    public HandSanitizerStatus handSanStat;

    public override void Handle()
    {
        base.Handle();
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
}
