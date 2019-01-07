using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTwoTracker : MonoBehaviour {
    public QuestTwo questTwo;
	
	// Update is called once per frame
	void Update () {
        if (questTwo.questStepts[0])
        {
            transform.GetChild(9).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(9).gameObject.SetActive(false);
        }

        if (questTwo.questStepts[1])
        {
            transform.GetChild(10).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(10).gameObject.SetActive(false);
        }

        if (questTwo.questStepts[2])
        {
            transform.GetChild(11).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(11).gameObject.SetActive(false);
        }

        if (questTwo.questStepts[3])
        {
            transform.GetChild(12).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(12).gameObject.SetActive(false);
        }

        if (questTwo.questStepts[4])
        {
            transform.GetChild(13).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(13).gameObject.SetActive(false);
        }

        if (questTwo.questStepts[5])
        {
            transform.GetChild(14).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(14).gameObject.SetActive(false);
        }

        if (questTwo.questStepts[6])
        {
            transform.GetChild(15).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(15).gameObject.SetActive(false);
        }

        if (questTwo.questStepts[7])
        {
            transform.GetChild(16).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(16).gameObject.SetActive(false);
        }

    }
}
