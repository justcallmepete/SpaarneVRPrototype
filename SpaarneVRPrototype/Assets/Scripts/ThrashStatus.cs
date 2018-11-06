using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrashStatus : MonoBehaviour {
    public bool LidOpen = false;
    public bool changeState = false;
    public GameObject Lid;
	// Update is called once per frame
	void Update () {
		
	}

    public void OpenLid()
    {
        Lid.transform.Rotate(new Vector3(0, 0, 1), -60f);
        LidOpen = true;
    }

    public void CloseLid()
    {
        LidOpen = false;
        Lid.transform.Rotate(new Vector3(0, 0, 1), 60f);
    }
}
