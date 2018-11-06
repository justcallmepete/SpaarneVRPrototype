using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectZoneSpawner : MonoBehaviour {

    public InteractableObject ItemToSpawn;

    private int currentIndex = 0;
    private int limit = 5;

   public Transform spawnPosition;

    private void Start()
    {
        Instantiate(ItemToSpawn, spawnPosition, false);
    }

    public void OnTriggerExit(Collider other)
    {
        InteractableObject interactable;
        if (other.GetComponent<InteractableObject>()) {
            interactable = other.GetComponent<InteractableObject>();
        } else
        {
            interactable = null;
        }
        if (interactable && !interactable.hasLeftZone && currentIndex < limit)
        {
                Instantiate(ItemToSpawn, spawnPosition, false);
                currentIndex++;
            interactable.hasLeftZone = true;
          //  interactable.transform.SetParent(null);
            interactable = null;
        }
    }
}