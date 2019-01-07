using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class KeyboardInput : MonoBehaviour {

	public List<Button> buttons = new List<Button>();

	string playerName = "";
	[SerializeField]
	private Text text;
	private bool firstPress = false;
	[SerializeField]
	private int maxAmountOfCharacters = 15;

	public ScoreSystem scoreSystem;

	private void Awake()
	{
		foreach(Button b in buttons)
		{
			b.onClick.AddListener(delegate { ButtonPress(b.name); });
		}
	}

	void ButtonPress(string button)
	{
		if (!firstPress)
		{
			text.text = "";
			firstPress = true;
		}

		if(button == "Backspace")
		{
			if (playerName.Length <= 0) return;

			playerName = playerName.Substring(0, playerName.Length - 1);
		} else
		if (button == "Enter")
		{
			Debug.Log("enter clicked");
			// ToDo: Submit Score to List
			if(playerName != "")
			{
				scoreSystem.SubmitScore(playerName);
                transform.gameObject.SetActive(false);
			}
		}else
		if (button == "Space")
		{
			if (playerName.Length < maxAmountOfCharacters)
				playerName += " ";
		}else
		{
			if(playerName.Length < maxAmountOfCharacters)
			playerName += button;
			Debug.Log(button + " clicked");
		}
		text.text = playerName;
	}
}
