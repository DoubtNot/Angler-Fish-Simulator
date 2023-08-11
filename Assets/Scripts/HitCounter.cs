using UnityEngine;
using UnityEngine.UI;

public class HitCounter : MonoBehaviour
{
    public GameObject uiImage; // Reference to the UI image game object.
    public Sprite[] hitSprites; // Array of sprites representing each hit.
    public float healthImageDeactivateTime = 5f; // Time in seconds until the health image deactivates.
    public float hitsDecreaseInterval = 1f; // Time interval in seconds to decrease hits.

    private int currentHits = 1; // The current hit count starts at 1.
    private float healthImageTimer; // Timer to track the health image deactivation.
    private float hitsDecreaseTimer; // Timer to track hits decrease interval.

    public Vector3 resetLocation; // Variable for specifying the reset location.


    private void Start()
    {
        // Deactivate the UI image at the start of the game.
        uiImage.SetActive(false);

        // Initialize the health image and hits timers.
        healthImageTimer = healthImageDeactivateTime;
        hitsDecreaseTimer = hitsDecreaseInterval;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision involves the player (replace "EnemyAmmo" with the appropriate tag for the enemy ammo).
        if (collision.gameObject.CompareTag("EnemyAmmo"))
        {
            // Reset the health image and hits timers.
            healthImageTimer = healthImageDeactivateTime;
            hitsDecreaseTimer = hitsDecreaseInterval;

            // Increment the hit count and update the UI image.
            currentHits++;
            UpdateUIImage();

            // Activate the UI image if it's not already active.
            if (!uiImage.activeSelf)
            {
                uiImage.SetActive(true);
            }

            // Check if the player has been hit 10 times.
            if (currentHits > 10)
            {
                // Reset the hit count to 1.
                currentHits = 1;
                uiImage.SetActive(false);
                
                //reset attached object's position to (15,5092,108) for OpenWorlds and (0,0,0) for Tutorial.
                transform.position = resetLocation;
            }
        }
    }

    private void Update()
    {
        // If the health image is active, update the health image timer.
        if (uiImage.activeSelf)
        {
            healthImageTimer -= Time.deltaTime;

            // If the health image timer reaches zero, start decreasing the hit count.
            if (healthImageTimer <= 0f)
            {
                // If the currentHits is already at 1, deactivate the UI and return.
                if (currentHits == 1)
                {
                    uiImage.SetActive(false);
                    return;
                }

                // Start decreasing the hit count.
                hitsDecreaseTimer -= Time.deltaTime;
                if (hitsDecreaseTimer <= 0f)
                {
                    currentHits--;
                    UpdateUIImage();
                    hitsDecreaseTimer = hitsDecreaseInterval;
                }
            }
        }
    }

    private void UpdateUIImage()
    {
        // Check if there is a valid sprite for the current hit count.
        if (currentHits <= hitSprites.Length && currentHits >= 1)
        {
            // Calculate the index to access the sprite based on the current hit count.
            int spriteIndex = currentHits - 1;

            // Update the UI image with the corresponding sprite.
            uiImage.GetComponent<Image>().sprite = hitSprites[spriteIndex];
        }
    }
}
