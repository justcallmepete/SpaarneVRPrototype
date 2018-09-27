using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedTeleportSpot : MonoBehaviour {

    [SerializeField]
    private GameObject outline;

    public void OnHover()
    {
        if (!outline.activeInHierarchy) outline.SetActive(true);
    }

    public void Off()
    {
        if (outline.activeInHierarchy) outline.SetActive(false);
    }

}
