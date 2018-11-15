using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloveDisplay : MonoBehaviour {
    public SingleVariable gloves;
    public GameObject image;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gloves.task)
        {
            image.SetActive(true);
        }
        else
        {
            image.SetActive(false);
        }
	}
}
