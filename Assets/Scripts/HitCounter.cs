using UnityEngine;
using UnityEngine.UI;

public class HitCounter : MonoBehaviour
{
    public Image uiImage; // Reference to the UI image component.
    public float healthImageDeactivateTime = 5f; // Time in seconds until the health image deactivates.
    public float alphaDecreaseRate = 0.1f; // Rate at which alpha decreases when not hit (0.1 means 10% per second).
    public int hitsForReset = 20; // Number of hits required for reset.

    private int currentHits = 0; // The current hit count starts at 0.
    private float healthImageTimer; // Timer to track the health image deactivation.

    public Vector3 resetLocation; // Variable for specifying the reset location.

    private void Start()
    {
        // Initialize the health image timer.
        healthImageTimer = healthImageDeactivateTime;

        // Make the UI image invisible at the start of the game.
        Color imageColor = uiImage.color;
        imageColor.a = 0f;
        uiImage.color = imageColor;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision involves the player (replace "EnemyAmmo" with the appropriate tag for the enemy ammo).
        if (collision.gameObject.CompareTag("EnemyAmmo"))
        {
            // Reset the health image timer.
            healthImageTimer = healthImageDeactivateTime;

            // Increment the hit count and update the UI image.
            currentHits++;
            UpdateUIImage();

            // Activate the UI image if it's not already active.
            if (!uiImage.gameObject.activeSelf)
            {
                uiImage.gameObject.SetActive(true);
            }

            // Check if the player has reached the hits for reset.
            if (currentHits >= hitsForReset)
            {
                // Call the reset location function.
                ResetPlayerLocation();
            }
        }
    }

    private void Update()
    {
        // If the UI image is active, update the health image timer.
        if (uiImage.gameObject.activeSelf)
        {
            healthImageTimer -= Time.deltaTime;

            // If the health image timer reaches zero, start decreasing the alpha gradually.
            if (healthImageTimer <= 0f)
            {
                Color imageColor = uiImage.color;
                imageColor.a -= alphaDecreaseRate * Time.deltaTime;
                imageColor.a = Mathf.Clamp01(imageColor.a); // Ensure alpha stays within [0, 1]
                uiImage.color = imageColor;

                // Deactivate the UI image if alpha is 0.
                if (imageColor.a == 0f)
                {
                    uiImage.gameObject.SetActive(false);
                }
            }
        }
    }

    private void UpdateUIImage()
    {
        // Update the alpha value based on the hit count.
        Color imageColor = uiImage.color;
        imageColor.a = currentHits * 0.05f; // Each hit increases alpha by 5 (0.05 * 100)
        uiImage.color = imageColor;
    }

    private void ResetPlayerLocation()
    {
        // Call your reset location function here.
        transform.position = resetLocation;
        currentHits = 0; // Reset the hit count.
        UpdateUIImage(); // Update the UI image to reset alpha.
    }
}
