using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingPinReset : MonoBehaviour
{
    public GameObject bowlingPinPrefab;
    public Transform respawnPinPoint;

    private GameObject[] spawnedBowlingPins;

    private bool isResetting = false; // Flag to track if resetting is in progress

    private void Update()
    {
        spawnedBowlingPins = GameObject.FindGameObjectsWithTag("BowlingPin");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CannonBall") && !isResetting)
        {
            isResetting = true; // Start resetting process

            foreach (GameObject pin in spawnedBowlingPins)
            {
                Destroy(pin, 15.0f);
            }

            Invoke("CleanUpPins", 16.0f);
        }
    }

    private void CleanUpPins()
    {
        foreach (GameObject pin in spawnedBowlingPins)
        {
            Destroy(pin);
        }

        Invoke("RespawnPins", 1.0f);
    }

    private void RespawnPins()
    {
        if (spawnedBowlingPins.Length == 0) // Check if no pins are present
        {
            GameObject newPin = Instantiate(bowlingPinPrefab, respawnPinPoint.position, Quaternion.identity);
        }

        isResetting = false; // Reset the flag
    }
}
