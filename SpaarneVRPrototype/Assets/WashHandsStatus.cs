using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashHandsStatus : MonoBehaviour {
    public float timer;
    public float number = 5;
    public SingleVariable washHands;
	// Use this for initialization
	public void Start() {
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {

        if (washHands.task && timer > (number + 2))
        {
            timer = 0;
        }
        timer += Time.deltaTime;

        if(timer > number)
        {
            washHands.task = false;
        }

	}
}
