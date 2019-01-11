using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Background_Room_Sound : MonoBehaviour {

    //public AudioClip backgroundSound;
    public AudioSource backgroundSource;
    public PersonPosition personPosition;
    public InteractionDoor interactionDoor;


    // Update is called once per frame
    void Update()
    {


        if (personPosition.inTube && !interactionDoor.doorIsOpen || personPosition.inRoom)
        {
            backgroundSource.volume = 0;
        }
        else
        {
            backgroundSource.volume = 1;
        }


    }
}