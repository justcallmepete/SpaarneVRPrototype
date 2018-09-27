using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTeleport : MonoBehaviour
{
    public bool TeleportEnabled
    {
        get { return teleportEnabled; }
    }

    public Bezier bezier;
    public GameObject teleportSprite;

    private bool teleportEnabled;
    private bool firstClick;
    private bool fixedSpotFound;
    private float firstClickTime;
    private float doubleClickTimeLimit = 0.5f;

    float alpha = 1.0f;

    void Start()
    {
        teleportEnabled = false;
        fixedSpotFound = false;
        firstClick = false;
        firstClickTime = 0f;
        teleportSprite.SetActive(false);
    }

    void Update()
    {
        UpdateTeleportEnabled();

        if (teleportEnabled)
        {
            HandleBezier();
            HandleTeleport();
        }
    }

    // On double-click, toggle teleport mode on and off.
    void UpdateTeleportEnabled()
    {

        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        { // The trigger is pressed.
            Debug.Log("PRIMARY TRIGGER PRESSED");
            if (!firstClick)
            { // The first click is detected.
                firstClick = true;
                firstClickTime = Time.unscaledTime;
            }
            else
            { // The second click detected, so toggle teleport mode.
                firstClick = false;
                ToggleTeleportMode();
            }
        }

        if (Time.unscaledTime - firstClickTime > doubleClickTimeLimit)
        { // Time for the double click has run out.
            firstClick = false;
        }
    }

    void HandleTeleport()
    {
        if (bezier.fixedEndPointDetected)
        {
            Vector3 endSpot = bezier.fixedEndSpot;
            teleportSprite.SetActive(true);
            teleportSprite.transform.position = bezier.fixedEndSpot;
            if (OVRInput.GetDown(OVRInput.Button.One)) // Teleport to the position.
                TeleportToPosition(bezier.fixedEndSpot);
        }
        else
        {
            teleportSprite.SetActive(false);
        }
    }

    void TeleportToPosition(Vector3 teleportPos)
    {
        gameObject.transform.position = teleportPos + Vector3.up * 0.5f;
    }

    // Optional: use the touchpad to move the teleport point closer or further.
    void HandleBezier()
    {
        Vector2 touchCoords = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);

        if (Mathf.Abs(touchCoords.y) > 0.8f)
        {
            bezier.ExtensionFactor = touchCoords.y > 0f ? 1f : -1f;
        }
        else
        {
            bezier.ExtensionFactor = 0f;
        }
    }

    void ToggleTeleportMode()
    {
        teleportEnabled = !teleportEnabled;
        bezier.ToggleDraw(teleportEnabled);
        if (!teleportEnabled)
        {
            teleportSprite.SetActive(false);
        }
    }

}
