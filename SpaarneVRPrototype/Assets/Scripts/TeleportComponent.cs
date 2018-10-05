using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportComponent : MonoBehaviour
{
    public bool TeleportEnabled
    {
        get { return teleportEnabled; }
    }

    public GameObject lastTeleportSpot = null;

    private bool teleportEnabled;
    public bool fixedSpotFound;

    void Start()
    {
        teleportEnabled = false;
        fixedSpotFound = false;
    }

    public bool OnHover(GameObject teleportSpot)
    {
        bool isSameObject = (teleportSpot != lastTeleportSpot) ? true : false;
        return isSameObject;
    }

   public void TeleportToPosition(FixedTeleportSpot teleportSpot)
    {
        if (teleportSpot.gameObject != lastTeleportSpot)
        {
            gameObject.transform.position = teleportSpot.TeleportTransform;
            lastTeleportSpot = teleportSpot.gameObject;
            teleportSpot.Off();
        }
    }
}
