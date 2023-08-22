using UnityEngine;
using UnityEngine.UI;

public class ChangeMaterialButton : MonoBehaviour
{
    public MeshRenderer objectToChange; // Drag the MeshRenderer component here in the Inspector
    public Material newMaterial;        // Drag the new material here in the Inspector
    public GameObject objectToActivate; // Drag the GameObject to activate here in the Inspector

    private GameObject treasureBoat;
    private bool hasFoundTreasureBoat = false;

    private void Update()
    {
        if (!hasFoundTreasureBoat)
        {
            CheckAndActivateObject();
        }
    }

    private void CheckAndActivateObject()
    {
        if (treasureBoat == null)
        {
            treasureBoat = GameObject.Find("TreasureBoat(Clone)");
        }

        if (treasureBoat != null)
        {
            objectToActivate.SetActive(true);
            hasFoundTreasureBoat = true; // Set the flag to stop further checking
        }
    }

    public void ChangeMaterial()
    {
        if (objectToChange != null && newMaterial != null)
        {
            objectToChange.material = newMaterial;
        }
        else
        {
            Debug.LogWarning("MeshRenderer or new material is not set.");
        }
    }
}
