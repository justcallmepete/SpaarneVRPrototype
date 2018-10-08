using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteractionComponent : MonoBehaviour {

    [SerializeField]
    private GameObject controller;

    private RaycastHit hit;
    private Vector3 forwardPos;
    private Vector3 startPos;

    private GameObject hitObject;

    public void UpdateComponent()
    {

    }

    private void ControllerRaycast()
    {
        Ray r = new Ray(controller.transform.position, controller.transform.forward);
        forwardPos = startPos + controller.transform.forward * 10;
        if (Physics.Raycast(r, out hit))
        {
            hitObject = hit.transform.gameObject;
        }
        else
        {
            hitObject = null;
        }
    }


}
