using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarningSystem : MonoBehaviour {
    public GameObject warningHolder;
    public Text warningText;
    private float Timer;
    private float fadeCol;

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
