using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropZone : MonoBehaviour {
	
	[SerializeField]
	private GameObject itemToDrop;
    private bool isDone = false;

    public void Onhover()
    {
        // On hover show ghostimage of currently selected item?

    }

    public void OffHover()
    {
        //?
    }


    public void dropItem(GameObject obj)
    {
        if (!obj) return;

        if (IsCorrectItem(obj))
        {
            isDone = true;
            Debug.Log("Dropped the correct item");
        }
    }

    private bool IsCorrectItem(GameObject obj)
    {
        if (obj == itemToDrop && isDone)
            return true;
        else
            return false;
    }
}
