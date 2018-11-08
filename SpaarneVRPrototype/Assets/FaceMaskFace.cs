using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceMaskFace : MonoBehaviour {
    public SingleVariable MouthMask;
    public GameObject FaceMask;
	// Update is called once per frame
	void Update () {
        if (MouthMask.task)
        {
            FaceMask.SetActive(true);
        }
        else
        {
            FaceMask.SetActive(false);
        }
	}
}
