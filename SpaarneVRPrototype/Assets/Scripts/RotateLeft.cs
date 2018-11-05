using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLeft : MonoBehaviour {
	
	public float speed = 30f;
	
	public List<GameObject> Objects;
	
	// Update is called once per frame
	void Update () {
		foreach(GameObject g in Objects)
		g.transform.RotateAround(g.transform.position, g.transform.up, Time.deltaTime * speed);
	}
}
