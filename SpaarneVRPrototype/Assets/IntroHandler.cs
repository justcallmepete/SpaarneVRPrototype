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
    public bool firstmessage = false;
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
                movementAttachment = PlayerVR;
                found = true;   
            }
          

        }
        else
        {
            if (!firstmessage)
            {
                warningSystem.SetWarning("Welcome, Feel free to look around.");
                firstmessage = true;
            }
            controller.SetActive(false);
            warningSystem.transform.GetComponent<Oculus_Controller>().enabled = false;
            if (timer > waitDelay)
            {
                if (Vector3.Magnitude(movementAttachment.transform.position - new Vector3(EndWalking.transform.position.x, movementAttachment.transform.position.y, EndWalking.transform.position.z)) > 2f)
                {
                    movementAttachment.transform.position += Vector3.Normalize(new Vector3(EndWalking.transform.position.x, movementAttachment.transform.position.y, EndWalking.transform.position.z) - movementAttachment.transform.position) * Time.deltaTime * speed;
                }
                else
                {
                    movementAttachment.transform.position += Vector3.Normalize(new Vector3(EndWalking.transform.position.x, movementAttachment.transform.position.y, EndWalking.transform.position.z) - movementAttachment.transform.position) * Time.deltaTime * speed *(Vector3.Magnitude(movementAttachment.transform.position - new Vector3(EndWalking.transform.position.x, movementAttachment.transform.position.y, EndWalking.transform.position.z))/2f);

                }
                //Debug.Log(Vector3.Magnitude(movementAttachment.transform.position - new Vector3(EndWalking.transform.position.x, movementAttachment.transform.position.y, EndWalking.transform.position.z)));
                if (Vector3.Magnitude(movementAttachment.transform.position - new Vector3(EndWalking.transform.position.x, movementAttachment.transform.position.y, EndWalking.transform.position.z)) < 0.085f)
                {
                    warningSystem.SetWarning("Don't forget to read the clipboard.");
                    done = true;
                }



                if (done)
                {
                    warningSystem.transform.GetComponent<Oculus_Controller>().enabled = true;
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
