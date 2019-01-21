using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionGloveBox : Interaction {
    public AllThrashStatus thrash;
    public bool UnlockedBox;
    public string size;

    public override void Start()
    {
        base.Start();
        thrash = GameObject.Find("AllThrash").GetComponent<AllThrashStatus>();
    }
    public void Update()
    {
        if (!UnlockedBox)
        {
            InteractionTask = "Open Handschoenendoos";
        }
    }

    public override void Handle()
    {
        base.Handle();
       
        if (!UnlockedBox)
        {
            UnlockedBox = true;
            transform.GetChild(0).gameObject.SetActive(true);
           
        }
    }
}
