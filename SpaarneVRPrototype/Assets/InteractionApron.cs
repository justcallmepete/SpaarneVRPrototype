using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionApron : Interaction
{
    public SingleVariable apron;
	
	public override void Start () {
        base.Start();
        InteractionTask = "Doe een schort aan";
	}

    public override void Handle()
    {
        base.Handle();
        if (!apron.task)
        {
            apron.task = true;
        }else
        {
            warningSystem.SetWarning("Je hebt al een schort aan.");
        }

    }
}
