using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingPinReset : MonoBehaviour
{
    public GameObject bowlingPinPrefab;
    public Transform respawnPinPoint;

    private GameObject[] spawnedBowlingPins; // Changed to an array to store multiple pins

    public GameObject[] deactivateObjects; // Array to hold the GameObjects you want to deactivate.
    public GameObject[] activateObjects; // Array to hold the bridge objects you want to activate.


    private void Update()
    {
        spawnedBowlingPins = GameObject.FindGameObjectsWithTag("BowlingPin");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CannonBall"))
        {
            foreach (GameObject pin in spawnedBowlingPins)
            {
                Destroy(pin, 15.0f);
            }

            Invoke("RespawnPins", 16.0f);

            // Deactivate the string of gameobjects upon trigger enter.
            foreach (GameObject deactivateObjects in deactivateObjects)
            {
                deactivateObjects.SetActive(false);
            }
        }
    }

    private void RespawnPins()
    {
        GameObject newPin = Instantiate(bowlingPinPrefab, respawnPinPoint.position, Quaternion.identity);

        // Enable all gameobjects in the string of activeObjects.
        foreach (GameObject activateObjects in activateObjects)
        {
            activateObjects.SetActive(true);
        }
    }
}
