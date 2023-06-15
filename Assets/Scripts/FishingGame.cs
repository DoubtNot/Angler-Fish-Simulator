using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishingGame : MonoBehaviour
{
    public GameObject[] fishPrefabs; // Array of fish prefabs
    private GameObject currentFish; // Current spawned fish
    public GameObject catchButton; // Reference to the catch button
    public GameObject castButton;
    public GameObject fishingLine;

    public Transform spawnPoint; // Reference to the end of the fishing fish spawn
    public Transform waterCollider; // Reference to the water collider

    public float minWaitTime = 5f; // Minimum waiting time before fish spawns
    public float maxWaitTime = 10f; // Maximum waiting time before fish spawns
    private float waitTime = 0f; // Current waiting time
    public float launchForce = 10f; // The force with which the projectile should be launched


    private bool isCounting = false; // Flag to check if counting before fish spawn


    private void Start()
    {
        catchButton.SetActive (false);
    }

    private void Update()
    {
        if (isCounting)
        {
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                catchButton.SetActive (true);
                isCounting = false;

            }
        }
    }

    public void castLine()
    {
        fishingLine.SetActive(true);
        castButton.SetActive(false);

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == waterCollider)
        {
            isCounting = true;
            waitTime = Random.Range(minWaitTime, maxWaitTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the object you want to deactivate the fishing line
        if (collision.gameObject.CompareTag("Land"))
        {
            // Deactivate the fishing line object
            fishingLine.SetActive(false);
            castButton.SetActive(true);
        }
    }

    // Call this method when the player successfully catches a fish
    public void CatchFish()
    {
        catchButton.SetActive(false);
        castButton.SetActive(true);
        fishingLine.SetActive(false);

        SpawnFish();
    }

    private void SpawnFish()
    {
        int randomIndex = Random.Range(0, fishPrefabs.Length);
        currentFish = Instantiate(fishPrefabs[randomIndex], spawnPoint.position, Quaternion.identity);

        Vector3 launchDirection = -transform.forward; //shoots the fish back towards player
        Rigidbody projectileRigidbody = currentFish.GetComponent<Rigidbody>();
        projectileRigidbody.AddForce(launchDirection * launchForce, ForceMode.Impulse);

    }

    public void RotateObject()
    {
        // Set the desired rotation angles
        float targetAngleX = -40.584f; // Replace with your desired angle on the X-axis
        float targetAngleY = 0f;  // Replace with your desired angle on the Y-axis
        float targetAngleZ = 0f;  // Replace with your desired angle on the Z-axis

        // Create a new Vector3 with the desired rotation angles
        Vector3 newRotation = new Vector3(targetAngleX, targetAngleY, targetAngleZ);

        // Apply the new rotation to the object
        fishingLine.transform.eulerAngles = newRotation;
    }

}

