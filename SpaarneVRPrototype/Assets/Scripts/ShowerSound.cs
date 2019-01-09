using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowerSound : MonoBehaviour {
    public GameObject Shower_Sound;
    public PersonPosition personPosition;
    public InteractionDoor interactionDoor;


	// Update is called once per frame
	void Update () {


        if (personPosition.inTube && interactionDoor.doorIsOpen || personPosition.inRoom)
        {
            Shower_Sound.SetActive(true);
        }
        else {
            Shower_Sound.SetActive(false);
        }


    }
}
