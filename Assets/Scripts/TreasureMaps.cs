using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureMaps : MonoBehaviour
{
    PlayerController playerController;

    // List of possible treasures
    private List<string> treasures = new List<string> { "Gold coin", "Diamond", "Ruby", "Emerald", "Sapphire" };


    private void Start()
    {
        GameObject playerControllerObj = GameObject.Find("Player");
        playerController = playerControllerObj.GetComponent<PlayerController>();
    }

    // Function to generate a random piece of treasure
    private string GenerateTreasure()
    {
        int index = Random.Range(0, treasures.Count);
        return treasures[index];
    }

    // Function to dig at a specified location
    public void DigSuccess()
    {
        string treasure = GenerateTreasure();
        Debug.Log("Congratulations! You found a " + treasure + "!");
        playerController.digButton.SetActive(true);
        playerController.treasureDigButton.SetActive(false);
    }
    public void DigFail()
    {
        Debug.Log("Sorry, no treasure found at this location.");
    }

}