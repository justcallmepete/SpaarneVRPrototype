using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSettings : MonoBehaviour {
    public static GameSettings instance;
    public bool[] procedure = new bool[4];
    public bool[] guide = new bool[4];

    [SerializeField]
    private Vector3 backFromRoomPos;

    // Use this for initialization
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if(instance != this)
        {
            GameObject intro = GameObject.Find("Introduction");
            IntroHandler handler = intro.GetComponent<IntroHandler>();
            handler.done = true;
            handler.firstmessage = true;
            handler.controller.SetActive(true);
            GameObject player = GameObject.Find("Player");
            player.transform.position = backFromRoomPos;
            Destroy(this);
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
