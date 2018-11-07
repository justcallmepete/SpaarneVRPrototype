using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionGuideSelect : Interaction {
    public int number;
    public Vector3 startPos;
    public PrikBordStats prikBordStats;

    public override void Start()
    {
        base.Start();
        startPos = this.transform.parent.transform.position;
        prikBordStats = GameObject.Find("Prikbord_Model").GetComponent<PrikBordStats>();
    }

    public override void Handle()
    {
        base.Handle();
        if(InteractionTaskB != "Select Guide")
        {
            prikBordStats.ResetPositionGuide(this.transform.parent.gameObject);
        }else
        {
            prikBordStats.MoveIntoPositionGuide(this.transform.parent.gameObject);
        }
    }
}
