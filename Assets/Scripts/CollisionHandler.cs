using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public GameObject skateboard;
    public GameObject boat;
    public GameObject skateboardButton;
    public GameObject boatButton;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            // Deactivate skateboard and disable its button
            skateboard.SetActive(false);
            skateboardButton.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Land"))
        {
            // Deactivate boat and disable its button
            boat.SetActive(false);
            boatButton.SetActive(false);
        }
    }
}
