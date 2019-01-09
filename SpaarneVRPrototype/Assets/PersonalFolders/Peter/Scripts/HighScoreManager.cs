using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class HighScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreTextQuestOne;
    public TextMeshProUGUI scoreTextQuestTwo;
    private string JSONPath = "/PlayerScores.json";
    [SerializeField]
    private List<ScoreValueObject> valueObjectList = new List<ScoreValueObject>();

    public GameObject keyboardInput;

    void Start()
    {
        valueObjectList = LoadData();
        DisplayHighScore();
    }

    private List<ScoreValueObject> LoadData()
    {
        // Load Data
        string filePath = Application.streamingAssetsPath + JSONPath;
        string jsonToLoad = File.ReadAllText(filePath);

        // string jsonToLoad = PlayerPrefs.GetString("Data");
        Debug.Log(jsonToLoad);
        if (jsonToLoad == "")
        {

            Debug.Log("error loading data");
        }
        //Load as Array
        ScoreValueObject[] _tempLoadListData = JSONHelper.FromJson<ScoreValueObject>(jsonToLoad);
        //Convert to List
        List<ScoreValueObject> loadListData = _tempLoadListData.OfType<ScoreValueObject>().ToList();
        return loadListData;
    }

    public void SaveData(ScoreValueObject obj)
    {
        if (SearchForPlayer(obj))
        {
            valueObjectList.Add(obj);

            
            string jsonToSave = JSONHelper.ToJson(valueObjectList.ToArray());
            Debug.Log(jsonToSave);
            //  PlayerPrefs.SetString("Data", jsonToSave);
            // PlayerPrefs.Save();
            string filePath = Application.streamingAssetsPath + JSONPath;
            Debug.Log("filepath is: "+filePath);
            File.WriteAllText(filePath, jsonToSave);
            Debug.Log("saved data in json");
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

        if (player.Score >= temp_Current)
        {
            return true;
        }

        return false;
    }

    public void DisplayHighScore()
    {
        if (!scoreTextQuestOne || !scoreTextQuestTwo) return;
        int maxChars = 8;
        string questOneString = "";
        string questTwoString = "";
        // give me a list of the highest ranking people in descending order
        //List<int> scoreList = new List<int>();
        var test = valueObjectList.OrderByDescending(i => i.Score);
        foreach (var VARIABLE in test)
        {
            if (VARIABLE.QuestNumber == 1)
            {
                questOneString += string.Format("{0,-8}", VARIABLE.PlayerName) + ": " + VARIABLE.Score + "\n";
                Debug.Log(questOneString);
            }
            else
            {
                questTwoString += string.Format("{0,-8}", VARIABLE.PlayerName) + ": " + VARIABLE.Score + "\n";
                Debug.Log(questTwoString);
            }
            // thing += VARIABLE.PlayerName + ": " + VARIABLE.Score + "\n";
           
            //Debug.Log(VARIABLE.PlayerName);
            //  Debug.Log(VARIABLE.Score);
        }
        scoreTextQuestOne.text = questOneString;
        scoreTextQuestTwo.text = questTwoString;
    }

    public void ShowKeyboardInput()
    {
        if (!keyboardInput) return;

        keyboardInput.SetActive(true);
    }

    public void InputScore(string name, int questID, int score)
    {
        ScoreValueObject newPlayer = new ScoreValueObject
        {
            PlayerName = name,
            QuestNumber = questID,
            Score = score
        };
        SaveData(newPlayer);
        Debug.Log("save succesful");
    }
}
