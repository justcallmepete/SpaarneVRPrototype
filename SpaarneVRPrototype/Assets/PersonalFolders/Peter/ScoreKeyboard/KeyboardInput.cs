using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardInput : MonoBehaviour {

	public List<Button> buttons = new List<Button>();

	string PlayerName;
	[SerializeField]
	private Text text;
	private bool firstPress = false;

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
			if (PlayerName.Length <= 0) return;

			PlayerName = PlayerName.Substring(0, PlayerName.Length - 1);
		} else
		if (button == "Enter")
		{
			// ToDo: Submit Score to List
		}else
		if (button == "Space")
		{
			PlayerName += " ";
		}else
		{
			PlayerName += button;
		}
		text.text = PlayerName;
	}

}
