using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modelScript : MonoBehaviour {

    MeshRenderer renderer;

	// Use this for initialization
	void Start () {
        renderer = this.GetComponent<MeshRenderer>();
        renderer.enabled = false;
	}

}
