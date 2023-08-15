using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DigForTreasure : MonoBehaviour
{
    public GameObject digButton;
    public GameObject smokeyBurst;
    public Transform spawnSmokePoint;
    public GameObject noTreasureMapText;

    public GameObject[] treasureMaps; // Array of the "X marks the spot" drawings that appear in front of the treasure map object
    public GameObject[] treasureTriggers; // Array of the colliders that set off the bools below ("isIn...Trigger")

    public GameObject[] boatTreasures; // Array of boat treasure prefabs
    public GameObject[] fishBarrelTreasures; // Array of the fish barrel treasure prefabs
    public GameObject[] shovelTreasures; // Array of shovel treasure prefabs

    public bool isInBoatTrigger = false;
    public bool isInFishBarrelTrigger = false;
    public bool isInShovelTrigger = false;

    public void Start()
    {
        digButton.SetActive(true);
    }

    public void SpawnSmoke()
    {
        GameObject smoke = Instantiate(smokeyBurst, spawnSmokePoint.position, Quaternion.identity);
        Destroy(smoke, 2.0f);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("TreasureBoat"))
        {
            isInBoatTrigger = true;
        }

        if (collision.gameObject.CompareTag("TreasureShovel"))
        {
            isInShovelTrigger = true;
        }

        if (collision.gameObject.CompareTag("TreasureFishBarrel"))
        {
            isInFishBarrelTrigger = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("TreasureBoat"))
        {
            isInBoatTrigger = false;
        }

        if (collision.gameObject.CompareTag("TreasureShovel"))
        {
            isInShovelTrigger = false;
        }

        if (collision.gameObject.CompareTag("TreasureFishBarrel"))
        {
            isInFishBarrelTrigger = false;
        }
    }

    public void DigForTreasureAction()
    {
        if (isInBoatTrigger)
        {
            int randomIndex = Random.Range(0, boatTreasures.Length);
            GameObject chosenBoat = Instantiate(boatTreasures[randomIndex], spawnSmokePoint.position, Quaternion.identity);

            // Deactivate every object in the treasureMaps array
            foreach (GameObject treasureMap in treasureMaps)
            {
                treasureMap.SetActive(false);
            }

            // Deactivate every object in the treasureTriggers array
            foreach (GameObject treasureTrigger in treasureTriggers)
            {
                treasureTrigger.SetActive(false);
            }

            noTreasureMapText.SetActive(true);

            isInBoatTrigger = false;
        }

        if (isInFishBarrelTrigger)
        {
            int randomIndex = Random.Range(0, fishBarrelTreasures.Length);
            GameObject chosenFishBarrel = Instantiate(fishBarrelTreasures[randomIndex], spawnSmokePoint.position, Quaternion.identity);

            // Deactivate every object in the treasureMaps array
            foreach (GameObject treasureMap in treasureMaps)
            {
                treasureMap.SetActive(false);
            }

            // Deactivate every object in the treasureTriggers array
            foreach (GameObject treasureTrigger in treasureTriggers)
            {
                treasureTrigger.SetActive(false);
            }

            noTreasureMapText.SetActive(true);

            isInFishBarrelTrigger = false;
        }

        if (isInShovelTrigger)
        {
            int randomIndex = Random.Range(0, shovelTreasures.Length);
            GameObject chosenShovel = Instantiate(shovelTreasures[randomIndex], spawnSmokePoint.position, Quaternion.identity);

            // Deactivate every object in the treasureMaps array
            foreach (GameObject treasureMap in treasureMaps)
            {
                treasureMap.SetActive(false);
            }

            // Deactivate every object in the treasureTriggers array
            foreach (GameObject treasureTrigger in treasureTriggers)
            {
                treasureTrigger.SetActive(false);
            }

            noTreasureMapText.SetActive(true);

            isInShovelTrigger = false;
        }

        SpawnSmoke(); // Always spawn smoke
    }
}
