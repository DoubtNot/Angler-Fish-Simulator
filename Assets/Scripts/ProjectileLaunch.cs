using UnityEngine;
using UnityEngine.UI;

public class ProjectileLaunch : MonoBehaviour
{
    public GameObject projectilePrefab; // Reference to the projectile prefab
    public Transform spawnPoint; // The point where the projectile should spawn
    public float launchForce = 10f; // The force with which the projectile should be launched
    public Button launchButton; // Reference to the UI button

    public GameObject smokeyBurst;


    private void Start()
    {
        launchButton.onClick.AddListener(SpawnAndLaunchProjectile);
    }

    private void SpawnAndLaunchProjectile()
    {
        // Spawn the projectile at the spawn point
        GameObject projectile = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);

        // Get the rigidbody component of the projectile
        Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();

        // Calculate the launch direction based on the rotation of the cannon
        Vector3 launchDirection = transform.forward;

        // Apply the launch force to the projectile
        projectileRigidbody.AddForce(launchDirection * launchForce, ForceMode.Impulse);

        GameObject smoke = Instantiate(smokeyBurst, spawnPoint.position, Quaternion.identity);

        Destroy(smoke, 2.0f);
    }
}
