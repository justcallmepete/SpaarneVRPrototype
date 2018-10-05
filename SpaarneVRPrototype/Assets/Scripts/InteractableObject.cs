using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour {

    private Rigidbody rb;
    public bool hasLeftZone = false;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.useGravity = true;
    }
}
