using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInactiveTrigger : MonoBehaviour
{
    public GameObject[] activateObjects; // Array to hold the bridge objects you want to deactivate.


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject activateObjects in activateObjects)
            {
                activateObjects.SetActive(false);
            }
        }
    }


}
