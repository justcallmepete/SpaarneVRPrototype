using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedTeleportSpot : MonoBehaviour {

    public Vector3 TeleportTransform
    {
        get { return teleportTransform; }
    }

    
    public GameObject outline;
    public GameObject teleportDestination;
    private Vector3 teleportTransform;

    private void Start()
    {
        teleportTransform = teleportDestination.transform.position;
    }

    public void OutlineOn()
    {
        if (!outline.activeInHierarchy) outline.SetActive(true);
    }

    public void OutlineOff()
    {
        if (outline.activeInHierarchy) outline.SetActive(false);
    }

}
