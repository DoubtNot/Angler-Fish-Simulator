using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DigForTreasure : MonoBehaviour
{
    public GameObject digButton;
    public GameObject smokeyBurst;
    public Transform spawnSmokePoint;
    public GameObject[] boatTreasures; // Array of boat treasure prefabs

    public bool isInBoatTrigger = false;

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
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("TreasureBoat"))
        {
            isInBoatTrigger = false;
        }
    }

    public void DigForTreasureAction()
    {
        if (isInBoatTrigger)
        {
            int randomIndex = Random.Range(0, boatTreasures.Length);
            GameObject chosenBoat = Instantiate(boatTreasures[randomIndex], spawnSmokePoint.position, Quaternion.identity);

            // Deactivate the object with the "TreasureBoat" tag
            GameObject treasureBoat = GameObject.FindGameObjectWithTag("TreasureBoat");
            if (treasureBoat != null)
            {
                treasureBoat.SetActive(false);
            }

            isInBoatTrigger = false;
        }

        SpawnSmoke(); // Always spawn smoke
    }


}
