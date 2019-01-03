using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickExample : MonoBehaviour
{

	private Camera viewCamera;

	public Button currentButton;
	private EventSystem eventSystem;

	private void Start()
	{
		viewCamera = GetComponent<Camera>();
		eventSystem = EventSystem.current;
	}

	private void Update()
	{
		UpdateCursor();

		if(Input.GetKeyDown(KeyCode.P))
		{
			if (currentButton)
			currentButton.onClick.Invoke();
		}
	}

	private void UpdateCursor()
	{
		// Create a gaze ray pointing forward from the camera
		Ray ray = new Ray(viewCamera.transform.position, viewCamera.transform.rotation * Vector3.forward);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 500f))
		{
			// If the ray hits something, set the position to the hit point
			// and rotate based on the normal vector of the hit
			if (hit.transform.GetComponent<Button>())
			{
				currentButton = hit.transform.GetComponent<Button>();
				currentButton.Select();
			}
			if (currentButton && hit.transform.gameObject != currentButton.gameObject)
			{
				eventSystem.SetSelectedGameObject(null);
			}
		}
		else
		{
			if (currentButton)
			{
				eventSystem.SetSelectedGameObject(null);
			}
		}

	}



}
