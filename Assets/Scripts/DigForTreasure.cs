using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DigForTreasure : MonoBehaviour
{
    public GameObject digBoatButton;
    public GameObject digFailButton;

    public GameObject smokeyBurst;

    public Transform spawnTreasurePoint; // The point where the treasure should spawn

    public Transform spawnSmokePoint;

    public GameObject boatPrefab;


    public void NoTreasureFound()
    {
        GameObject smoke = Instantiate(smokeyBurst, spawnSmokePoint.position, Quaternion.identity);

        Destroy(smoke, 2.0f);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("TreasureBoat"))
        {
            digBoatButton.SetActive (true);
            digFailButton.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("TreasureBoat"))
        {
            digBoatButton.SetActive(false);
            digFailButton.SetActive(true);
        }
    }

    public void TreasureIsFound()
    {
        // Spawn the treasure at the spawn point
        GameObject treasure = Instantiate(boatPrefab, spawnTreasurePoint.position, Quaternion.identity);

        GameObject smoke = Instantiate(smokeyBurst, spawnTreasurePoint.position, Quaternion.identity);

        digBoatButton.SetActive(false);

        Destroy(smoke, 2.0f);
    }


}



