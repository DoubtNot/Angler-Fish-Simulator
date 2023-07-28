using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public string playerTag = "Player"; // The tag of the player object to follow.
    public float movementSpeed = 5f; // The speed at which the object will move towards the player.

    private Transform targetPlayer; // Reference to the player's transform.

    private void Start()
    {
        // Find the nearest player with the specified tag at the start of the game.
        FindNearestPlayer();
    }

    private void Update()
    {
        if (targetPlayer != null)
        {
            // Calculate the direction to the player.
            Vector3 directionToPlayer = targetPlayer.position - transform.position;
            directionToPlayer.y = 0f; // Keep the object on the same plane as the player.

            // Move the object towards the player.
            transform.position += directionToPlayer.normalized * movementSpeed * Time.deltaTime;
        }
    }

    private void FindNearestPlayer()
    {
        // Find all game objects with the specified tag.
        GameObject[] players = GameObject.FindGameObjectsWithTag(playerTag);

        // If there are no players with the specified tag, return.
        if (players.Length == 0)
        {
            Debug.LogWarning("No objects found with tag: " + playerTag);
            return;
        }

        // Find the nearest player among the game objects with the specified tag.
        float nearestDistance = Mathf.Infinity;
        foreach (GameObject player in players)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            if (distanceToPlayer < nearestDistance)
            {
                nearestDistance = distanceToPlayer;
                targetPlayer = player.transform;
            }
        }
    }
}
