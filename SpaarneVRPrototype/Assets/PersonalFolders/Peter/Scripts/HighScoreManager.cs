using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class HighScoreManager : MonoBehaviour
{
   // public Text testthing;
    //public TextMeshProUGUI thingtwo;
    public TextMeshProUGUI scoreText;
    //public textmeshpro

    [SerializeField]
    private List<ScoreValueObject> valueObjectList = new List<ScoreValueObject>();

    void Start()
    {
      //  scoreText.text = "SFDKFHDJKAFHDKJFHDKJAHFJDKA";
        valueObjectList = LoadData();
        //ScoreValueObject laura = new ScoreValueObject();
        //laura.PlayerName = "Koen";
        //laura.Score = 100;
        //laura.QuestNumber = 1;
        //SaveData(laura);
        DisplayHighScore();
    }

    private List<ScoreValueObject> LoadData()
    {
        // Load Data
        string jsonToLoad = PlayerPrefs.GetString("Data");
        Debug.Log(jsonToLoad);
        if (jsonToLoad == "")
        {
            Debug.Log("error loading data");
        }
        //Load as Array
        ScoreValueObject[] _tempLoadListData = JSONHelper.FromJson<ScoreValueObject>(jsonToLoad);
        //Convert to List
        List<ScoreValueObject> loadListData = _tempLoadListData.OfType<ScoreValueObject>().ToList();
        //Print Data
        //for (int i = 0; i < loadListData.Count; i++)
        //{
        //    Debug.Log("Got: " + loadListData[i].PlayerName);
        //}
        return loadListData;
    }

    public void SaveData(ScoreValueObject obj)
    {
       // List<ScoreValueObject> loadListData = LoadData();

        if (SearchForPlayer(obj))
        {
            valueObjectList.Add(obj);

            string jsonToSave = JSONHelper.ToJson(valueObjectList.ToArray());
            PlayerPrefs.SetString("Data", jsonToSave);
            PlayerPrefs.Save();
        }
    }

    private bool SearchForPlayer(ScoreValueObject player)
    {
        int temp_Current = 0;

       // List<ScoreValueObject> loadListData = LoadData();
        // check if existingPlayer with same name exists
        foreach (ScoreValueObject obj in valueObjectList)
        {
            if (player.PlayerName == obj.PlayerName)
            {
                if (obj.Score > temp_Current)
                {
                    temp_Current = obj.Score;
                }
            }
        }

        if (player.Score > temp_Current)
        {
            return true;
        }

        return false;
    }

    public void DisplayHighScore()
    {
        string thing = "";
        // give me a list of the highest ranking people in descending order
        //List<int> scoreList = new List<int>();
        var test = valueObjectList.OrderByDescending(i => i.Score);
        foreach (var VARIABLE in test)
        {
            thing += VARIABLE.PlayerName+": "+VARIABLE.Score+"\n";
            Debug.Log(VARIABLE.PlayerName);
            Debug.Log(VARIABLE.Score);
        }
        scoreText.text = thing;
    }

}
