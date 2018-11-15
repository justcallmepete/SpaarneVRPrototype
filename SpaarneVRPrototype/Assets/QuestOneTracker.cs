using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestOneTracker : MonoBehaviour {
    public QuestOne questOne;
	
	// Update is called once per frame
	void Update () {
        if(questOne.PutOnMaskBeforeEntering)
        {
            transform.GetChild(12).gameObject.SetActive(true);
        }else
        {
            transform.GetChild(12).gameObject.SetActive(false);
        }

        if (questOne.WasinRoom)
        {
            transform.GetChild(13).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(13).gameObject.SetActive(false);
        }

        if (questOne.WashedHandsBeforeLeaving)
        {
            transform.GetChild(14).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(14).gameObject.SetActive(false);
        }


        if (questOne.LeftAfterWashingHands)
        {
            transform.GetChild(15).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(15).gameObject.SetActive(false);
        }


        if (questOne.RemovedMaskAfterLeaving)
        {
            transform.GetChild(16).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(16).gameObject.SetActive(false);
        }

        if (questOne.WashedHandsAfterRemovingMask)
        {
            transform.GetChild(17).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(17).gameObject.SetActive(false);
        }
    }
}
