using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedTeleportSpot : MonoBehaviour {

    public Vector3 TeleportTransform
    {
        get { return teleportTransform; }
    }

    [SerializeField]
    private GameObject outline;
    public Transform teleportDestination;
    private Vector3 teleportTransform;

    private void Start()
    {
        //teleportTransform = gameObject.transform.position + Vector3.up * 0.5f;
        teleportTransform = teleportDestination.position + Vector3.up * .5f;
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
