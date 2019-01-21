﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestOne : MonoBehaviour
{
    public string LastActivity;
    public InteractionManager interactionManager;
    public WarningSystem warningSystem;
    public PersonPosition PersonP;
    public SingleVariable mouthMask;
    public SingleVariable WashedHands;
    public List<bool> questSteps = new List<bool>();

    public bool completed = false;
    public bool warned = false;
    public float timer = 0;

    // Use this for initialization
	void Start ()
    {
        for (int i = 0; i < 6; i++)
        {
            questSteps.Add(false);
        }
      Debug.Log("done");
        warningSystem = GameObject.Find("Manager").GetComponent<WarningSystem>();
        
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!warned)
        {
            timer = 0;
        }
        if (warned)
        {
            timer += Time.deltaTime;
            if(timer > 4)
            {
                //load scene
                SceneManager.LoadScene("Hospital_Wing");
            }
        }
        LastActivity = interactionManager.LastActivity;
        
        //Check if the person left the room with out washing hands. 
        if(!PersonP.inRoom && questSteps[1] && !questSteps[2] && !warned)
        {
            warningSystem.SetWarning("Je bent weg gegaan zonder je handen te wassen." , true, "Red");
            warned = true;
        }

        if(PersonP.inRoom && !warned)
        {
            questSteps[1] = true;
        }

        //Arogene Isolatie
        if (!questSteps[0])
        {
            //Check if person is not in the room or tube and puts on mouthmask.
            if (!PersonP.inTube && !PersonP.inRoom && mouthMask.task)
            {
                questSteps[0] = true;
            }
            //if the person doesnt have a mask but still enters the room he fails.
            else if (PersonP.inTube && !mouthMask.task || PersonP.inRoom && !mouthMask.task)
            {
                if (!warned)
                {
                    warned = true;
                    warningSystem.SetWarning("Je hebt je masker al afgedaan voordat het moest." , true, "Red");
                }
            }
        }else if (questSteps[0] && !PersonP.inRoom && !PersonP.inTube && !questSteps[1])
        {
            if(!mouthMask.task)
            {
                questSteps[0] = false;
            }
        }
        //if the person removes or doesnt have a mask in the tube or room he fails.
        else if(PersonP.inTube && !mouthMask.task || PersonP.inRoom && !mouthMask.task)
        { 
            if (!warned)
            {
            warned = true;
            warningSystem.SetWarning("Je hebt je masker al afgedaan voordat het moest" , true, "Red");
            }
        }
        //if at this point the person hasnt failed he should be in the room. 
        else if (!warned && questSteps[1])
        {
            //Before exiting the room Wash Hands
            if (!questSteps[2] && PersonP.inRoom)
            {
                if (WashedHands.task)
                {
                    questSteps[2] = true;
                    WashedHands.task = false;
                }
            }
            //if the person does anything else in the room the washed hands status drops.
            else if (LastActivity != "Was handen" && LastActivity != "Open de Deur" &&  LastActivity != "Sluit de Deur" && PersonP.inRoom)
            {
                questSteps[2] = false;
            }else if(questSteps[2] && !questSteps[3])
            {
                if(!PersonP.inRoom && !PersonP.inTube)
                {
                    questSteps[3] = true; 
                }
            }
            else if (!PersonP.inRoom && !PersonP.inTube && !mouthMask.task && !questSteps[4])
            {
                questSteps[4] = true;
            }else if (!questSteps[5] && questSteps[4])
            {
                if (WashedHands.task && LastActivity == "Was handen")
                {
                    questSteps[5] = true;
                    WashedHands.task = false;
                }
            }
        }

        //Last step after removing the mask is to wash hands.
        if (questSteps[5] && !completed)
        {
            completed = true;
            warningSystem.SetWarning("Gefeliciteerd je hebt Arogene Islolatie afgerond." , true, "Green");
        }        
    }
}
