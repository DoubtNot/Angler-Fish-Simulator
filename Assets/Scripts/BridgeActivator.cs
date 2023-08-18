using UnityEngine;
using UnityEngine.UI;

public class BridgeActivator : MonoBehaviour
{
    public GameObject[] activateObjects; // Array to hold the bridge objects you want to activate.
    public Button[] uiButtons; // Array to hold the UI buttons you want to interact with.
    public GameObject[] deactivateObjects; // Array to hold the GameObjects you want to deactivate upon trigger enter.

    public GameObject[] onExitDeactivateObjects; //  Array to hold the GameObjects you want to deactivate upon trigger exit.

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
            // Enable all gameobjects in the string of activeObjects.
            foreach (GameObject activateObjects in activateObjects)
            {
                activateObjects.SetActive(true);
            }

            // Enable all UI buttons once the player enters the trigger.
            foreach (Button button in uiButtons)
            {
                button.interactable = true;
            }

            // Deactivate the string of gameobjects upon trigger enter.
            foreach (GameObject deactivateObjects in deactivateObjects)
            {
                deactivateObjects.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Deactivate the string of gameobjects upon trigger exit.
            foreach (GameObject onExitDeactivateObjects in onExitDeactivateObjects)
            {
                onExitDeactivateObjects.SetActive(false);
            }
        }
    }
}
