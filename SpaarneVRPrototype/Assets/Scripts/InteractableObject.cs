using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour {

    private Vector3 originalPosition;

    public Collider zone;

    public bool isGrabbed = false;


    private void Start()
    {
        originalPosition = this.transform.position;
    }

    public void OnTriggerExit(Collider other)
    {
        if (other == zone)
        {
            Debug.Log("out of the zone");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other == zone)
        {
            Debug.Log("In the zone");
        }
    }
}
