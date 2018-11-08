using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCollider : MonoBehaviour {
    public bool hit;
	
	// Update is called once per frame
	void OnTriggerEnter (Collider col) {
        if(col.transform.tag == "Player")
        {
            hit = true;
        }
	}
    
    void OnTriggerExit (Collider col)
    {
        if(col.transform.tag == "Player")
        {
            hit = false;
        }
    }
    
}
