
using UnityEngine;
using UnityEngine.UI;


public class DrawOnTopScript : MonoBehaviour {
    public bool startCheck = false;
    public UnityEngine.Rendering.CompareFunction comparison = UnityEngine.Rendering.CompareFunction.Always;

    public bool apply = false;

    private void Update()
    {
        if (startCheck == false)
        {
            startCheck = true;
            Image image = GetComponent<Image>();
            Material existingGlobalMat = image.materialForRendering;
            Material updatedMaterial = new Material(existingGlobalMat);
            updatedMaterial.SetInt("unity_GUIZTestMode", (int)comparison);
            image.material = updatedMaterial;
        }
    }
}