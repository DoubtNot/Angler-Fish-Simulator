using UnityEngine;

public class BlueFlag : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FlagHolderBlue"))
        {
            // Set the object with the trigger as a child of the player
            transform.SetParent(other.transform);

            // Set the trigger object's position to the player's position
            transform.position = other.transform.position;

            // Copy the player's rotation to the trigger object
            transform.rotation = other.transform.rotation;

        }
    }
}
