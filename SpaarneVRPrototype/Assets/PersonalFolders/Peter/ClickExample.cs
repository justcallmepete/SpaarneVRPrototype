using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickExample : MonoBehaviour {

	// Use this for initialization
    public Renderer rend;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKey(KeyCode.A))
	    {
	        rend.material.SetFloat("_OutlineWidth", 1.14f);
        }
	}
}
