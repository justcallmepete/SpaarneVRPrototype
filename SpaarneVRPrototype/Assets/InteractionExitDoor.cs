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
        InteractionTask = "Enter isolation wing";
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
            warningSystem.SetWarning("Please select a Guide and Procedure with the Post it!", true,"Red");
        }else if(!guideSelected)
        {
            warningSystem.SetWarning("Please select a Guide with the Post it!", true, "Red");
        }
        else if (!procesSelected)
        {
            warningSystem.SetWarning("Please select a Procedure with the Post it!", true, "Red");
        }
    }
}
