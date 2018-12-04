using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroHandler : MonoBehaviour {
    public GameObject EndWalking;
    public GameObject movementAttachment;
    public GameObject PlayerVR;
    public GameObject PlayerPC;
    public GameObject controller;
    public float speed = 1.5f;
    public bool found;
    public bool done;
    public WarningSystem warningSystem;
    public float waitDelay = 4f;
    public float timer = 0;
	// Use this for initialization
	void Start () {
        warningSystem = GameObject.Find("Manager").GetComponent<WarningSystem>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!found)
        {
            if (PlayerPC.activeInHierarchy)
            {
                movementAttachment = PlayerPC;
                found = true;
            }
            else if (PlayerVR.activeInHierarchy)
            {
                movementAttachment = PlayerVR.transform.GetChild(0).gameObject;
                found = true;   
            }
            warningSystem.SetWarning("Welcome, Feel free to look around.");
        }
        else
        {
            
            controller.SetActive(false);
            if (timer > waitDelay)
            {
                movementAttachment.transform.position += Vector3.Normalize(EndWalking.transform.position - movementAttachment.transform.position) * Time.deltaTime * speed;
                if (Vector3.Magnitude(movementAttachment.transform.position - new Vector3(EndWalking.transform.position.x, movementAttachment.transform.position.y, EndWalking.transform.position.z)) < 0.075f)
                {
                    warningSystem.SetWarning("Don't forget to read the clipboard.");
                    done = true;
                }



                if (done)
                {
                    controller.SetActive(true);
                    transform.gameObject.SetActive(false);
                }
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
	}
}
