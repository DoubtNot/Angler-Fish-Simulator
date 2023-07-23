using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float destroyDelay = 20f; // Time in seconds before the GameObject is destroyed

    private void Start()
    {
        // Start the countdown to destroy the GameObject
        Destroy(gameObject, destroyDelay);
    }
}
