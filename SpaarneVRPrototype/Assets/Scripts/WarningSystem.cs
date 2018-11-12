using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarningSystem : MonoBehaviour {
    public GameSettings gameSettings;
    public GameObject warningHolder;
    public Text warningText;
    public GameObject Holder1;
    public GameObject Holder2;
    [SerializeField]
    private float Timer;
    private float fadeCol;

    private void Start()
    {
        

        if (Holder1.activeInHierarchy)
        {
            warningHolder = Holder1;
            warningText = Holder1.transform.GetChild(0).transform.GetComponent<Text>();
        }
        else if(Holder2.activeInHierarchy){
            warningHolder = Holder2;
            warningText = Holder2.transform.GetChild(0).transform.GetComponent<Text>();

        }
        Timer = 0;
        warningText.text = "test";
        Timer = 0f;
        fadeCol = 1f;
        if (GameObject.Find("GameSettings").transform.GetComponent<GameSettings>())
        {
            gameSettings = GameObject.Find("GameSettings").transform.GetComponent<GameSettings>();
        }
    }

    private void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= 1)
        {
            fadeCol -= Time.deltaTime * 0.25f;
            warningText.color = new Vector4(1f, 0f, 0f, fadeCol);
        }
        if (Timer >= 5)
        {
            warningHolder.SetActive(false);
        }

    }

    public void SetWarning(string textMessage, bool quest = false)
    {
        if (gameSettings != null)
        {
            if (gameSettings.guide[0])
            {
                warningHolder.SetActive(false);
            }
            else if (gameSettings.guide[1])
            {
                warningHolder.SetActive(true);
                if (quest)
                {
                    warningText.text = "You made a mistake in the protocol.";
                }
                else
                {
                    warningText.text = "That wont work.";
                }
            }
            else if (gameSettings.guide[2] || gameSettings.guide[3])
            {
                warningHolder.SetActive(true);
                warningText.text = textMessage;
            }
        }
        else
        {
            warningHolder.SetActive(true);
            warningText.text = textMessage;
        }
        Timer = 0f;
        fadeCol = 1f;   
        warningText.color = new Vector4(1f, 0f, 0f, fadeCol);
    }

}
