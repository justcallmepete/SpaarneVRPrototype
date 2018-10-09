using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteractionComponent : MonoBehaviour {

    private RaycastHit hit;
    private Vector3 forwardPos;
    private Vector3 startPos;
	
	private InteractableObject grabbedObject;
	public Oculus_Controller controller;
	
	
	
	private bool isInteractable(GameObject hitObject){
		if (hitObject && hitObject.GetComponent<InteractableObject>())
			return true;
		else
			return false;
	}
	
	public void SelectItem(GameObject hitObject){
		if(isInteractable(hitObject)){
			grabbedObject = hitObject.GetComponent<InteractableObject>();
			grabbedObject.Select(controller);
		}
	}
	
	public void ReleaseItem(){
		if (grabbedObject){
			grabbedObject.Deselect();
		}
	}


}
