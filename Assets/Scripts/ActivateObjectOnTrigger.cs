using UnityEngine;

public class ActivateObjectOnTrigger : MonoBehaviour
{
    public GameObject tentaclePrefab; // Reference to the tentacle prefab
    public Transform spawnPoint; // The point where the projectile should spawn

    public string prefabTag = "SpawnedPrefab"; // Tag of the prefabs to be destroyed


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Boat"))
        {
            // Spawn the projectile at the spawn point
            GameObject projectile = Instantiate(tentaclePrefab, spawnPoint.position, Quaternion.identity);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Boat"))
        {
            // Find all GameObjects with the specified tag
            GameObject[] prefabs = GameObject.FindGameObjectsWithTag(prefabTag);

            // Destroy all prefabs
            for (int i = 0; i < prefabs.Length; i++)
            {
                Destroy(prefabs[i]);
            }
        }
    }
}
