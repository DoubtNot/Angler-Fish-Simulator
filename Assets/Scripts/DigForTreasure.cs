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

    public GameObject[] anglerfishTreasures; // Array of anglerfish treasure prefabs
    public GameObject[] boatTreasures; // Array of boat treasure prefabs
    public GameObject[] fishBarrelTreasures; // Array of the fish barrel treasure prefabs
    public GameObject[] shovelTreasures; // Array of shovel treasure prefabs
    public GameObject[] fishingPoleTreasures; // Array of Fishing Pole treasure prefabs
    public GameObject[] cannonTreasures; // Array of cannon treasure prefabs

    public bool isInAnglerfishTrigger = false;
    public bool isInBoatTrigger = false;
    public bool isInFishBarrelTrigger = false;
    public bool isInShovelTrigger = false;
    public bool isInFishingPoleTrigger = false;
    public bool isInCannonTrigger = false;

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
        if (collision.gameObject.CompareTag("TreasureAnglerfish"))
        {
            isInAnglerfishTrigger = true;
        }

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

        if (collision.gameObject.CompareTag("TreasureFishingPole"))
        {
            isInFishingPoleTrigger = true;
        }

        if (collision.gameObject.CompareTag("TreasureCannon"))
        {
            isInCannonTrigger = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("TreasureAnglerfish"))
        {
            isInAnglerfishTrigger = false;
        }

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

        if (collision.gameObject.CompareTag("TreasureFishingPole"))
        {
            isInFishingPoleTrigger = false;
        }

        if (collision.gameObject.CompareTag("TreasureCannon"))
        {
            isInCannonTrigger = false;
        }
    }

    public void DigForTreasureAction()
    {
        if (isInAnglerfishTrigger)
        {
            int randomIndex = Random.Range(0, anglerfishTreasures.Length);
            GameObject chosenAnglerfish = Instantiate(anglerfishTreasures[randomIndex], spawnSmokePoint.position, Quaternion.identity);

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

            isInAnglerfishTrigger = false;
        }

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


        if (isInFishingPoleTrigger)
        {
            int randomIndex = Random.Range(0, fishingPoleTreasures.Length);
            GameObject chosenFishingPole = Instantiate(fishingPoleTreasures[randomIndex], spawnSmokePoint.position, Quaternion.identity);

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

            isInFishingPoleTrigger = false;
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

        if (isInCannonTrigger)
        {
            int randomIndex = Random.Range(0, cannonTreasures.Length);
            GameObject chosenCannon = Instantiate(cannonTreasures[randomIndex], spawnSmokePoint.position, Quaternion.identity);

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

            isInCannonTrigger = false;
        }


        SpawnSmoke(); // Always spawn smoke
    }
}
