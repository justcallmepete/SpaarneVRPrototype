using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WarningSystem : MonoBehaviour {
    public GameSettings gameSettings;
    public GameObject warningHolder;
    public Text warningText;
    public Image warningImage;
    public GameObject HolderPC;
    public GameObject HolderVR;
    public bool gotHolder = false;
    [SerializeField]
    private float Timer;
    private float fadeCol;
    private float fadeColI;
    private void Start()
    { 
        Timer = 6f;
        fadeCol = 1f;
        if (GameObject.Find("GameSettings"))
        {
            gameSettings = GameObject.Find("GameSettings").transform.GetComponent<GameSettings>();
        }
    }

    private void Update()
    {
        if (!gotHolder)
        {
            if (HolderPC.activeInHierarchy)
            {
                gotHolder = true;
                warningHolder = HolderPC;
                warningImage = HolderPC.transform.GetChild(0).transform.GetComponent<Image>();
                warningText = HolderPC.transform.GetChild(1).transform.GetComponent<Text>();
            }
            else if (HolderVR.activeInHierarchy)
            {
                gotHolder = true;
                warningHolder = HolderVR;
                warningImage = HolderPC.transform.GetChild(0).transform.GetComponent<Image>();
                warningText = HolderVR.transform.GetChild(1).transform.GetComponent<Text>();

            }
        }
        else
        {
            Timer += Time.deltaTime;
            if (Timer >= 1)
            {
                fadeCol -= Time.deltaTime * 0.25f;
                fadeColI -= Time.deltaTime * 0.15f;
                warningText.color = new Vector4(warningText.color.r, warningText.color.g, warningText.color.b, fadeCol);
                warningImage.color = new Vector4(Color.white.r, Color.white.g, Color.white.b, fadeColI);
            }
            if (Timer >= 5)
            {
                warningHolder.SetActive(false);
            }
        }

    }

    public void SetWarning(string textMessage, bool quest = false, string col = "Spaarne")
    {
        Timer = 0f;
        fadeCol = 1f;
        fadeColI = 0.6f;
        warningImage.color = new Vector4(Color.white.r,Color.white.g,Color.white.b,fadeColI);
        if (col == "Red")
        {
            warningText.material.color = new Vector4(Color.red.r, Color.red.g, Color.red.b, fadeCol);
            warningText.color = new Vector4(Color.red.r, Color.red.g, Color.red.b, 0.65f);
        }
        else if (col == "Green")
        {
            warningText.material.color = new Vector4(0f, 1f, 0f, fadeCol);
            warningText.color = new Vector4(0f, 1f, 0f, fadeCol);
        }
        else
        {
            warningText.material.color = new Vector4(29f / 255f, 156f / 255f, 155f / 255f, fadeCol);
            warningText.color = new Vector4(29f / 255f, 156f / 255f, 155f / 255f, fadeCol);
        }

        if (gameSettings != null && SceneManager.GetActiveScene().name != "MainMenu")
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
     

    }

}
