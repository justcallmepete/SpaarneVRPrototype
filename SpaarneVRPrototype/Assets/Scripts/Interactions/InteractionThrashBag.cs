using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionThrashBag : Interaction {
    public ThrashStatus thrash;
    public SingleVariable Gloves;
    public SingleVariable MouthMask;
    public SingleVariable Apron;
    public void Update()
    {
        if (Gloves.task)
        {
            InteractionTask = "Verwijder Handschoenen";
        }
        else if (Apron.task) {
            InteractionTask = "Verwijder Schort";
        }
        else if (MouthMask.task)
        {
            InteractionTask = "Verwijder Mondmasker";
        }
        else
        {
            InteractionTask = "null";

        }

    }
    public override void Handle()
    {
        base.Handle();
        if (thrash.LidOpen)
        {
            if (InteractionTask == "Verwijder Handschoenen")
            {
                Gloves.task = false;
            }
            else if (InteractionTask == "Verwijder Mondmasker")
            {
                MouthMask.task = false;
            }
            else if (InteractionTask == "Verwijder Schort")
            {
                Apron.task = false;
            }else
            {
                warningSystem.SetWarning("Je hebt niets om weg te gooien.");
            } 
        }else
        {
            warningSystem.SetWarning("De prullenbak is dicht.");
        }
    }
}
