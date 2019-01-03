using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class HighScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    [SerializeField]
    private List<ScoreValueObject> valueObjectList = new List<ScoreValueObject>();

	public GameObject keyboardInput;

    void Start()
    {
		//ScoreValueObject test = new ScoreValueObject();
		//test.PlayerName = "Player 1";
		//test.QuestNumber = 1;
		//test.Score = 500;
		//SaveData(test);
		valueObjectList = LoadData();
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
        return loadListData;
    }

    public void SaveData(ScoreValueObject obj)
    {
        if (SearchForPlayer(obj))
        {
            valueObjectList.Add(obj);

            string jsonToSave = JSONHelper.ToJson(valueObjectList.ToArray());
            PlayerPrefs.SetString("Data", jsonToSave);
            PlayerPrefs.Save();
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
		if (!scoreText) return;

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
