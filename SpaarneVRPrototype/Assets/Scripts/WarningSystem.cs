using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarningSystem : MonoBehaviour {
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

    public void SetWarning(string textMessage)
    {
        warningHolder.SetActive(true);
        Timer = 0f;
        fadeCol = 1f;
        warningText.text = textMessage;
        warningText.color = new Vector4(1f, 0f, 0f, fadeCol);

    }

}
