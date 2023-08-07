using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoatButtonTrigger : MonoBehaviour
{
    public Button button; // Reference to the button component

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water")) 
        {
            button.interactable = true; 
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            button.interactable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            button.interactable = false;
        }
    }
}
