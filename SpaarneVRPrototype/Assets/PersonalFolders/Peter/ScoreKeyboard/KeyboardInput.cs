using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class KeyboardInput : MonoBehaviour {

	public List<Button> buttons = new List<Button>();

	string PlayerName;
	[SerializeField]
	private Text text;
	private bool firstPress = false;

	GraphicRaycaster m_Raycaster;
	PointerEventData m_PointerEventData;
	EventSystem m_EventSystem;

	private void Awake()
	{
		foreach(Button b in buttons)
		{
			b.onClick.AddListener(delegate { ButtonPress(b.name); });
		}
	}

	private void Start()
	{
		//Fetch the Raycaster from the GameObject (the Canvas)
		m_Raycaster = GetComponent<GraphicRaycaster>();
		//Fetch the Event System from the Scene
		m_EventSystem = GetComponent<EventSystem>();
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
