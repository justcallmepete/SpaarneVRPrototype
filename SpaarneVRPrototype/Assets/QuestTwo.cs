﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTwo : MonoBehaviour {
    
    public InteractionManager interactionManager;
    public WarningSystem warningSystem;

    public PersonPosition personsPos;

    public SingleVariable gloves;
    public SingleVariable apron;
    public SingleVariable washedHands;

    public List<bool> questStepts = new List<bool>();

    public bool warned = false;

	void Start ()
    {
        for (int i = 0; i < 8; i++)
        {
            questStepts.Add(false);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (warned)
        {
            if (!questStepts[0] && questStepts[1] || !questStepts[0] && !questStepts[1] || !questStepts[0] && questStepts[1])
            {
                if (personsPos.inRoom || personsPos.inTube)
                {
                    warned = true;
                    warningSystem.SetWarning("You removed or dindt have a apron and/or gloves in the room. High risk of being infected.", true, "Red");
                }
                else if (apron.task && !questStepts[0])
                {
                    questStepts[0] = true;
                }
                else if (gloves.task && !questStepts[1])
                {
                    questStepts[1] = true;
                }
            }
            else if (!questStepts[2])
            {
                if (personsPos.inRoom || personsPos.inTube)
                {
                    questStepts[2] = true;
                }
            }
            else if (!questStepts[3])
            {
                if (personsPos.inTube && !personsPos.inRoom)
                {
                    questStepts[3] = true;
                }
            }
            else if (!questStepts[4] && !questStepts[5] || questStepts[4] && !questStepts[5])
            {
                if (personsPos.inRoom && !gloves.task || personsPos.inRoom && !apron.task)
                {
                    warned = true;
                    warningSystem.SetWarning("You cant go back into the room with out the right equipment. High risk of being infected.", true, "Red");
                }
                else if (!personsPos.inTube && !personsPos.inRoom)
                {
                    warned = true;
                    warningSystem.SetWarning("You cant leave the room with your isolation clothing still on. High risk of being infected.", true, "Red");
                }
                else if (!questStepts[4] && !gloves.task)
                {
                    questStepts[4] = true;
                }
                else if (!questStepts[4] && !apron.task)
                {
                    warned = true;
                    warningSystem.SetWarning("You cant remove the apron before the gloves. High risk of being infected.", true, "Red");
                }
                else if (questStepts[4] && !apron.task)
                {
                    questStepts[5] = true;
                }
            }
            else if (!questStepts[6])
            {
                if (personsPos.inRoom)
                {
                    warned = true;
                    warningSystem.SetWarning("You cant go back into the room with out the right equipment. High risk of being infected.", true, "Red");
                }
                else if (!personsPos.inTube && !personsPos.inRoom)
                {
                    warned = true;
                    warningSystem.SetWarning("You cant leave the room with out washing hands. High risk of being infected.", true, "Red");
                }
                else if (!questStepts[6] && washedHands.task)
                {
                    questStepts[6] = true;
                }
            }else if (!questStepts[7])
            {
                if (!personsPos.inRoom && !personsPos.inTube)
                {
                    questStepts[7] = true;
                }
                else if (personsPos.inRoom)
                {
                    warned = true;
                    warningSystem.SetWarning("You cant enter the room with out the rigtht equipment. High risk of being infected.", true, "Red");
                }
            }else if (questStepts[7])
            {
                warningSystem.SetWarning("Congratulations you finished Contact Islolation.", true, "Green");

            }
        }
	}
}
