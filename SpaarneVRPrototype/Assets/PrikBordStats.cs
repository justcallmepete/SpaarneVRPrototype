using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrikBordStats : MonoBehaviour {
    public GameSettings gameSettings;
    public Vector3 positionProcedure;
    public bool procedure;
    public Vector3 positionGuide;
    public bool guide;
    public GameObject[] GuidePostIt = new GameObject[4];
    public GameObject[] ProcedurePostIt = new GameObject[4];
    // Use this for initialization
    void Start () {
        gameSettings = GameObject.Find("GameSettings").GetComponent<GameSettings>();
    }

    public void MoveIntoPositionProcedure(GameObject mover)
    {
        foreach(GameObject procedurePost in ProcedurePostIt)
        {
            if(mover.gameObject == procedurePost)
            {
                mover.transform.localPosition = positionProcedure;
                gameSettings.procedure[mover.transform.GetChild(0).GetComponent<InteractionProcedureSelect>().number] = true;
                mover.transform.GetChild(0).GetComponent<InteractionProcedureSelect>().InteractionTaskB = "Reset Choice";
            }
            else
            {
                procedurePost.transform.position = procedurePost.transform.GetChild(0).GetComponent<InteractionProcedureSelect>().startPos;
                gameSettings.procedure[procedurePost.transform.GetChild(0).GetComponent<InteractionProcedureSelect>().number] = false;
                procedurePost.transform.GetChild(0).GetComponent<InteractionProcedureSelect>().InteractionTaskB = "Select Procedure";
            }
        }
    }

    public void ResetPositionProcedure(GameObject reseter)
    {
        gameSettings.procedure[reseter.transform.GetChild(0).GetComponent<InteractionProcedureSelect>().number] = false;
        reseter.transform.position = reseter.transform.GetChild(0).GetComponent<InteractionProcedureSelect>().startPos;
        reseter.transform.GetChild(0).GetComponent<InteractionProcedureSelect>().InteractionTaskB = "Select Procedure";
    }

    public void MoveIntoPositionGuide(GameObject mover)
    {

        foreach (GameObject guidePost in GuidePostIt)
        {
            if (mover.gameObject == guidePost)
            {
                mover.transform.localPosition = positionGuide;
                gameSettings.guide[mover.transform.GetChild(0).GetComponent<InteractionGuideSelect>().number] = true;
                mover.transform.GetChild(0).GetComponent<InteractionGuideSelect>().InteractionTaskB = "Reset Choice";
            }
            else
            {
                guidePost.transform.position = guidePost.transform.GetChild(0).GetComponent<InteractionGuideSelect>().startPos;
                gameSettings.procedure[guidePost.transform.GetChild(0).GetComponent<InteractionGuideSelect>().number] = false;
                guidePost.transform.GetChild(0).GetComponent<InteractionGuideSelect>().InteractionTaskB = "Select Guide";
            }
        }
    }

    public void ResetPositionGuide(GameObject reseter)
    {
        gameSettings.guide[reseter.transform.GetChild(0).GetComponent<InteractionGuideSelect>().number] = false;
        reseter.transform.position = reseter.transform.GetChild(0).GetComponent<InteractionGuideSelect>().startPos;
        reseter.transform.GetChild(0).GetComponent<InteractionGuideSelect>().InteractionTaskB = "Select Guide";

    }
}
