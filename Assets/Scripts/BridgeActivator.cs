using UnityEngine;
using UnityEngine.UI;

public class BridgeActivator : MonoBehaviour
{
    public GameObject[] activateObjects; // Array to hold the bridge objects you want to activate.
    public Button[] uiButtons; // Array to hold the UI buttons you want to interact with.

    public GameObject[] deactivateObjects;

    private void Start()
    {
        // Set all UI buttons as not interactable by default.
        foreach (Button button in uiButtons)
        {
            button.interactable = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject activateObjects in activateObjects)
            {
                activateObjects.SetActive(true);
            }

            // Enable all UI buttons once the player enters the trigger.
            foreach (Button button in uiButtons)
            {
                button.interactable = true;
            }
        }
    }
}
