using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteractionComponent : MonoBehaviour {

    [SerializeField]
    private GameObject controller;

    private RaycastHit hit;
    private Vector3 forwardPos;
    private Vector3 startPos;
	
	private bool isInteractable(GameObject hitObject){
		if (hitObject && hitObject.GetComponent<InteractableObject>())
			return true;
		else
			return false;
	}
	
	public void SelectItem(GameObject hitObject){
		if(isInteractable(hitObject)){
		Debug.Log("item is interactable");
		}
	}


}
