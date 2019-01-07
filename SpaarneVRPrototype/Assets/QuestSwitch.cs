using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSwitch : MonoBehaviour {
    public List<GameObject> quests = new List<GameObject>();
    public List<GameObject> questsCanvasVR = new List<GameObject>();
    public List<GameObject> questsCanvasPC = new List<GameObject>();
    public GameSettings gameSettings;
    public int manualQuest;
    // Use this for initialization
    void Start () {
        if (GameObject.Find("GameSettings").transform.GetComponent<GameSettings>())
        {
            gameSettings = GameObject.Find("GameSettings").transform.GetComponent<GameSettings>();

            for (int i = 0; i < quests.Count; i++)
            {
                if (gameSettings.procedure[i])
                {
                    quests[i].SetActive(true);
                    questsCanvasVR[i].SetActive(true);
                    questsCanvasPC[i].SetActive(true);
                }
                else
                {
                    quests[i].SetActive(false);
                    questsCanvasVR[i].SetActive(false);
                    questsCanvasPC[i].SetActive(false);
                }
            }

        }else
        {
            for (int i = 0; i < quests.Count; i++)
            {
                    quests[i].SetActive(false);
                    questsCanvasVR[i].SetActive(false);
                    questsCanvasPC[i].SetActive(false);
            }
            quests[manualQuest].SetActive(true);
            questsCanvasVR[manualQuest].SetActive(true);
            questsCanvasPC[manualQuest].SetActive(true);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
