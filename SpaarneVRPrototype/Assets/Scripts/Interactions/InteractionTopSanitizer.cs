using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTopSanitizer : Interaction
{
    public SingleVariable Gloves;
    public SingleVariable WashedHands;
    public Animator anim;

    public override void Start()
    {
        base.Start();
        InteractionTask = "Was handen";
    }

    public override void Handle()
    {
        base.Handle();
        if (Gloves.task)
        {
            warningSystem.SetWarning("Je kan je handen niet wassen met handschoenen aan.");
        }else
        {
            if (WashedHands.task)
            {
                warningSystem.SetWarning("Je hebt je handen net gewassen...");
            }
            else
            {
                WashedHands.task = true;
                anim.SetTrigger("Pumping 0");

            }
           
        }
    }
}
