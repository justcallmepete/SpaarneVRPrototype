using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonPosition : MonoBehaviour {
    public bool inTube;
    public bool inRoom;
    public RoomCollider room;
    public RoomCollider tube;

    public void Update()
    {
        if (room.hit)
        {
            inRoom = true;
        }
        else
        {
            inRoom = false;
        }
        if (tube.hit)
        {
            inTube = true;
        }
        else
        {
            inTube = false;
        }
    }
}
