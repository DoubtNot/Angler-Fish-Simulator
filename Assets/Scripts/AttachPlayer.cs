using UnityEngine;

public class AttachPlayer : MonoBehaviour
{
    private void Start()
    {
        // Find the player object (assuming it has a "Player" tag)
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        // If player object is found, make it a child of this GameObject
        if (playerObject != null)
        {
            playerObject.transform.SetParent(transform);
        }
    }
}
