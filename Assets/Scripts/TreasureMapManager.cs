using UnityEngine;
using UnityEngine.UI;

public class TreasureMapManager : MonoBehaviour
{
    public GameObject treasureMapObject; // This is the "X marks the spot" drawing that we dont want to deactive

    public GameObject[] treasureMaps; // Array of the "X marks the spot" drawings that appear in front of the treasure map object that you want to deactivate (all but the selected one)

    public void OnAcceptButtonClicked()
    {
        treasureMapObject.SetActive(true);

        // Deactivate every object in the treasureMaps array
        foreach (GameObject treasureMap in treasureMaps)
        {
            treasureMap.SetActive(false);
        }
    }
}
