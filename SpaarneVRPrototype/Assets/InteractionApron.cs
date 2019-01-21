using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionApron : Interaction
{
    public SingleVariable apron;
	
	public override void Start () {
        base.Start();
        InteractionTask = "Put on Apron";
	}

    public override void Handle()
    {
        base.Handle();
        if (!apron.task)
        {
            apron.task = true;
        }else
        {
            warningSystem.SetWarning("You already have a apron on.");
        }

    }
}
