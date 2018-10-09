using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportComponent : MonoBehaviour
{

    public GameObject lastTeleportSpot = null;

    private bool teleportEnabled;
    public bool fixedSpotFound;
	
	private GameObject currentObject;

    void Start()
    {
        teleportEnabled = false;
        fixedSpotFound = false;
    }
	
	public void UpdateComponent(GameObject hitObject){
		teleportEnabled = false;
		currentObject = hitObject;
		if (IsTeleportSpot() && !IsLastSpot()){
			OnHover();
			teleportEnabled = true;
		} //if (IsteleportSpot() && IsLastSpot()){
		//	OffHover();
		//	teleportEnabled = false;
		//}
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
     currentObject.GetComponent<FixedTeleportSpot>().On();
    }
	
	private void OffHover(){
		 currentObject.GetComponent<FixedTeleportSpot>().Off();
	}

   public void TeleportToPosition()
    {
        if (teleportEnabled){
			FixedTeleportSpot tp = currentObject.GetComponent<FixedTeleportSpot>();
			gameObject.transform.position =  tp.TeleportTransform;
			lastTeleportSpot = currentObject;
			tp.Off();
		}
    }
}
