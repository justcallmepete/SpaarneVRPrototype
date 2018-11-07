using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractionExitDoor : Interaction {
    public GameSettings gameSettings;
    public override void Start()
    {
        base.Start();
        gameSettings = GameObject.Find("GameSettings").GetComponent<GameSettings>();
        InteractionTaskB = "Leave Room";
    }

    public override void Handle()
    {
        base.Handle();
        bool guideSelected = false;
        bool procesSelected =  false;
        foreach (bool guide in gameSettings.guide)
        {
            if (guide)
            {
                guideSelected = true;
            }
        }
        foreach(bool proces in gameSettings.procedure)
        {
            if (proces)
            {
                procesSelected = true;
            }
        }
        if(guideSelected && procesSelected)
        {
            SceneManager.LoadScene("Hospital_Wing");
        }else if(!guideSelected && !procesSelected)
        {

        }else if(!guideSelected)
        {

        }else if (!procesSelected)
        {

        }
    }
}
