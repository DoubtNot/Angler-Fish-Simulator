using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject projectilePrefab; // The prefab of the projectile to fire.
    public Transform firePoint; // The position from which projectiles will be fired.
    public float firingRange = 10f; // The range within which the enemy will start firing at the player.
    public float innerRange = 3f; // The distance at which the enemy will start moving away from the player.
    public float stoppingDistance = 5f; // The distance at which the enemy will stop moving towards the player.
    public float fireRate = 1f; // The time delay between each projectile fired.
    public float launchForce = 10f; // The force with which the projectile is launched.
    public float chaseSpeed = 3f; // The speed at which the enemy chases the player.
    public float retreatSpeed = 2f; // The speed at which the enemy retreats from the player.

    public float destroyEnemyAtRange = 10f; // Range at which the enemies will automatically be destroyed if player is not within.

    private GameObject player; // Reference to the player GameObject.
    private float nextFireTime; // Time to track the next firing.

    private void Start()
    {
        // Find the GameObject with the "Player" tag in the scene.
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("Player object not found. Make sure the player has the tag 'Player'.");
        }
    }

    private void Update()
    {
        if (player != null)
        {
            // Calculate the distance between the enemy and the player.
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            if (distanceToPlayer <= firingRange)
            {
                // If the player is within firing range, rotate to face the player.
                Vector3 targetDirection = player.transform.position - transform.position;
                targetDirection.y = 0f; // Keep the enemy upright.
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);

                // Retreat from the player if they get too close.
                if (distanceToPlayer <= innerRange)
                {
                    Vector3 retreatDirection = transform.position - player.transform.position;
                    retreatDirection.y = 0f; // Keep the enemy on the same plane as the player.
                    transform.position += retreatDirection.normalized * retreatSpeed * Time.deltaTime;
                }
                // Otherwise, chase the player if they are outside the "stoppingDistance."
                else if (distanceToPlayer > stoppingDistance)
                {
                    Vector3 chaseDirection = player.transform.position - transform.position;
                    chaseDirection.y = 0f; // Keep the enemy on the same plane as the player.
                    transform.position += chaseDirection.normalized * chaseSpeed * Time.deltaTime;
                }

                // If the player is within firing range, start firing projectiles.
                if (Time.time >= nextFireTime)
                {
                    FireProjectile();
                    nextFireTime = Time.time + fireRate;
                }
            }

            if (distanceToPlayer > destroyEnemyAtRange)
            {
                Destroy(gameObject);
            }
        }
    }

    private void FireProjectile()
    {
        // Instantiate a new projectile at the firePoint position and rotation.
        GameObject newProjectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        // Get the Rigidbody component of the projectile and apply launch force to it.
        Rigidbody projectileRigidbody = newProjectile.GetComponent<Rigidbody>();
        if (projectileRigidbody != null)
        {
            projectileRigidbody.AddForce(firePoint.forward * launchForce, ForceMode.Impulse);
        }

    }
}