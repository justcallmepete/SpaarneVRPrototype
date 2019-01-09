using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSoundCompletion : MonoBehaviour
{
    public GameObject questOne;
    public GameObject questTwo;
    public AudioClip questSound;
    public AudioSource VRAudioPlayer;
    public AudioSource ComputerAudioPlayer;
    public AudioSource activeAudioPlayer;
    public List<bool> soundPlayed = new List<bool>();
    public List<bool> questSteps = new List<bool>();


    // Use this for initialization
    void Start ()
    {
		if (questTwo.activeInHierarchy)
        {
         questSteps= questTwo.GetComponent<QuestTwo>().questStepts;
        }
        else
        {
            questSteps = questOne.GetComponent<QuestOne>().questSteps;
           
        }
       // Debug.Log(questSteps.Count);
     
        if (VRAudioPlayer.isActiveAndEnabled)
        {
            activeAudioPlayer = VRAudioPlayer;
        }
        else
        {
            activeAudioPlayer = ComputerAudioPlayer;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (soundPlayed.Count == 0) {
            for (int i = 0; i < questSteps.Count; i++)
            {
                soundPlayed.Add(false);
            }
        }
        else
        {

        

        for (int i = 0; i < questSteps.Count; i++)
        {
            if (questSteps[i] && !soundPlayed[i])
            {
                activeAudioPlayer.clip = questSound;
                Debug.Log(activeAudioPlayer.clip);
                activeAudioPlayer.Play();
                Debug.Log(activeAudioPlayer.isPlaying);
                soundPlayed[i] = true;
            }
        }
        }
    }
}
