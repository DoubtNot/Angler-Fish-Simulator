using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileLaunch : MonoBehaviour
{
    public GameObject[] projectileTypes; // Array of different projectile types
    private GameObject currentProjectile; // Reference to the current projectile

    public float launchCooldown = 1.5f; // The cooldown period between each launch
    private bool canLaunch = true; // Variable to track if the player can launch a projectile

    public Button launchButton; // Reference to the UI button that launches the projectile


    public Transform spawnPoint; // The point where the projectile should spawn
    public float launchForce = 10f; // The force with which the projectile should be launched
    public float verticalForce = 2f; // The additional vertical force to apply

    public GameObject smokeyBurst;


    private void Start()
    {
        // Set the initial projectile as the current projectile
        currentProjectile = projectileTypes[0];
        currentProjectile.SetActive(true);

        // Make sure the listener is only added once
        launchButton.onClick.RemoveAllListeners();
        launchButton.onClick.AddListener(OnLaunchButtonClicked);
    }

    private void OnLaunchButtonClicked()
    {
        // Check if the player can launch a projectile
        if (canLaunch)
        {
            // Call the method to spawn and launch the projectile
            SpawnAndLaunchProjectile();

            // Start the cooldown timer
            StartCoroutine(StartCooldownTimer());

            // Disable the launch button during cooldown
            launchButton.interactable = false;
        }
    }

    private IEnumerator StartCooldownTimer()
    {
        // Set canLaunch to false to prevent further launches during the cooldown
        canLaunch = false;

        // Wait for the specified cooldown duration
        yield return new WaitForSeconds(launchCooldown);

        // Cooldown period has elapsed, allow the player to launch again
        canLaunch = true;

        // Enable the launch button after cooldown
        launchButton.interactable = true;
    }

    public void SpawnAndLaunchProjectile()
    {


        // Spawn the projectile at the spawn point
        GameObject projectile = Instantiate(currentProjectile, spawnPoint.position, Quaternion.identity);

        // Get the rigidbody component of the projectile
        Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();

        // Calculate the launch direction based on the rotation of the cannon
        Vector3 launchDirection = transform.forward + (transform.up * verticalForce);

        // Apply the launch force to the projectile
        projectileRigidbody.AddForce(launchDirection * launchForce, ForceMode.Impulse);

        GameObject smoke = Instantiate(smokeyBurst, spawnPoint.position, Quaternion.identity);

        Destroy(smoke, 2.0f);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Ammo"))
        {
            GameObject triggeredProjectile = collision.gameObject;
            string triggeredPrefabName = triggeredProjectile.name;

            GameObject matchingProjectile = FindMatchingProjectile(triggeredPrefabName);

            if (matchingProjectile != null)
            {
                currentProjectile.SetActive(false); // Disable the current projectile
                currentProjectile = matchingProjectile; // Set the new projectile as the current projectile
                currentProjectile.SetActive(true); // Activate the new projectile
            }

            Destroy(triggeredProjectile); // Destroy the collided GameObject
        }

        if (collision.gameObject.CompareTag("Bowling"))
        {
            launchForce = launchForce * 2;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Bowling"))
        {
            launchForce = 100f;
        }
    }

    private GameObject FindMatchingProjectile(string prefabName)
    {
        foreach (GameObject projectile in projectileTypes)
        {
            if (projectile.name == prefabName)
            {
                return projectile;
            }
        }

        return null; // Return null if no matching projectile is found
    }

}
