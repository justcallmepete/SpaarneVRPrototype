using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSettings : MonoBehaviour {
    public static GameSettings instance;
    public bool[] procedure = new bool[4];
    public bool[] guide = new bool[4];
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
            Destroy(this);
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
