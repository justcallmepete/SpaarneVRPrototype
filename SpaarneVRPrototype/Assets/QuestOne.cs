using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        LastActivity = interactionManager.LastActivity;
        
        //Check if the person left the room with out washing hands. 
        if(!PersonP.inRoom && questSteps[1] && !questSteps[2] && !warned)
        {
            warningSystem.SetWarning("You left the room with out washing hands. High risk of being infected." , true, "Red");
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
                    warningSystem.SetWarning("You removed or didn't have a mask in the room. High risk of being infected." , true, "Red");
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
            warningSystem.SetWarning("You removed or didn't have a mask in the room. High risk of being infected." , true, "Red");
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
            else if (LastActivity != "Wash hands" && LastActivity != "Open door" &&  LastActivity != "Close door" && PersonP.inRoom)
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
                if (WashedHands.task && LastActivity == "Wash hands")
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
            warningSystem.SetWarning("Congratulations you finished Arogene Islolation." , true, "Green");
        }        
    }
}
