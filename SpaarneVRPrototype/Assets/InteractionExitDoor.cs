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
        InteractionTask = "Start infectie preventie training.";
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
            warningSystem.SetWarning("Selecteer een procedure en een speelstijl op het prikbord.", true,"Red");
        }else if(!guideSelected)
        {
            warningSystem.SetWarning("Selecteer een speelstijl op het prikbord.", true, "Red");
        }
        else if (!procesSelected)
        {
            warningSystem.SetWarning("Selecteer een procedure op het prikbord.", true, "Red");
        }
    }
}
