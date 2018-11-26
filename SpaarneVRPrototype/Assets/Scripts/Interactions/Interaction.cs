using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour {
    public WarningSystem warningSystem;
    public string InteractionTask = "null";

	// Use this for initialization
	public virtual void Start () {
        warningSystem = GameObject.Find("Manager").GetComponent<WarningSystem>();
	}

    public virtual void Handle()
    {

    }
}
