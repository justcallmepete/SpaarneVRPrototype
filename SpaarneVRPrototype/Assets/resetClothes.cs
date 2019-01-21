using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetClothes : MonoBehaviour {
    public SingleVariable apron;
    public SingleVariable mouthMask;
    public SingleVariable gloves;
    
	// Use this for initialization
	void Start () {
        apron.task = false;
        mouthMask.task = false;
        gloves.task = false;
	}

}
