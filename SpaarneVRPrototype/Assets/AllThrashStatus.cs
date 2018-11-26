using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllThrashStatus : MonoBehaviour {
    List<ThrashStatus> ThrashyList = new List<ThrashStatus>();
	// Use this for initialization
	void Start () {
       foreach(GameObject thrash in GameObject.FindGameObjectsWithTag("ThrashCan"))
        {
            ThrashyList.Add(thrash.GetComponent<ThrashStatus>());
        }
	}

    public bool isThereACanOpen()
    {
        foreach(ThrashStatus thrash in ThrashyList)
        {
            if (thrash.LidOpen)
            {
                return true;
            }
        }

        return false;
    }
}
