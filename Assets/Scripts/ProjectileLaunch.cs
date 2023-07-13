using UnityEngine;
using UnityEngine.UI;

public class ProjectileLaunch : MonoBehaviour
{
    public GameObject[] projectileTypes; // Array of different projectile types
    private GameObject currentProjectile; // Reference to the current projectile


    public Transform spawnPoint; // The point where the projectile should spawn
    public float launchForce = 10f; // The force with which the projectile should be launched

    public GameObject smokeyBurst;


    private void Start()
    {
        // Set the initial projectile as the current projectile
        currentProjectile = projectileTypes[0];
        currentProjectile.SetActive(true);
    }

    public void SpawnAndLaunchProjectile()
    {


        // Spawn the projectile at the spawn point
        GameObject projectile = Instantiate(currentProjectile, spawnPoint.position, Quaternion.identity);

        // Get the rigidbody component of the projectile
        Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();

        // Calculate the launch direction based on the rotation of the cannon
        Vector3 launchDirection = transform.forward;

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
