using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionProcedureSelect : Interaction {
    public int number;
    public GameSettings gameSettings;
    public Vector3 startPos;
    public PrikBordStats prikBordStats; 

    public override void Start()
    {
        base.Start();
        startPos = this.transform.parent.transform.position;
        prikBordStats = GameObject.Find("Prikbord_Model").GetComponent<PrikBordStats>();
        InteractionTask = "Select Procedure";
    }

    public override void Handle()
    {
        base.Handle();
        if(InteractionTask != "Select Procedure") {
            prikBordStats.ResetPositionProcedure(this.transform.parent.gameObject);
        } else
        {
            prikBordStats.MoveIntoPositionProcedure(this.transform.parent.gameObject);
        }
    }
}
