using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HigherHead : MonoBehaviour {
    public GameObject Floor;
    public GameObject CenterEye;
    public bool updatedHead = false;
    public float timer = 0.4f;
    public float time;
	// Use this for initialization
	void Start () {
    }

    private void Update()
    {
        if (time > timer)
        {
            
            if (!updatedHead)
            {
                if (CenterEye.transform.position.y < 1.65f)
                {
                    Floor.transform.position = new Vector3(Floor.transform.position.x, Floor.transform.position.y + (1.68f - CenterEye.transform.position.y), Floor.transform.position.z);
                }
                this.GetComponent<HigherHead>().enabled = false;
                updatedHead = true;
            }

        }
        time += Time.deltaTime;
    }
}
