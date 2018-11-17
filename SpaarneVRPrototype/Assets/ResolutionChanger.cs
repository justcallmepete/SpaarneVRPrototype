using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionChanger : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        Debug.Log("Set to: " + UnityEngine.XR.XRSettings.eyeTextureResolutionScale);
        UnityEngine.XR.XRSettings.eyeTextureResolutionScale = 1.5f;
        OVRManager.tiledMultiResLevel = OVRManager.TiledMultiResLevel.LMSMedium; // LMSHigh
     //   OVRManager.display.displayFrequency = 72.0f;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
