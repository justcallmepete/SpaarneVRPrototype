using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestOneTracker : MonoBehaviour {
    public QuestOne questOne;
	
	// Update is called once per frame
	void Update () {
        if(questOne.questSteps[0])
        {
            transform.GetChild(12).gameObject.SetActive(true);
        }else
        {
            transform.GetChild(12).gameObject.SetActive(false);
        }

        if (questOne.questSteps[1])
        {
            transform.GetChild(13).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(13).gameObject.SetActive(false);
        }

        if (questOne.questSteps[2])
        {
            transform.GetChild(14).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(14).gameObject.SetActive(false);
        }


        if (questOne.questSteps[3])
        {
            transform.GetChild(15).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(15).gameObject.SetActive(false);
        }


        if (questOne.questSteps[4])
        {
            transform.GetChild(16).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(16).gameObject.SetActive(false);
        }

        if (questOne.questSteps[5])
        {
            transform.GetChild(17).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(17).gameObject.SetActive(false);
        }
    }
}
