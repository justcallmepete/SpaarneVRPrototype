using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportComponent : MonoBehaviour
{

    public GameObject lastTeleportSpot = null;

    private bool teleportEnabled;
	
	private GameObject currentObject;
	
	private FixedTeleportSpot currentTP;

    void Start()
    {
        teleportEnabled = false;
    }
    	
	public void UpdateComponent(GameObject hitObject){
		currentObject = hitObject;
		if (IsTeleportSpot() && !IsLastSpot()){
			currentTP = hitObject.GetComponent<FixedTeleportSpot>();
			if(!IsLastSpot()){
			OnHover();
			teleportEnabled = true;
			} else {
				OffHover();
			teleportEnabled = false;
			}
		} 
		if(!IsTeleportSpot() && currentTP){
			OffHover();
			teleportEnabled = false;
		}
	}
	
	private bool IsLastSpot(){
		if(currentObject == lastTeleportSpot){
			return true;
		} else{
			return false;
		}
	}
	
	private bool IsTeleportSpot(){
		if (currentObject && currentObject.GetComponent<FixedTeleportSpot>()){
			return true;
		}
		else {
			return false;
		}
	}

    private void OnHover()
    {
    currentTP.OutlineOn();
    }
	
	private void OffHover(){
	currentTP.OutlineOff();
	}

   public void TeleportToPosition(GameObject hitobject)
    {
        if (teleportEnabled && currentTP){
			gameObject.transform.position =  currentTP.TeleportTransform;
			lastTeleportSpot = currentObject;
			currentTP.OutlineOff();
			currentTP = null;
		}
    }
}
